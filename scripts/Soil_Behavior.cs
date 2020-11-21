using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil_Behavior : MonoBehaviour
{
    public Animator animator;
    public ParticleSystem dirt;
    public void plant()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            animator.SetTrigger("planted");
        }
        
    }
    public void water()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("planted"))
        {
            animator.SetTrigger("water");
        }
    }
    public IEnumerator harvest()
    {
        yield return new WaitForSeconds(.8f);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("full"))
        {
            dirt.Play();
            animator.SetTrigger("harvested");
            Tools.stack();
        }
    }
}
