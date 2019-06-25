using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_MovingObjectController : MonoBehaviour {

    //Special Thanks to Sebastian Lague for his 2D-Platformer Controller Series
    //Please check him out on Youtube

    public float speed = 1;             //the platforms movespeed (set in inspector)
    public bool isMoving = true;        
    public bool cyclic;                 //if set true, when reaching the last waypoint, the platform travels back to the first
    public float waitTime;              //time the platform pauses at each waypoint (set in inspector)
    public Vector3[] localWaypoints;    //the waypoints the platform travels (set in inspector)
    public int moveDirection = 1;

    [HideInInspector]
    public Vector3[] globalWaypoints;
    [HideInInspector]
    public int fromWaypointIndex;

    private float percentBetweenWaypoints;
    private float nextMoveTime;

    

    private void Start()
    {
        globalWaypoints = new Vector3[localWaypoints.Length];
        for(int i = 0;i< localWaypoints.Length; i++)
        {
            globalWaypoints[i] = localWaypoints[i]+transform.position;
        }
    }

    private void FixedUpdate()
    {
        Vector3 velocity = CalculateMovement();
        transform.Translate(velocity);
    }

    //drawing gizmos for better overview
    private void OnDrawGizmos()
    {
        if(localWaypoints != null)
        {
            Gizmos.color = Color.red;
            float size = .3f;
            for (int i = 0; i < localWaypoints.Length; i++)
            {
                Vector3 globalWaypointPosition =(Application.isPlaying)?globalWaypoints[i] : localWaypoints[i] + transform.position;
                Gizmos.DrawLine(globalWaypointPosition - Vector3.up * size, globalWaypointPosition + Vector3.up * size);
                Gizmos.DrawLine(globalWaypointPosition - Vector3.right * size, globalWaypointPosition + Vector3.right * size);
            }
        }
    }

    Vector3 CalculateMovement()
    {
        if(Time.time < nextMoveTime)
        {
            isMoving = false;
            return Vector3.zero;            
        }
        isMoving = true;
        fromWaypointIndex %= globalWaypoints.Length;
        int toWaypointIndex = (fromWaypointIndex + 1)%globalWaypoints.Length;
        float distanceBetweenWaypoints = Vector3.Distance(globalWaypoints[fromWaypointIndex], globalWaypoints[toWaypointIndex]);
        percentBetweenWaypoints += Time.deltaTime * speed/distanceBetweenWaypoints;
        Vector3 newPosition = Vector3.Lerp(globalWaypoints[fromWaypointIndex], globalWaypoints[toWaypointIndex], percentBetweenWaypoints);

        if(percentBetweenWaypoints >= 1)
        {
            percentBetweenWaypoints = 0;
            fromWaypointIndex++;
            nextMoveTime = Time.time + waitTime;
            if (!cyclic)
            {
                if (fromWaypointIndex >= globalWaypoints.Length - 1)
                {
                    fromWaypointIndex = 0;
                    ChangeMoveDirection();
                    System.Array.Reverse(globalWaypoints);
                }
            }
            

        }

        return newPosition-transform.position;
    }
    public virtual void ChangeMoveDirection()
    {
        moveDirection *= -1;
    }
}
