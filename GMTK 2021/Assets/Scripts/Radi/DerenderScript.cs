using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DerenderScript : MonoBehaviour
{
    public GameData gameData;

    public Renderer[] renderers;
    // Start is called before the first frame update

    private void Awake()
    {
        if (transform.parent != null)
        {
            renderers = transform.parent.GetComponentsInChildren<Renderer>();
        }
    }
    private void OnEnable()
    {
        UpdateRenderer();
    }

    void Start()
    {
        InvokeRepeating("UpdateRenderer", 0, 5);
        //UpdateRenderer();
    }


    public void UpdateRenderer()
    {
        bool sameLayer;

        if (gameData.botControl)
        {
            if (Mathf.Abs(Mathf.Round(transform.position.y / gameData.laneDistance)) == gameData.playerLane)
            {
                sameLayer = true;
            }
            else
            {
                sameLayer = false;
            }


            foreach (Renderer renderer in renderers)
            {
                renderer.enabled = sameLayer;
            }
        }
        else
        {
            foreach (Renderer renderer in renderers)
            {
                renderer.enabled = true;
            }
        }

    }
}
