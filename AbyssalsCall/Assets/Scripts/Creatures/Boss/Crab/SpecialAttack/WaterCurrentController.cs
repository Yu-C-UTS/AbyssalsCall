using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCurrentController : MonoBehaviour
{
    void Start()
    {
        destroyMyself();
    }

    private IEnumerable destroyMyself()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
