using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipScript : MonoBehaviour
{
    public Transform target;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > transform.position.x)
        {
            Vector2 scale = transform.localScale;
            scale.x = Mathf.Abs(transform.localScale.x);
            transform.localScale = scale;
        }
        else
        {
            Vector2 scale = transform.localScale;
            scale.x = -Mathf.Abs(transform.localScale.x);
            transform.localScale = scale;

        }
    }
}
