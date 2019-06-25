using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_Trap : MonoBehaviour
{
    public float timeToActivate = 1;        //time it takes to acitvate the trap (set in inspector)
    public float timeToDeactivate= 1;       //time it takes to deactivate the trap (set in inspector)
    public bool triggeredTrap =true;        //triggered or automated trap?
    public GameObject attackCollider;       //the area in which damage is applied
    public GameObject trapTrigger;          //the area which triggers the trap (triggered Trap only)

    private bool trapActivated;
    private bool coroutineStarted=false;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        attackCollider.SetActive(false);
        if (!triggeredTrap)
        {
            trapTrigger.SetActive(false);
        }
    }

    private void Update()
    {
        AnimatorSetBools();

        if (!triggeredTrap)
        {
            if (!coroutineStarted)
            {
                StartCoroutine(AutoTrap());
            }
        }
    }

    //TriggerEnter and TriggerExit get called from within the TrapTrigger gameobject.
    //You can place the TrapTrigger wherever you want!

    public void TriggerEnter(Collider2D collision)
    {
        if (collision.CompareTag("Player") | collision.CompareTag("Enemy"))
        {
            StartCoroutine(ActivateTrap());
        }
    }

    public void TriggerExit(Collider2D collision)
    {
        if (collision.CompareTag("Player") | collision.CompareTag("Enemy"))
        {
            StartCoroutine(DeactivateTrap());
        }
    }

    private IEnumerator ActivateTrap()
    {    
        yield return new WaitForSeconds(timeToActivate);
        attackCollider.SetActive(true);
        trapActivated = true;
    }

    private IEnumerator DeactivateTrap()
    {
        yield return new WaitForSeconds(timeToDeactivate);
        trapActivated = false;
        attackCollider.SetActive(false);        
    }

    private IEnumerator AutoTrap()
    {
        coroutineStarted = true;
        yield return new WaitForSeconds(timeToActivate);
        trapActivated = true;
        attackCollider.SetActive(true);
        yield return new WaitForSeconds(timeToDeactivate);
        trapActivated = false;
        attackCollider.SetActive(false);
        coroutineStarted = false;
    }

    private void AnimatorSetBools()
    {
        animator.SetBool("trapActivated", trapActivated);
    }
}
