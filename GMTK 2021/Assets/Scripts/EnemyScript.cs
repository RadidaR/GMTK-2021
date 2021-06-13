using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int MovementDir;
    public float speed = 2f;
    Animator anim;
    public bool moving;
    public bool pushing;
    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Moving", moving);
        if (this.transform.position.x < 0)
        {
            MovementDir = 1;
        }
        else
            MovementDir = -1;

        FlipX(MovementDir);
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.position = transform.position + new Vector3(speed * MovementDir * Time.deltaTime,0,0);
            anim.Play("Guard Walk");
        }
        else
        {
            if (!pushing)
            {
            anim.Play("Guard Idle");

            }
        }
    }

    void FlipX(int direction)
    {
        Vector2 newScale = transform.localScale;
        newScale.x = Mathf.Abs(newScale.x) * -direction;
        transform.localScale = newScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        Destroy(gameObject, 0.2f);
    }

    public void MoveTrue()
    {
        moving = true;
    }
    public void PushFalse()
    {
        pushing = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<ControlScript>() != null)
        {
            moving = false;
            pushing = true;
            anim.Play("Guard_Push");
        }
        else if (collision.gameObject.tag == "EnemySpawn")
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
