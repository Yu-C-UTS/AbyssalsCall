using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestoryed : MonoBehaviour
{

    [SerializeField]
    private GameObject dieEffect;

     [SerializeField]
    private GameObject AbbysalCrystal;

    [SerializeField]
    private int AbyssalCrystalDropped = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        BasicEnemyController destroyed = GetComponent<BasicEnemyController>();
        destroyed.OnDestroyed += ShowExplosion;
    }

    private void ShowExplosion(object sender, BasicEnemyController.OnDestroyedEventArgs e)
    {
        Instantiate(dieEffect, e.pos, Quaternion.identity);

        for(int i = 0; i < AbyssalCrystalDropped; i++)
        {
            Vector3 dropPoint = new Vector3(e.pos.x + Random.Range(-0.2f,0.2f), e.pos.y + Random.Range(-0.5f,0.5f));
            GameObject crystalInstance = Instantiate(AbbysalCrystal, dropPoint, Quaternion.Euler(new Vector3(0, 0, Random.Range(0.0f, 360.0f))));
            Rigidbody2D rigidBody = crystalInstance.GetComponent<Rigidbody2D>();
            rigidBody.AddForce(new Vector2(Random.Range(-10.0f,10.0f), Random.Range(-35.0f,-20.0f)));
            rigidBody.AddTorque(Random.Range(-20.0f,20.0f));
            float myScale = Random.Range(0.1f, 0.3f);
            crystalInstance.transform.localScale = new Vector3(myScale,myScale,myScale);
        }
        

        BasicEnemyController destroyed = GetComponent<BasicEnemyController>();
         destroyed.OnDestroyed -= ShowExplosion;
    }
}
