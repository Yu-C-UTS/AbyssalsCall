using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIPathfinding : MonoBehaviour
{
    public Transform target;
    public float speed;
    //How far is the enemy need to be close to a waypoint before moving to next one
    public float nextWayWaypointDistance;

    private Path path;
    private int currentWayPoint = 0;
    private bool reachedEnd = false;

    private Seeker seeker;
    private Rigidbody2D rb;

    void Awake(){
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Start()
    {
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void FixedUpdate()
    {
        if(path == null){
            return;
        }

        if(currentWayPoint >= path.vectorPath.Count)
        {
            reachedEnd = true;
            return;
        }else{
            reachedEnd = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if(distance < nextWayWaypointDistance)
        {
            currentWayPoint++;
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }

    }


}
