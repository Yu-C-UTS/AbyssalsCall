using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subgentest : MonoBehaviour
{   private void Start() 
    {
        Debug.LogWarning("subgentest class can be removed, use 'PlayerSubmarineSpawner.Instance.SpawnNewSubmarine()' instead to spawn new player submarine into scene.");
        PlayerSubmarine instantiatedSub = PlayerSubmarineSpawner.Instance.SpawnNewSubmarine();

        CameraManager.Instance.MainFocusTransform = instantiatedSub.transform;
    }
}
