using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
//using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.PostProcessing;
//using UnityEngine.Experimental.Rendering.Universal;

public class TunnelVisionScript : MonoBehaviour
{
    public GameData gameData;

    public GameObject tunnelVision;
    public Light2D[] lights;

    public GameObject filters;

    private void Start()
    {
        lights = GetComponentsInChildren<Light2D>();
    }

    private void Update()
    {
        if (gameData.botControl)
        {
            TunnelVision();
        }
        else
        {
            EndTunnelVision();
        }
    }

    private void TunnelVision()
    {
        tunnelVision.SetActive(true);
        SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
        //filters.GetComponent<PostProcessVolume>().
        filters.SetActive(true);


        foreach (Light2D light in lights)
        {
            if (renderer.sortingLayerName != light.gameObject.name)
            {
                light.enabled = false;
            }
            else
            {
                light.enabled = true;
            }
        }

    }

    private void EndTunnelVision()
    {
        tunnelVision.SetActive(false);
        filters.SetActive(false);
    }
}
