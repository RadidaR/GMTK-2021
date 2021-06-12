using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpritesScript : MonoBehaviour
{
    public GameObject helmet;
    public GameObject chestplate;

    public GameData gameData;

    [Range(0, 1)] public float transparency;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer[] chestplateSprites = chestplate.GetComponentsInChildren<SpriteRenderer>();
        SpriteRenderer[] helmetSprites = helmet.GetComponentsInChildren<SpriteRenderer>();
        if (gameData.botControl)
        {

            foreach (SpriteRenderer renderer in chestplateSprites)
            {
                Color transparent = renderer.color;
                transparent.a = transparency;
                renderer.color = transparent;
            }

            foreach (SpriteRenderer renderer in helmetSprites)
            {
                Color transparent = renderer.color;
                transparent.a = 1f;
                renderer.color = transparent;
            }
        }
        else
        {
            foreach (SpriteRenderer renderer in chestplateSprites)
            {
                Color transparent = renderer.color;
                transparent.a = 1f;
                renderer.color = transparent;
            }

            foreach (SpriteRenderer renderer in helmetSprites)
            {
                Color transparent = renderer.color;
                transparent.a = transparency;
                renderer.color = transparent;
            }

        }
    }
}
