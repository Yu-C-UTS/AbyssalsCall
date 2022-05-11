using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBossBehaviour : MonoBehaviour
{

    [SerializeField]
    private CrabBoss anim;

    [SerializeField]
    private Transform myCenter;

    private float MeleeAttackTime = 3;
    private float MeleeAttackTimer;
    private int MeleeAttackCount;

    private float PullDownTime = 5;
    private float PullDownTimer;

    private CrabBossState myState;

    [SerializeField]
    private Transform watercurrentMaker;
    [SerializeField]
    private Transform watercurrent;

    void Start()
    {
        myState = gameObject.GetComponent<CrabBossState>();
        MeleeAttackTimer = MeleeAttackTime;
        PullDownTimer = PullDownTime;
    }

    void Update()
    {

        if (myState.getTarget())
        {
            if(VerticalDistanceTo(myState.getTarget()) >= 10)
            {
                PullDown(myState.getTarget());
            }
        }

        if (distanceTo(myState.getTarget()) <= 10)
        {
            if (AttackCountDown() == 0)
            {
                if (MeleeAttackCount != 0 && MeleeAttackCount % 3 == 1)
                {
                    StartCoroutine(heavyAttack());
                }
                else
                {
                    StartCoroutine(lightAttack());
                }
            }
        }
    }

    private float AttackCountDown()
    {
        if(MeleeAttackTimer <= 0)
        {
            MeleeAttackTimer = MeleeAttackTime;
            return 0;
        }
        else
        {
            MeleeAttackTimer -= Time.deltaTime;
            return MeleeAttackTimer;
        }
    }

    protected float distanceTo(Transform target)
    {
        return Vector2.Distance(target.position, myCenter.position);
    }

    protected float VerticalDistanceTo(Transform target)
    {
        return Mathf.Abs(target.position.y - myCenter.position.y);
    }

    private void PullDown(Transform target)
    {
        Vector2 launchPos = target.position;
        launchPos.y = watercurrentMaker.position.y;
        Instantiate(watercurrent, launchPos, Quaternion.identity);
    }

    private Vector2 directionTo(Transform target)
    {
        Vector2 direction = target.position - myCenter.position;
        return direction.normalized;
    }

    private IEnumerator lightAttack()
    {
        anim.SetAnimation(anim.lightAttackFront, true);
        myState.state = CrabBossState.State.Attacking;
        MeleeAttackCount += 1;
        Debug.Log("Light Attack");
        yield return new WaitForSeconds(0.5f);
        myState.state = CrabBossState.State.Active;
    }

    private IEnumerator heavyAttack()
    {
        anim.SetAnimation(anim.heavyAttack, false);
        myState.state = CrabBossState.State.Attacking;
        MeleeAttackCount += 1;
        Debug.Log("Heavey Attack");
        yield return new WaitForSeconds(0.5f);
        myState.state = CrabBossState.State.Active;
    }
}
