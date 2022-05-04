using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBossMovement : MonoBehaviour
{

    public float speed = 5;

    private Transform target;
    private Rigidbody2D rb;

    [SerializeField]
    private CrabBoss anim;

    [SerializeField]
    private Transform myCenter;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (target)
        {
            rb.AddForce(directionTo(target) * speed);
        }
        UpdateFacingDirection();

        if (rb.velocity.x >= 0)
        {
            anim.AddAnimation(anim.walk, true);
        }
    }

    protected Vector2 directionTo(Transform target)
    {
        Vector2 direction = target.position - myCenter.position;
        direction.y = 0;
        return direction.normalized;
    }

    protected void UpdateFacingDirection()
    {
        if (target == null)
        {
            if (rb.velocity.x >= 0.01f)
            {
                GetComponentInChildren<Transform>().localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (rb.velocity.x <= -0.01f)
            {
                GetComponentInChildren<Transform>().localScale = new Vector3(1f, 1f, 1f);
            }
        }
        else
        {
            if (directionTo(target).x >= 0.01)
            {
                GetComponentInChildren<Transform>().localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (directionTo(target).x <= -0.01)
            {
                GetComponentInChildren<Transform>().localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }
}
