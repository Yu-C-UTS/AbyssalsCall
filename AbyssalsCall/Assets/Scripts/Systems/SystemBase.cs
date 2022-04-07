using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemBase : MonoBehaviour
{
    [SerializeField]
    private string systemName = "New System";

    [SerializeField]
    private bool isUnique = false;

    [SerializeField]
    private bool isRemovable = true;
}
