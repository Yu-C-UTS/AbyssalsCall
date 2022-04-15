using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemFactory : MonoBehaviour
{
    public static SystemFactory Instance{ get; private set; }

    private void Awake() 
    {
        if(Instance != null)
        {
            Destroy(this);
        }    
        Instance = this;
    }
}
