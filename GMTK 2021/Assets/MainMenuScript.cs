using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManagerScript>().PlaySound("Background_Music");
    }

    public void PlayAudio(string audioName)
    {
        FindObjectOfType<AudioManagerScript>().PlaySound(audioName);
    }

}
