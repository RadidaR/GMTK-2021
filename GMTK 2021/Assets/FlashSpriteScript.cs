using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashSpriteScript : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Color color;
    public int numberOfFlashes = 3;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<ControlScript>() != null)
        {
            StartCoroutine(FlashSprite());
        }
    }

    IEnumerator FlashSprite()
    {
        for (int i = 0; i < numberOfFlashes; i++)
        {
            sprite.color = color;
            yield return new WaitForSeconds(0.15f);
            sprite.color = Color.white;
            yield return new WaitForSeconds(0.15f);
        }
    }
}
