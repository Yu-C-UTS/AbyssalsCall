using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishShoal : MonoBehaviour
{
    [SerializeField]
    private GameObject unitPrefab;
    [SerializeField]
    private int numUnits = 10;
    [SerializeField]
    private Vector3 range = new Vector3(5, 5, 0);
    [SerializeField]
    private float movingRadius = 5;
    private Vector3 shoalSpawnPoint;
    public Vector3 GoalPos { get; set; }

    [SerializeField]
    [Range(0,100)]
    private float changingRate;

    public GameObject[] units;

    public float neighbourDistance = 1f;
    public float maxForce = 0.5f;
    public float maxVelocity = 2.0f;

    public bool seekGoal;
    public bool obedient;
    public bool willful;

    void Start()
    {
        shoalSpawnPoint = transform.position;
        GoalPos = shoalSpawnPoint;
        units = new GameObject[numUnits];
        for(int i = 0; i < numUnits; i++)
        {
            Vector3 unitSpawnPos = new Vector3(Random.Range(-range.x, range.x),
                                               Random.Range(-range.y, range.y),
                                               0);
            units[i] = Instantiate(unitPrefab, this.transform.position + unitSpawnPos, Quaternion.identity) as GameObject;
            units[i].GetComponent<fishUnit>().manager = this.gameObject;
        }

        seekGoal = true;
        obedient = true;
        willful = true;
    }

    void Update()
    {
        if (Random.Range(0, 1/changingRate * 1000) <= 1)
        {
            GoalPos = PickRandomPoint();
        }

        /*if (Random.Range(0, 1 / changingRate * 1000) <= 1)
        {
            seekGoal = !seekGoal;
        }*/

        if (Random.Range(0, 1 / changingRate * 1000) <= 1)
        {
            obedient = !obedient;
        }
    }

    private Vector3 PickRandomPoint()
    {
        Vector3 point = Random.insideUnitCircle * movingRadius;
        point += shoalSpawnPoint;
        return point;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(this.transform.position, range * 2);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, 0.2f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GoalPos, 0.2f);
    }
}
