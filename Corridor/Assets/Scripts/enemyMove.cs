using UnityEngine;
using System.Collections;

public class enemyMove : MonoBehaviour
{
    public Transform Player;
    public int MoveSpeed = 4;
    public int MinDist = 5;
    public int MaxDist = 10;


    void Start()
    {

    }

    void Update()
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
    }
}