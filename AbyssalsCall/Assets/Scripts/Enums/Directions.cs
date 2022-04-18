using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Directions
{
    public enum EDirection
    { forward, backward, upward, downward}

    public static Vector3 DirectionToV3(EDirection direction)
    {
        switch(direction)
        {
            case EDirection.forward:
            return Vector3.right;

            case EDirection.backward:
            return Vector3.left;

            case EDirection.upward:
            return Vector3.up;

            case EDirection.downward:
            return Vector3.down;

            default:
            Debug.LogWarning("Unknow Direction, returning forward");
            return Vector3.right;
        }
    }

    public static Vector3 RelativeDirectionToV3(EDirection direction, Transform relativeTransform)
    {
        switch(direction)
        {
            case EDirection.forward:
            return relativeTransform.TransformDirection(relativeTransform.right);

            case EDirection.backward:
            return relativeTransform.TransformDirection(-relativeTransform.right);

            case EDirection.upward:
            return relativeTransform.TransformDirection(relativeTransform.up);

            case EDirection.downward:
            return relativeTransform.TransformDirection(-relativeTransform.up);

            default:
            Debug.LogWarning("Unknow Direction, returning forward");
            return relativeTransform.TransformDirection(relativeTransform.right);
        }
    }
}
