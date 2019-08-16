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
    public float timeInChase;
    public float lastSeen;
    public float timeInIdle;
    public float timeWaited;
    public Transform Player;
    public Transform patHolder;
    private Vector3[] wayPoints;
    public int targetPoint;
    public float rotateSpeed;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        wayPoints = new Vector3[patHolder.childCount];
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = patHolder.GetChild(i).position;
        }
        
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
        //rotate on place
        Vector3 targetDir = new Vector3(wayPoints[targetPoint].x - transform.position.x,
                                        transform.forward.y,
                                        wayPoints[targetPoint].z - transform.position.z);
        float step = rotateSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);

        timeWaited += Time.deltaTime;
        if (timeWaited >= timeInIdle)
        {
            timeWaited = 0;
            state = 1;//patrol
            zombieAnimation.startWalk();
        }
    }

    void patrol()
    {
        transform.LookAt( new Vector3(wayPoints[targetPoint].x,
                                      transform.position.y,
                                      wayPoints[targetPoint].z));
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        float distanceFromWayPoint = Vector3.Distance(transform.position, wayPoints[targetPoint]);
        //TODO, instead of move, call the script AIDestinationSetter and change the destination
        if(distanceFromWayPoint <= 0.5f)
        {
            state = 0; //idle
            zombieAnimation.startIdle();
            targetPoint = (targetPoint + 1) % wayPoints.Length;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            state = 2;
            zombieAnimation.startAttack();
            timeWaited = 0;
            lastSeen = 0;
        }
    }         

    void chase()
    {
        //Moves toward player
        transform.LookAt(Player);
        //TODO, instead of move, call the script AIDestinationSetter and change the destination to Player
        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                // Destroy(this.gameObject, 1f);
        
            }
        }
        lastSeen += Time.deltaTime;
        if (lastSeen >= timeInChase)
        {
            lastSeen = 0;
            state = 0;
        }
        //TODO - Transform player must be updated with the last seen position of the player if lastSeen is too high
        //TODO - Path to follow;
    }
    private void OnDrawGizmos()
    {
        Vector3 startPosition = patHolder.GetChild(0).position;
        Vector3 lastPosition = startPosition;
        foreach(Transform wayPoint in patHolder)
        {
            Gizmos.DrawSphere(wayPoint.position, 1);
            Gizmos.DrawLine(wayPoint.position, lastPosition);
            lastPosition = wayPoint.position;
        }
        Gizmos.DrawLine(lastPosition, startPosition);
    }
}
