using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gizmos : MonoBehaviour
{
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
        Gizmos.DrawSphere(this.transform.position, 1);
    }
}
