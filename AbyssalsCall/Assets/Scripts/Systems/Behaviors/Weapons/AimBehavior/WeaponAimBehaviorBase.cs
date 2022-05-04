using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponAimBehaviorBase : WeaponBehaviorBase
{
    public Sprite CrosshairSprite;
    protected Transform crosshairTransform;

    public abstract Vector2 GetAimDirection();

    public abstract void moveCrosshair(Vector2 moveDelta);
    public abstract void AimUpdate();

    public override void InitilizeBehavior(Transform WeaponTransform, GeneralWeaponSystem parentWeaponSystem)
    {
        base.InitilizeBehavior(WeaponTransform, parentWeaponSystem);

        crosshairTransform = new GameObject("Crosshair").transform;
        crosshairTransform.SetParent(WeaponTransform);
        SpriteRenderer crosshairSpriteRenderer = crosshairTransform.gameObject.AddComponent<SpriteRenderer>();    
        crosshairSpriteRenderer.sprite = CrosshairSprite;
        crosshairSpriteRenderer.sortingLayerName = "UI";
    }

    public virtual Transform GetTargetTransform()
    {
        return crosshairTransform;
    }
}
