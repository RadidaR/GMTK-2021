using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionIndicatorScript : MonoBehaviour
{
    public GameObject directionIndicator;
    public Transform player;
    public Transform target;

    public LayerMask indicatorLayer;

    Renderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_renderer.isVisible)
        {
            if (!directionIndicator.activeInHierarchy)
            {
                directionIndicator.SetActive(true);
            }

            Vector2 directionToTarget = player.position - target.position;

            RaycastHit2D ray = Physics2D.Raycast(target.position, directionToTarget, Vector2.Distance(player.position, target.position), indicatorLayer);

            if (ray.collider != null)
            {
                //Debug.Log("hit");
                directionIndicator.transform.position = ray.point;
            }
        }
        else
        {
            if (directionIndicator.activeInHierarchy)
            {
                directionIndicator.SetActive(false);
            }
        }
    }

    
}
