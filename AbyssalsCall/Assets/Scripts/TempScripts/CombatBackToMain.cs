using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatBackToMain : MonoBehaviour
{
    private List<GameObject> enemies = new List<GameObject>();
    //private bool hasEnemies;
    private GameObject sub;
    void Start()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemies.Add(enemy);
        }

        sub = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //hasEnemies = false;
        foreach (GameObject enemy in enemies)
        {
            if(enemy != null)
            {
                //hasEnemies = true;
                return;
            }
            // else
            // {
            //     //hasEnemies = false;
            //     break;
            // }
        }

        GameSceneManager.Instance.LoadScene("MapDisplayScene");

        // if (hasEnemies)
        // {
        //     Destroy(sub);
        //     //GameSceneManager.Instance.LoadScene("MapDisplayScene");
        // }
    }
}
