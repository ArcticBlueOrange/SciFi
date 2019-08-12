using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieAnimation : MonoBehaviour
{
    public Animator animator;
    public bool isAnimating = false;
    public bool timing = false;
    public bool attack = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("startWalk", 5);
        Invoke("startAttack", 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(timing && attack==false)
        {
            animator.SetBool("isTime", true);
        }
        if (attack)
        {
            animator.SetBool("isTime", false);
            animator.SetBool("isTrigger", true);
        }
    }

    void startWalk()
    {
        timing = !timing;
    }

    void startAttack()
    {
        attack = !attack;
    }
}
