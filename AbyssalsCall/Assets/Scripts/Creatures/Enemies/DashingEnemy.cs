using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashingEnemy : BasicEnemyMovement
{
    [SerializeField]
    private float DashDistance = 3f;
    [SerializeField]
    private float DashForce = 550f;
    [SerializeField]
    private float DashWait = 1f;

    private float dashDuration = 1f;
    private float dashCoolDown = 4f;
    private float dashCoolTimer;

    protected override void Awake()
    {
        pfController = new PathfindingController(transform, PickRandomPoint());
        dashCoolTimer = 0;
    }

    protected override void FixedUpdate()
    {
        detectPlayer("Player", detectRadius);
        UpdateSpeed();
        if (dashActive())
        {
                StartCoroutine(Dash());
        }
        pfController.UpdateMovement();
    }
    protected override void UpdateSpeed()
    {
        if (hasTarget)
        {
            pfController.speed = chaseSpeed;
        }
      /*  else if(hasTarget && !dashActive() && distanceTo(target) < DashDistance)
        {
            pfController.speed = 0;
        }*/
        else
        {
            pfController.speed = normalSpeed;
        }
        //Debug.Log(pfController.speed);
    }
    private bool dashActive()
    {
        if(dashCoolTimer <= 0)
        {
            dashCoolTimer = dashCoolDown;
            if (hasTarget)
            {
                if (distanceTo(target) < DashDistance)
                {
                    return true;
                }
            }
        }
        else
        {
            dashCoolTimer -= Time.deltaTime;
        }
        return false;
    }

    private IEnumerator Dash()
    {
        GetComponent<Rigidbody2D>().AddForce(-directionTo(target) * pfController.speed);
        yield return new WaitForSeconds(DashWait);
        Vector2 dashDirect = directionTo(target);
        GetComponent<Rigidbody2D>().AddForce(directionTo(target) * DashForce);
        hasTarget = false;
        yield return new WaitForSeconds(dashDuration);
        GetComponent<Rigidbody2D>().AddForce(-dashDirect * DashForce/2);
    }
}
