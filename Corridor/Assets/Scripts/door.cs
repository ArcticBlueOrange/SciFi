using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private bool trig = false;
    public static bool open = false;
    public GameObject Player;
    public AudioSource Music;
    public GameObject DoorAnim;
    private Animator  anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && trig == true)
        {
           if(open==false)
            {
                anim = DoorAnim.GetComponent<Animator>();
                anim.SetBool("isOpen", true);
                Music.Stop();
                OpenCloseDoorCanvas.ChangeOpenTrigger();
                
            }
            if (open == true)
            {
                anim = DoorAnim.GetComponent<Animator>();
                anim.SetBool("isClose", true);
               
                OpenCloseDoorCanvas.ChangeOpenTrigger();

            }


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Player.tag)
        {
            Debug.Log("Enter trig");
            trig = true;
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Player.tag)
        {
            Debug.Log("Exit trig");
            trig = false;
        }
    }

    public static void ChangeAnimatorTrigger()
    {
        open = !open;
    }
}
