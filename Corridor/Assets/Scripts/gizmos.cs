using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gizmos : MonoBehaviour
{
    public int Shape;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        switch (Shape)
        {
            case 0://Sphere
        Gizmos.DrawSphere(this.transform.position, 1);
                break;
            case 1: //rect
                ///Gizmos.DrawWireCube(this.transform.position, this.transform.lossyScale);
                //Gizmos.DrawWireCube(this.transform.position, this.transform.localScale);
                break;
        }
}
}
