using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public GameData gameData;

    Animator anim;
    //Animation[] animations;
    string currentAnimation;
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        string idle = "Goblin Idle";
        PlayAnimation(idle);

    }

    private void Update()
    {
        anim.SetBool("Walking", GetComponentInParent<ControlScript>().walking);
    }

    public void PlayAnimation(string newAnimation)
    {
        if (currentAnimation == newAnimation)
        {
            return;
        }

        anim.Play(newAnimation);

        currentAnimation = newAnimation;
    }
}
