using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{

    public GameObject crosshairs;
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject firePoint;
    public float bulletSpeed = 60.0f;
    //private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Location of mouse in world space
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Place crosshair at location of mouse
        crosshairs.transform.position = new Vector2(target.x,target.y);

        //Rotate the sub-marine towards crosshair
        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if(Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference/distance;
            direction.Normalize();
            Shoot(direction, rotationZ);
        }
    }

    void Shoot(Vector2 direction, float rotationZ)
    {
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.transform.position = firePoint.transform.position;
        bullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
