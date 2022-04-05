using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BasicEnemyController : MonoBehaviour
{
    private Seeker seeker;
    private Rigidbody2D rb;
    private PathfindingController pfController;
    public Transform target;

    private void Awake()
    {
        pfController = new PathfindingController(transform, target);
    }

    private void Start()
    {
        InvokeRepeating("UpdateAIPath", 0f, .5f);
    }
    private void UpdateAIPath()
    {
        pfController.UpdatePath();
    }

    private void FixedUpdate()
    {
        pfController.UpdateMovement();
    }
}
