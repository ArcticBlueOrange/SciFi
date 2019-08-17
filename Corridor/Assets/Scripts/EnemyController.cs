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
    public Transform Playerholder;
    public Transform patHolder;
    //private Vector3[] wayPoints;
    private Transform[] wayPoints;
    public int targetPoint;
    public float rotateSpeed;

    void Start()
    {
        Playerholder = GameObject.FindGameObjectWithTag("Player").transform;
        wayPoints = new Transform[patHolder.childCount];//new Vector3[patHolder.childCount];
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = patHolder.GetChild(i).transform;
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
        //Need to check if all this is removable
        Vector3 targetDir = new Vector3(wayPoints[targetPoint].position.x - transform.position.x,
                                        transform.forward.y,
                                        wayPoints[targetPoint].position.z - transform.position.z);
        float step = rotateSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
        //GetComponent<Pathfinding.AIDestinationSetter>().target = null;

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
        //check if this is removable?
        transform.LookAt( new Vector3(wayPoints[targetPoint].position.x,
                                      transform.position.y,
                                      wayPoints[targetPoint].position.z));
        //transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        GetComponent<Pathfinding.AIDestinationSetter>().target = wayPoints[targetPoint];
        float distanceFromWayPoint = Vector3.Distance(transform.position, wayPoints[targetPoint].position);
        if (distanceFromWayPoint <= 0.5f)
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
        transform.LookAt(Playerholder);
        //TODO, instead of move, call the script AIDestinationSetter and change the destination to Player
        GetComponent<Pathfinding.AIDestinationSetter>().target = Playerholder;
        //if (Vector3.Distance(transform.position, Playerholder.position) >= MinDist)
        //{
        //    transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        //    if (Vector3.Distance(transform.position, Playerholder.position) <= MaxDist)
        //    {
        //        // Destroy(this.gameObject, 1f);
        //
        //    }
        //}
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
