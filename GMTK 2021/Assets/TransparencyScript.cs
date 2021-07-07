using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyScript : MonoBehaviour
{
    public GameData gameData;
    public int lane;

    private void Awake()
    {
        InvokeRepeating("CheckPlayerLane", 1, 1f);
    }

    void CheckPlayerLane()
    {
        if (gameData.playerLane >= lane)
        {
            GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color.SetAlpha(0.6f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color.SetAlpha(); 
        }
    }

}
