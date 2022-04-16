using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObject : MonoBehaviour
{
    public enum AnchorPoint
    { turret, top, bottom, front, back}

    public Transform FirePoint;
    public AnchorPoint PreferedAnchorPoint = AnchorPoint.bottom;
}
