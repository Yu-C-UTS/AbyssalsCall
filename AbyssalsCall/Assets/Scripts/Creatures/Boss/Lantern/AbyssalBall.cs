using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssalBall : MonoBehaviour
{
    public Damage AbyssalBallDamage = new Damage(15);
    public float speed = 2;
    private Vector2 currentTargetPos;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(UpdatePath());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentTargetPos, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerSubmarine>().TakeDamage(AbyssalBallDamage);
        }
        Destroy(gameObject);
    }

    private IEnumerator UpdatePath()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            currentTargetPos = target.position;
        }
    }

}
