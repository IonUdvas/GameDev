using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPointandFollow : MonoBehaviour
{
    public NavMeshAgent EnemyPath;
    public Transform[] waypoints;

    public GameObject Player;
    bool m_PlayerIsSeen;


    int m_CurrentWaypointIndex;


    // Start is called before the first frame update
    void Start()
    {
        EnemyPath.SetDestination (waypoints[0].position);
    }

    public void SeenPlayer()
    { 
        m_PlayerIsSeen = true; 
    }

    // Update is called once per frame
    void Update()
    {
        // if(m_PlayerIsSeen){
        //     EnemyPath.SetDestination(Player.position);
        // }
        if(EnemyPath.remainingDistance < EnemyPath.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            EnemyPath.SetDestination (waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
