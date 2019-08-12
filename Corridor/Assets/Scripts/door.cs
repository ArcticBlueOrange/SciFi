using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{

    private bool trig = false;

    // Start is called before the first frame update
    void Start()
    {
        if(Input.GetKeyDown(KeyCode.E) && trig==true)
        {
            GetComponent<Animation>().Play("doorOpern");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Enter trig");
            trig = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Exit trig");
            trig = false;
        }
    }
}
