using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLayerScript : MonoBehaviour
{
    public GameData gameData;

    public SpriteRenderer sprite;
    public Color color;

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
            laneCalculation = Mathf.Abs(Mathf.RoundToInt(GetComponentInParent<ControlScript>().gameObject.transform.position.y / gameData.laneDistance));
        }
        else
        {
            laneCalculation = Mathf.Abs(Mathf.RoundToInt(transform.position.y / gameData.laneDistance));
        }

        return laneCalculation;
    }

    public void UpdateLayer()
    {
        int layer = lane();
        gameObject.layer = layer + 6;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponentInParent<ControlScript>() != null)
        {
            StartCoroutine(FlashSprite());
        }
    }

    IEnumerator FlashSprite()
    {
        yield return new WaitForSeconds(0.35f);
    }

}
