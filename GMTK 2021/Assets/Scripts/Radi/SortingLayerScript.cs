using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerScript : MonoBehaviour
{
    public GameData gameData;

    string laneLayer;

    public List<int> originalOrder;
    SpriteRenderer[] sprites;

    private void Awake()
    {
        sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer renderer in sprites)
        {
            originalOrder.Add(renderer.sortingOrder);
        }

        if (gameObject.tag != "Player")
        {
            AssignSortingOrder();
        }

        UpdateSortingLayer();
    }

    void Update()
    {
        if (gameObject.tag == "Player") 
        {
            UpdateSortingLayer();
        }

    }

    void UpdateSortingLayer()
    {
        //int lane = Mathf.RoundToInt(transform.position.y / gameData.laneDistance);
        int sortingLayer = lane();
        laneLayer = "Lane " + sortingLayer.ToString();


        //sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer renderer in sprites)
        {
            renderer.sortingLayerName = laneLayer;
        }

        if (gameObject.tag == "Player")
        {
            gameData.playerLane = sortingLayer;
        }
    }

    void AssignSortingOrder()
    {
        int layer = lane();
        if (gameObject.tag == "Ground")
        {
            foreach (SpriteRenderer renderer in sprites)
            {
                renderer.sortingOrder = -500;
            }
        }
        else
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                float pos = transform.position.y - (gameData.laneDistance * layer);

                if (pos > 0)
                {
                    sprites[i].sortingOrder = originalOrder[i] - Mathf.RoundToInt(100 * Mathf.Abs(pos));
                }
                else if (pos < 0)
                {
                    sprites[i].sortingOrder = originalOrder[i] + Mathf.RoundToInt(100 * Mathf.Abs(pos));
                }
            }
        }
    }

    public int lane()
    {
        int laneCalculation = Mathf.RoundToInt(transform.position.y / gameData.laneDistance);
        return laneCalculation;
    }


}
