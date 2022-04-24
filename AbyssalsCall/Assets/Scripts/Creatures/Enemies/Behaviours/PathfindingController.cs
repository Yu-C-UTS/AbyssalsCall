using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PathfindingController
{
    public Vector3 targetPos { get; set; }
    public float speed { get; set; }
    //How far is the enemy need to be close to a waypoint before moving to next one
    private float nextWayWaypointDistance;

    private int currentWayPoint = 0;
    private Seeker seeker;
    private Rigidbody2D rb;

    private bool reachedEnd = false;
    private Path path;


    //Taking Tansform as target
    public PathfindingController(Transform self, Transform target)
    : this(self, target.position, 100f, 1.5f)
    { }

    public PathfindingController(Transform self, Transform target, float speed)
    : this(self, target.position, speed, 1.5f)
    { }

    //Taking Vector3 as Input
    public PathfindingController(Transform self, Vector3 targetPos)
    : this(self, targetPos, 50f, 1.5f)
    { }

    public PathfindingController(Transform self, Vector3 targetPos, float speed)
    : this(self, targetPos, speed, 1.5f)
    { }

    public PathfindingController(Transform self, Vector3 targetPos, float speed, float nextWayWaypointDistance)
    {
        this.targetPos = targetPos;
        this.speed = speed;
        this.nextWayWaypointDistance = nextWayWaypointDistance;
        if (seeker = self.GetComponent<Seeker>())
            Debug.Log("Seeker Assigned: " + seeker);
        else
            throw new System.Exception("Seeker not found in " + self);

        if (rb = self.GetComponent<Rigidbody2D>())
            Debug.Log("Rigidbody Assigned: " + rb);
        else
            throw new System.Exception("Rigidbody not found in " + self);

    }

    //Physics Update
    public void UpdateMovement()
    {
        if(path == null || targetPos == null)
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

    public void StayStill()
    {
        rb.velocity = Vector2.zero;
    }

    //Path Update
    public void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, targetPos, OnPathComplete);
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
