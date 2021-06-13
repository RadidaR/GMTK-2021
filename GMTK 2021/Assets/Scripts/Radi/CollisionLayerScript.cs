using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLayerScript : MonoBehaviour
{
    public GameData gameData;

    private void Awake()
    {
        //Debug.Log(transform.parent.parent.name);
        //Debug.Log(transform.position.ToString());
        UpdateLayer();
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

    public void UpdateLayer()
    {
        int layer = lane();
        gameObject.layer = layer + 6;
    }

}