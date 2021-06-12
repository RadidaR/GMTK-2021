using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerScript : MonoBehaviour
{
    public GameData gameData;

    string laneLayer;

    void Update()
    {
        int lane = Mathf.RoundToInt(transform.position.y / gameData.laneDistance);
        laneLayer = "Lane " + lane.ToString();


        SpriteRenderer[] sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer renderer in sprites)
        {
            renderer.sortingLayerName = laneLayer;

        }
    }


}
