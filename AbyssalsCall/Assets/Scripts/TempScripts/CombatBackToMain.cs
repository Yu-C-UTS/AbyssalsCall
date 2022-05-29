using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatBackToMain : MonoBehaviour
{
    private List<GameObject> enemies = new List<GameObject>();
    private bool empty;
    void Start()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemies.Add(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        empty = false;
        foreach (GameObject enemy in enemies)
        {
            if(enemy == null)
            {
                empty = true;
            }
            else
            {
                empty = false;
                break;
            }
        }

        if (empty)
        {
            GameSceneManager.Instance.LoadScene("MapDisplayScene");
        }
    }
}
