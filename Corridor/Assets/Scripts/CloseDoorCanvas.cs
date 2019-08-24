using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseDoorCanvas : MonoBehaviour
{
    public GameObject Player;
    public GameObject CanvasClose;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Player.tag)
        {
            CanvasClose.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Player.tag)
        {
            CanvasClose.SetActive(false);
        }
    }



    // Update is called once per frame

}
