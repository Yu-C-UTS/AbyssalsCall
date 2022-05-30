using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBehaviour : MonoBehaviour
{
    private Vector2 currentTargetPos;
    private Vector2 currentDirect;
    private Transform target;
    public float speed = 15;
    private float distanceToTarget;
    private bool move = true;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(UpdateTarget());
        currentDirect = directionTo(currentTargetPos);
        StartCoroutine(UpdatePath());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, directionTo(currentTargetPos), speed * Time.deltaTime);
        transform.Translate(currentDirect * speed * Time.deltaTime);
    }

    private IEnumerator UpdateTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.7f);
            currentTargetPos = target.position;
        }
    }

    private IEnumerator UpdatePath()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            currentDirect = directionTo(currentTargetPos);
        }
    }

    private Vector2 directionTo(Vector3 target)
    {
        Vector2 direction = target - transform.position;
        return - direction.normalized;
    }
}
