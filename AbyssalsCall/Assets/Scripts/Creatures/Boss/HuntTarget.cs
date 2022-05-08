using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntTarget : MonoBehaviour
{
   public float rotationSpeed;
    private Vector2 direction;

   public GameObject objectToFollow;
    public GameObject objectToLookAt;

    public bool followCursor = false;

    private SpriteRenderer mySpriteRenderer;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // rotaion towards
        if (followCursor)
        {
            //follow the cursor
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }
        else
        {
            direction = objectToFollow.transform.position - transform.position;
        }
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        if (direction.x < 0)
        {
            //mySpriteRenderer.flipY = true;
            transform.localScale = new Vector3(1, -1, 1);
        }

        // move towards
        Vector2 objectPos;
        if (followCursor)
        {
            objectPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           
        }
        else
        {
            objectPos = objectToFollow.transform.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, objectPos, moveSpeed * Time.deltaTime);

    }
}
