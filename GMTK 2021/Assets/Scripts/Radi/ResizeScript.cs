using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeScript : MonoBehaviour
{
    public GameData gameData;

    float maxSize = 1;
    float minSize;

    float shrinkPerLane = 0.05f;
    private void Start()
    {
        minSize = maxSize - (gameData.numberOfLanes * shrinkPerLane);
    }
    public int lane()
    {
        int laneCalculation;
        if (GetComponentInParent<ControlScript>() != null)
        {
            laneCalculation = Mathf.RoundToInt(GetComponentInParent<ControlScript>().gameObject.transform.position.y / gameData.laneDistance);
        }
        else
        {
            laneCalculation = Mathf.RoundToInt(transform.position.y / gameData.laneDistance);
        }

        return laneCalculation;
    }

    private void Update()
    {
        Vector2 scale = transform.localScale;
        int currentLane = lane();
        scale.y = maxSize - currentLane * shrinkPerLane;

        //scale.y = Mathf.Lerp(maxSize, minSize, (transform.position.y / gameData.numberOfLanes * gameData.laneDistance));
        if (scale.x < 0)
        {
            //scale.x = -Mathf.Lerp(maxSize, minSize, (transform.position.y / gameData.numberOfLanes * gameData.laneDistance));
            scale.x = -scale.y;
        }
        else if (scale.x > 0)
        {
            scale.x = scale.y;
            //scale.x = Mathf.Lerp(maxSize, minSize, (transform.position.y / gameData.numberOfLanes * gameData.laneDistance));
        }

        transform.localScale = scale;
    }
}
