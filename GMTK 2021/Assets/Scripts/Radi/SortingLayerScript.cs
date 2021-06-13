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
    }

    private void Start()
    {
        UpdateSortingLayer();
        if (gameObject.tag != "Player")
        {
            AssignSortingOrder();
        }
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
    }

    void AssignSortingOrder()
    {
        int layer = lane();
        if (gameObject.tag == "Ground")
        {
            foreach (SpriteRenderer renderer in sprites)
            {
                renderer.sortingOrder = -150;
            }
        }
        else
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                if ((transform.position.y - (gameData.laneDistance * layer) > 0))
                {
                    sprites[i].sortingOrder = originalOrder[i] - 30;
                }
                else if ((transform.position.y - (gameData.laneDistance * layer) < 0))
                {
                    sprites[i].sortingOrder = originalOrder[i] + 30;
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
