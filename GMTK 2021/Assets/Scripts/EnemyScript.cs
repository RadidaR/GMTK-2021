using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int MovementDir;
    public float speed = 2f;
    private void OnEnable()
    {
        if (this.transform.position.x < 0)
        {
            MovementDir = 1;
        }
        else
            MovementDir = -1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(speed * MovementDir * Time.deltaTime,0,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this);
    }
}
