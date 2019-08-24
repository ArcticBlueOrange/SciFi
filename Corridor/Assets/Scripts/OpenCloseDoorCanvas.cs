using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseDoorCanvas : MonoBehaviour
{
    public GameObject Player;
    public GameObject CanvasOpenCloseDoor;
    public Text open;
    public Text close;

    private static bool isOpen = false;
  

    // Start is called before the first frame update
    
        private void OnTriggerEnter(Collider other)
        {
          if(  other.tag == Player.tag )
        {
            CanvasOpenCloseDoor.SetActive(true);
            if(isOpen==false)
            {
                
                open.text = "Press E to open";
            }
            if (isOpen == true)
            {
               // Door.ChangeAnimatorTrigger();
                open.text = " ";
            }
        }
        }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Player.tag)
        {
            CanvasOpenCloseDoor.SetActive(false);
        }
    }

    public static void ChangeOpenTrigger()
    {
        isOpen = !isOpen;
    }

    
    



    // Update is called once per frame

}
