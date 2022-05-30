using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternFish : DashingEnemy
{
    // Start is called before the first frame update
    protected override void Awake()
    {
        maxHealth = 500;
        Health = maxHealth;
        pfController = new PathfindingController(transform, PickRandomPoint());
        dashCoolTimer = 0;
        dashAttack = false;
    }

}
