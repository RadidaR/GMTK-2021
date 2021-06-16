using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{
    public GameData gameData;

    public float hurtTimer;

    public GameEvent eHit;
    public GameEvent eGameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameData.currentHealth = gameData.startingHealth;
    }

    private void Update()
    {
        if (hurtTimer > 0)
        {
            hurtTimer -= Time.deltaTime;
        }
        else if (hurtTimer < 0)
        {
            if (gameData.hurt)
            {
                gameData.hurt = false;
                hurtTimer = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameData.invincible)
        {
            if (gameData.currentHealth > 0)
            {
                gameData.hurt = true;
                //gameData.invincible = true;
                eHit.Raise();
                hurtTimer = gameData.hurtDuration;
            }
            else if (gameData.currentHealth == 0)
            {
                eGameOver.Raise();
            }
        }
    }

    public void Damage()
    {
        gameData.currentHealth--;
    }
}
