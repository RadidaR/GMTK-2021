using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int MovementDir;
    public float speed = 2f;
    public Animator anim;
    public bool moving;
    public bool pushing;

    public GameData gameData;
    private void OnEnable()
    {
        anim = GetComponentInChildren<Animator>();
        //anim.SetBool("Moving", true);
        if (this.transform.position.x < 0)
        {
            MovementDir = 1;
        }
        else
            MovementDir = -1;

        FlipX(MovementDir);
    }

    private void Start()
    {
        if (moving)
        {
            MoveTrue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            //transform.position = transform.position + new Vector3(speed * MovementDir * Time.deltaTime,0,0);
            GetComponent<Rigidbody2D>().MovePosition(transform.position + new Vector3(speed * MovementDir * Time.deltaTime, 0, 0));
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
        if (collision.gameObject.GetComponentInParent<ControlScript>() != null)
        {
            if (!pushing && !gameData.hurt)
            {
                moving = false;
                anim.SetBool("Moving", false);
                pushing = true;
                anim.Play("Guard_Push");
            }
        }
        else
        {
            Debug.Log("hit collider");
            Destroy(gameObject, 0.1f);
        }
    }

    public void MoveTrue()
    {
        anim.SetBool("Moving", true);
        moving = true;
    }
    public void PushFalse()
    {
        pushing = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Hit trigger");

        if (collision.gameObject.GetComponentInParent<ControlScript>() != null)
        {
            moving = false;
            pushing = true;
            anim.Play("Guard_Push");
        }
        else
        {
            if (collision.gameObject.layer == 15)
            {
                Destroy(gameObject, 0.1f);
            }
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log("trigger");
    //}
}
