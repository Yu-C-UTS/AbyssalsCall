using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PathfindingController
{
    public Transform target { get; set; }
    public float speed { get; set; }
    //How far is the enemy need to be close to a waypoint before moving to next one
    private float nextWayWaypointDistance;

    private int currentWayPoint = 0;
    private Seeker seeker;
    private Rigidbody2D rb;

    private bool reachedEnd = false;
    private Path path;

    public PathfindingController(Transform self, Transform target)
    : this(self, target, 100f, 1.5f)
    { }

    public PathfindingController(Transform self, Transform target, float speed)
    : this(self, target, speed, 1.5f)
    { }

    public PathfindingController(Transform self, Transform target, float speed, float nextWayWaypointDistance)
    {
        this.target = target;
        this.speed = speed;
        this.nextWayWaypointDistance = nextWayWaypointDistance;
        if(seeker = self.GetComponent<Seeker>())
            Debug.Log("Seeker Assigned: " + seeker);
        else
            throw new System.Exception("Seeker not found in " + target);

        if(rb = self.GetComponent<Rigidbody2D>())
            Debug.Log("Rigidbody Assigned: " + rb);
        else
            throw new System.Exception("Rigidbody not found in " + target);

    }

    public void UpdateMovement()
    {
        if(path == null || target == null)
        {
            return;
        }
        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEnd = true;
            return;
        }
        else
        {
            reachedEnd = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWayWaypointDistance)
        {
            currentWayPoint++;
        }
    } 


    public void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
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





















}
