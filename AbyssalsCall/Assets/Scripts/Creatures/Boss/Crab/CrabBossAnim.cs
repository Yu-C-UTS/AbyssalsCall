using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class CrabBossAnim : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idle, walk, swim, defend, die, hit, jumpUp, land, lightAttackFront, lightAttackBack, heavyAttack, attackRam, shootWarmUp, shootFire, vortexWarmUp, vortexFire;

    private Spine.AnimationState animationState;
    private Skeleton skeleton;

    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        if (skeletonAnimation == null)
        {
            return;
        }

        skeleton = skeletonAnimation.Skeleton;
        animationState = skeletonAnimation.AnimationState;

        // inital animation is idle
        //skeletonAnimation.state.AddAnimation(0,shootWarmUp,false,0);
        AddAnimation(idle, true);

        // listen for Spine events
        animationState.Event += OnEvent;
    }

    // user defined events
    public void OnEvent(Spine.TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "loop")
        {
            Debug.Log("loop point");
        }
        if (e.Data.Name == "attack hit")
        {
            Debug.Log("attack hit");
        }
    }

    ///Called when a bullet hits the crab
	private void OnTirggerEnter2D(Collider2D collider)
    {
        Debug.Log("trigger");
        if (collider.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("hit!");
            AddAnimation(hit, false);
        }
    }

    private void OnMouseDown()
    {
        AddAnimation(hit, false);
    }

    /// Supporting method to mix between Spine animations
	public void AddAnimation(AnimationReferenceAsset ani, bool loop)
    {

        int trackNum = 0;
        // mix the hit animation over the others by placing it on track 1
        if (ani.Animation.Name == "hit") trackNum = 1;

        Spine.TrackEntry animationEntry = skeletonAnimation.state.AddAnimation(trackNum, ani, loop, 0);
        // add any chained animations
        Debug.Log("name: " + ani.Animation.Name + " track: " + trackNum);
        switch (ani.Animation.Name)
        {
            case "shoot warmup":
                animationEntry.Complete += shootWarmUp_Complete;
                break;
            case "shoot fire":
                animationEntry.Complete += shootFire_Complete;
                break;
            case "vortex warmup":
                animationEntry.Complete += vortexWarmUp_Complete;
                break;
            case "vortex fire":
                animationEntry.Complete += vortexFire_Complete;
                break;
        }
    }

    public void SetAnimation(AnimationReferenceAsset ani, bool loop)
    {
        int trackNum = 0;
        Spine.TrackEntry animationEntry = skeletonAnimation.state.SetAnimation(trackNum, ani, loop);
    }

    /// Performs certain actions after the animations is complete
	private void shootWarmUp_Complete(Spine.TrackEntry trackEntry)
    {
        AddAnimation(shootFire, false);
    }
    private void shootFire_Complete(Spine.TrackEntry trackEntry)
    {
        AddAnimation(idle, true);
    }
    private void vortexWarmUp_Complete(Spine.TrackEntry trackEntry)
    {
        AddAnimation(vortexFire, false);
    }
    private void vortexFire_Complete(Spine.TrackEntry trackEntry)
    {
        AddAnimation(idle, true);
    }

}
