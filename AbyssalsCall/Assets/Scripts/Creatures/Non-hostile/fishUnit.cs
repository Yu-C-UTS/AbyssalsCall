using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishUnit : MonoBehaviour, IDamagable
{
    public GameObject manager { get; set; }
    public Vector2 location { get; set; }
    public Vector2 velocity { get; set; }

    private Rigidbody2D rb;
    private fishShoal shoalManager;

    private Vector2 goalPos = Vector2.zero;
    private Vector2 currentForce;

    public float Health = 10f;

    void Awake()
    {
        Health = 10f;
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        shoalManager = manager.GetComponent<fishShoal>();
    }

    private Vector2 seek(Vector2 target)
    {
        return (target - location);
    }

    private void applyForce(Vector2 force)
    {
        float maxForce = shoalManager.maxForce;
        float maxVelocity = shoalManager.maxVelocity;

        if (force.magnitude > maxForce)
        {
            force = force.normalized * maxForce;
        }

        rb.AddForce(force);

        if(rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
        Debug.DrawRay(this.transform.position, force, Color.white);
    }

    //Get the average direction of the group
    private Vector2 align()
    {
        float neighbourdist = shoalManager.neighbourDistance;
        Vector2 sumDirect = Vector2.zero;
        int neighbourCount = 0;
        foreach(GameObject other in shoalManager.units)
        {
            if (other == this.gameObject)
                continue;

            float distance = Vector2.Distance(location, other.GetComponent<fishUnit>().location);

            if(distance < neighbourdist)
            {
                sumDirect += other.GetComponent<fishUnit>().velocity;
                neighbourCount++;
            }
        }

        if(neighbourCount > 0)
            return sumDirect / neighbourCount - velocity;

        return Vector2.zero;
    }

    //Direction for move towards the average group location
    private Vector2 cohesion()
    {
        float neighbourdist = shoalManager.neighbourDistance;
        Vector2 sumLocation = Vector2.zero;
        int neighbourCount = 0;
        foreach (GameObject other in shoalManager.units)
        {
            if (other == this.gameObject)
                continue;

            float distance = Vector2.Distance(location, other.GetComponent<fishUnit>().location);

            if (distance < neighbourdist)
            {
                sumLocation += other.GetComponent<fishUnit>().location;
                neighbourCount++;
            }
        }

        if (neighbourCount > 0)
            return seek(sumLocation / neighbourCount);

        return Vector2.zero;
    }

    private void flock()
    {
        location = this.transform.position;
        velocity = rb.velocity;

        if(shoalManager.obedient && Random.Range(0, 50) <= 1)
        {
            if (shoalManager.seekGoal)
            {
                currentForce = seek(goalPos) + align() + cohesion();
            }
            else
            {
                currentForce = align() + cohesion();
            }

            currentForce = currentForce.normalized;
        }

        if(shoalManager.willful && Random.Range(0, 50) <= 1)
        {
            if(Random.Range(0, 50) <= 1)
            {
                currentForce = new Vector2(Random.Range(-rb.velocity.x, rb.velocity.x), Random.Range(-rb.velocity.y, rb.velocity.y));
            }
        }

        applyForce(currentForce);
    }

    private void OnDestroy()
    {
        shoalManager.units.Remove(this.gameObject);
    }

    void Update()
    {
        flock();
        goalPos = shoalManager.GoalPos;
        //transform.localScale = new Vector3(rb.velocity.normalized.x, 1, 1);
        if(rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(Damage damage)
    {
        Health -= damage.baseDamageValue;
    }
}
