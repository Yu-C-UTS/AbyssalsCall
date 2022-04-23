using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndrewTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTirggerEnter2D(Collider2D collider)
    {
        Debug.Log("triggerEnter");
		if (collider.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("bullet hit!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
