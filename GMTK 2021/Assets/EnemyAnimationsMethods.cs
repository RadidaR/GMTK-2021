using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationsMethods : MonoBehaviour
{
    EnemyScript script;
    public AudioSource stepAudio;
    public AudioSource kickAudio;
    private void Awake()
    {
        script = GetComponentInParent<EnemyScript>();
    }
    public void PushFalse()
    {
        script.pushing = true;
    }

    public void MoveTrue()
    {
        script.anim.SetBool("Moving", true);
        script.moving = true;
    }

    public void PlayFootStep()
    {
        stepAudio.Play();
    }

    public void PlayCollisionSound()
    {
        kickAudio.Play();
    }
}
