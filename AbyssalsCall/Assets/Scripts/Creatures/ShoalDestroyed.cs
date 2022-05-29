using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoalDestroyed : MonoBehaviour
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
        fishUnit destroyed = GetComponent<fishUnit>();
        destroyed.OnDestroyed += ShowExplosion;
    }

    private void ShowExplosion(object sender, fishUnit.OnDestroyedEventArgs e)
    {
        Instantiate(dieEffect, e.pos, Quaternion.identity);

        for(int i = 0; i < AbyssalCrystalDropped; i++)
        {
            Instantiate(AbbysalCrystal, e.pos, Quaternion.Euler(new Vector3(0, 0, Random.Range(0.0f, 360.0f))));
        }
        

        fishUnit destroyed = GetComponent<fishUnit>();
         destroyed.OnDestroyed -= ShowExplosion;
    }
}
