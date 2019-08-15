using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieAnimation : MonoBehaviour
{
    public Animator animator;
    public bool isAnimating = false;
    public static bool walk = false;
    public static bool attack = false;
    public static bool idle = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(walk)
        {
            animator.SetBool("isWalk", true);
            animator.SetBool("isTrigger", false);
            animator.SetBool("isIdle", false);
        }
        if (attack)
        {
            animator.SetBool("isTrigger", true);
            animator.SetBool("isWalk", false);
            animator.SetBool("isIdle", false);
        }
        if (idle)
        {
            animator.SetBool("isWalk", false);
            animator.SetBool("isTrigger", false);
            animator.SetBool("isIdle", true);
        }
    }

    public static void startWalk()
    {
        Debug.Log("walk");
        walk = !walk;
        idle = false;
        attack = false;
    }

    public static void startAttack()
    {
        Debug.Log("attack");
        attack = !attack;
        walk = false;
        idle = false;
    }

    public static void startIdle()
    {
        Debug.Log("idle");
        idle = !idle;
        walk = false;
        attack = false;
    }
}
