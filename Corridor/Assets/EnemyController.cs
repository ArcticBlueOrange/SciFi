using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int state; //0-idle, 1-path, 2-chase
    public int MoveSpeed = 4;
    public int MinDist = 5;
    public int MaxDist = 10;
    public float timeToIdle;
    public float lastSeen;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        switch (state)
        {
            case 0: //idle
                idle();
                break;
            case 1: //patrol
                patrol();
                break;
            case 2:
                chase();
                break;
        }
    }

    void idle()
    {

    }

    void patrol()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        print(other);
        print(other.tag);
        if (other.tag == "Player")
        {
            state = 2;
        }
    }         

    void chase()
    {
        //Moves towrd player
        transform.LookAt(Player);
        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
        
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        
        
            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                // Destroy(this.gameObject, 1f);
        
            }
        }
        lastSeen += Time.deltaTime;
        if (lastSeen >= timeToIdle)
        {
            lastSeen = 0;
            state = 0;
        }
        //TODO - Transform player must be updated with the last seen position of the player if lastSeen is too high
        //TODO - Path to follow;
    }
}
