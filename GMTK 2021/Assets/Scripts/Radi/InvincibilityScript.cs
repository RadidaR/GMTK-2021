using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityScript : MonoBehaviour
{
    public GameData gameData;

    SpriteRenderer[] renderers;
    bool invincibilityCoroutine;
    bool hurtCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        renderers = GetComponentsInChildren<SpriteRenderer>();
    }

    IEnumerator Hurt()
    {
        while (gameData.hurt)
        {
            gameData.invincible = true;
            yield return new WaitForSecondsRealtime(0.2f);
            
            foreach (SpriteRenderer renderer in renderers)
            {
                Color flashColor = renderer.color;
                flashColor.a = 1;

                if (flashColor == Color.white)
                {
                    flashColor = Color.red;
                    flashColor.a = 0.35f;
                }
                else if(flashColor == Color.red)
                {
                    flashColor = Color.white;
                    flashColor.a = 0.75f;
                }
                renderer.color = flashColor;
            }

            if (!gameData.hurt)
            {
                break;
            }
        }

        gameData.invincible = false;

        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.color = Color.white;
        }

        hurtCoroutine = false;
    }

    IEnumerator Invincibility()
    {
        while (gameData.invincible)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            
            foreach (SpriteRenderer renderer in renderers)
            {
                Color flashColor = renderer.color;

                if (flashColor.a > 0.3f)
                {
                    flashColor.a = 0.3f;
                }
                else if(flashColor.a < 0.4f)
                {
                    flashColor.a = 1;
                }

                renderer.color = flashColor;
            }

            if (!gameData.invincible)
            {
                break;
            }
        }

        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.color = Color.white;
        }

        invincibilityCoroutine = false;
    }

    // Update is called once per frame
    public void InvincibilityFrames()
    {
        if (!invincibilityCoroutine)
        {
            invincibilityCoroutine = true;
            StartCoroutine(Invincibility());
        }
    }

    public void HurtFrames()
    {
        if (!hurtCoroutine)
        {
            hurtCoroutine = true;
            StartCoroutine(Hurt());
        }
    }

    private void Update()
    {
        //if (!coroutineRunning)
        //{
        //    if (gameData.invincible)
        //    {
        //        InvincibilityFrames();
        //    }
        //}
    }
}
