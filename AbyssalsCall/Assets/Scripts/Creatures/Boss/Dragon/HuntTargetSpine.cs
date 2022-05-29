using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class HuntTargetSpine : MonoBehaviour
{

     public SkeletonAnimation skeletonAnimation;
      private Skeleton skeleton;
   public float rotationSpeed;
    private Vector2 direction;

   public GameObject objectToFollow;
    public GameObject objectToLookAt;

    public bool followCursor = false;

    private SpriteRenderer mySpriteRenderer;

    public Material bodyMaterial1;
    public Material bodyMaterial2;

    public GameObject myTail;
    private Material tailMaterial;

    private LineRenderer line;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //mySpriteRenderer = GetComponent<SpriteRenderer>();

        skeletonAnimation = GetComponent<SkeletonAnimation>();
		if(skeletonAnimation == null)
        {
			return; 
        }
       
        skeleton = skeletonAnimation.Skeleton;

        tailMaterial = myTail.GetComponent<Renderer>().material;
        line = myTail.GetComponent<LineRenderer>();

        Debug.Log(tailMaterial);
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
            skeleton.ScaleY = -1;
            line.material = bodyMaterial2;
        }
        else
        {
            skeleton.ScaleY = 1;
            line.material = bodyMaterial1;
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
