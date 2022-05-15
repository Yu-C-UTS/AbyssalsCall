using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class LanternBoss : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
	public AnimationReferenceAsset staionaryIdle, swimIdle, swimSlow, hit, swimFast, heavyAttack, lightAttack, specialAttack;

    private Spine.AnimationState animationState;
    private Skeleton skeleton;

	void Start()
	{
 		skeletonAnimation = GetComponent<SkeletonAnimation>();
		if(skeletonAnimation == null)
        {
			return; 
        }
       
        skeleton = skeletonAnimation.Skeleton;
        animationState = skeletonAnimation.AnimationState;

        // listen for Spine events
        animationState.Event += OnEvent;
	}

    // user defined events
    public void OnEvent(Spine.TrackEntry trackEntry, Spine.Event e){
        if(e.Data.Name == "loop")
        {
            //Debug.Log("loop point");
        }
        if(e.Data.Name == "attack hit")
        {
            //Debug.Log("attack hit");
        }
    }

   private void OnMouseDown() {
        AddAnimation(hit, false);
    }

    /// Supporting method to mix between Spine animations
	public void AddAnimation(AnimationReferenceAsset ani, bool loop)
    {
        int trackNum = 0;
        // mix the attack animaitons ver the swim
        if (ani.Animation.Name == "heavy attack" || ani.Animation.Name == "light attack" || ani.Animation.Name == "special attack" || ani.Animation.Name == "hit") {
            trackNum = 1;
        }

        Spine.TrackEntry animationEntry = skeletonAnimation.state.SetAnimation(trackNum, ani, loop);
      /* if (ani.Animation.Name == "heavy attack" || ani.Animation.Name == "light attack" || ani.Animation.Name == "special attack") {
            animationEntry.Complete += attack_Complete;
        }*/
    }
}
