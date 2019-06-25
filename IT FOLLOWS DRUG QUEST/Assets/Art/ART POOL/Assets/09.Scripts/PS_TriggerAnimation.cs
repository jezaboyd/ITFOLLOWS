using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_TriggerAnimation : MonoBehaviour
{
    public string triggerTag = "AnimationTrigger"; //Set Tag that should trigger the animation in inspector!
    private Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(triggerTag))
        {
            anim.SetBool("TriggerAnimation", true);
        }
    }

}
