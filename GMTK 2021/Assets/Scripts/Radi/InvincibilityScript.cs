using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityScript : MonoBehaviour
{
    public GameData gameData;

    SpriteRenderer[] renderers;
    bool coroutineRunning;
    // Start is called before the first frame update
    void Start()
    {
        renderers = GetComponentsInChildren<SpriteRenderer>();
    }

    IEnumerator HurtFrames()
    {
        while (gameData.invincible)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            
            foreach (SpriteRenderer renderer in renderers)
            {
                Color flashColor = renderer.color;

                if (flashColor == Color.white)
                {
                    flashColor = Color.red;
                }
                else if(flashColor == Color.red)
                {
                    flashColor = Color.white;
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

        coroutineRunning = false;
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

        coroutineRunning = false;
    }

    // Update is called once per frame
    public void InvincibilityFrames()
    {
        if (!coroutineRunning)
        {
            coroutineRunning = true;
            StartCoroutine(Invincibility());
        }
    }

    private void Update()
    {
        if (!coroutineRunning)
        {
            if (gameData.invincible)
            {
                InvincibilityFrames();
            }
        }
    }
}
