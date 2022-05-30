using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternFish : DashingEnemy
{
    public float shootinCooldown = 10;
    private float shootinCooldownTimer;

    public GameObject ball;
    public Transform shootingpos;

    protected override void Awake()
    {
        maxHealth = 500;
        Health = maxHealth;
        pfController = new PathfindingController(transform, PickRandomPoint());
        dashCoolTimer = 0;
        dashAttack = false;
        shootinCooldownTimer = shootinCooldown;
    }
    protected override void LateUpdate()
    {
        UpdateFacingDirection();
        AbysallBall();
    }

    private void AbysallBall()
    {
        shootinCooldownTimer -= Time.deltaTime;

        if (shootinCooldownTimer > 0) return;

        shootinCooldownTimer = shootinCooldown;

        Instantiate(ball, shootingpos.position, Quaternion.identity);
    }


}
