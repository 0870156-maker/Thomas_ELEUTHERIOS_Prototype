using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : StateMachineBehaviour
{
    BossWeapon weapon;
    bool hasAttacked;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        weapon = animator.GetComponent<BossWeapon>();
        hasAttacked = false;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!hasAttacked && stateInfo.normalizedTime >= 0.5f)
        {
            weapon.Attack();
            hasAttacked = true;
        }
    } 
}
