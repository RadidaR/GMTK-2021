using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerScript : MonoBehaviour
{
    public GameData gameData;

    public float timer;

    //public Color alpha;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        //alpha = renderer.color;
        timer = gameData.markerDuration;
    }

    private void Start()
    {
        StartCoroutine(Expire());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Expire()
    {
        while (timer > 0)
        {
            yield return new WaitForSecondsRealtime(Time.deltaTime);
            timer -= Time.deltaTime;
            Color transparency = spriteRenderer.color;
            transparency.a = Mathf.Lerp(0, 1, timer / gameData.markerDuration);
            spriteRenderer.color = transparency;
            if (timer <= 0)
            {
                break;
            }
        }

        FindObjectOfType<ControlScript>().markers.Remove(gameObject);
        Destroy(gameObject);
    }
}
