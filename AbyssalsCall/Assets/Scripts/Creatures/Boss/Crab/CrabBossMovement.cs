using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBossMovement : MonoBehaviour
{
    public float speed = 5;
    public float stopDist = 6;

    private Vector2 lastPos;

    [SerializeField]
    private CrabBoss anim;

    [SerializeField]
    private Transform myCenter;

    private CrabBossState myState;

    private void Awake()
    {
        myState = gameObject.GetComponent<CrabBossState>();
    }

    void Update()
    {

        if (myState.getTarget())
        {
            if(horizontalDistanceTo(myState.getTarget()) > stopDist)
            {
                follow(myState.getTarget());
            }
        }

        UpdateFacingDirection();

        if (myMovingDirection() != 0)
        {
            anim.AddAnimation(anim.walk, true);
        }
        else
        {
            anim.SetAnimation(anim.idle, true);
        }
    }

    private Vector2 horizontalDirectionTo(Transform target)
    {
        Vector2 direction = target.position - myCenter.position;
        direction.y = 0;
        return direction.normalized;
    }

    private float horizontalDistanceTo(Transform target)
    {
        Vector2 targetPos = new Vector2(target.position.x, myCenter.position.y);
        return Vector2.Distance(targetPos, myCenter.position);
    }

    private float myMovingDirection()
    {
        Vector2 movingDirection = new Vector2(0, 0);
        movingDirection = lastPos - new Vector2(transform.position.x, transform.position.y);
        return movingDirection.x;
    }

    private void follow(Transform target)
    {
        Vector2 targetPos = new Vector2(target.position.x, transform.position.y);
        lastPos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    protected void UpdateFacingDirection()
    {
        if(myMovingDirection() > 0f)
        {
            GetComponentInChildren<Transform>().localScale = new Vector3(1f, 1f, 1f);
        }else if(myMovingDirection() < 0f)
        {
            GetComponentInChildren<Transform>().localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
