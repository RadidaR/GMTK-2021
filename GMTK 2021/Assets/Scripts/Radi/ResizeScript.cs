using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeScript : MonoBehaviour
{
    public GameData gameData;

    float maxSize = 1;
    float minSize;

    float shrinkPerLane = 0.075f;
    private void Start()
    {
        minSize = maxSize - (gameData.numberOfLanes * shrinkPerLane);
        UpdateSize();
    }
    public int lane()
    {
        int laneCalculation;
        if (GetComponentInParent<ControlScript>() != null)
        {
            laneCalculation = Mathf.Abs(Mathf.RoundToInt(GetComponentInParent<ControlScript>().gameObject.transform.position.y / gameData.laneDistance));
        }
        else
        {
            laneCalculation = Mathf.Abs(Mathf.RoundToInt(transform.position.y / gameData.laneDistance));
        }

        return laneCalculation;
    }

    private void Update()
    {
        //Vector2 scale = transform.localScale;
        int currentLane = lane();

        if (gameObject.tag == "Player")
        {
            UpdateSize();
            //Debug.Log((gameData.numberOfLanes * gameData.laneDistance).ToString());

        }

        
    }

    void UpdateSize()
    {
        Vector2 scale;

        if (gameObject.tag != "Player")
        {
            int currentLane = lane();

            scale.y = maxSize - currentLane * shrinkPerLane;
        }
        else
        {
            scale.y = Mathf.Lerp(maxSize, minSize, transform.position.y / (gameData.numberOfLanes * gameData.laneDistance));
        }

        if (transform.localScale.x < 0)
        {
            scale.x = -scale.y;
        }
        else if (transform.localScale.x > 0)
        {
            scale.x = scale.y;
        }
        else
        {
            return;
        }

        transform.localScale = scale;

    }
}
