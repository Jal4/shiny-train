using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack01State : State
{
    public CombatStanceState combatStanceState;
    public PursuitState pursuitState;
    public RotateTowardsTarget rotateTowardsTargetState;
    public EnemyAttackAction currentAttack;

    bool willDoComboNextAttack = false;
    public bool hasPerformedAttack = false;

    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);
        RotateTowardsTargetWhilstAttacking(enemyManager);

        if (distanceFromTarget > enemyManager.MaximumAggroRadius)
        {
            return pursuitState;
        }

        if(willDoComboNextAttack && enemyManager.canDoCombo)
        {
            AttackTargetWithCombo(enemyAnimatorManager, enemyManager);
        }

        if (!hasPerformedAttack)
        {
            AttackTarget(enemyAnimatorManager, enemyManager);
            RollForComboChance(enemyManager);
        }

        if (willDoComboNextAttack && hasPerformedAttack)
        {
            return this;
        }

        return rotateTowardsTargetState;
    }

    private void AttackTarget(EnemyAnimatorManager enemyAnimatorManager, EnemyManager enemyManager)
    {
        enemyAnimatorManager.PlayTargetAnimation(currentAttack.actionAnimation, true);
        enemyManager.currentRecoveryTime = currentAttack.recoveryTime;
        hasPerformedAttack = true;
    }

    private void AttackTargetWithCombo(EnemyAnimatorManager enemyAnimatorManager, EnemyManager enemyManager)
    {
        willDoComboNextAttack = false;
        enemyAnimatorManager.PlayTargetAnimation(currentAttack.actionAnimation, true);
        enemyManager.currentRecoveryTime = currentAttack.recoveryTime;
        currentAttack = null;
    }
    
    private void RotateTowardsTargetWhilstAttacking(EnemyManager enemyManager)
    {
        //manual 
        if (enemyManager.canRotate && enemyManager.isInteracting)
        {
            Vector3 direction = enemyManager.currentTarget.transform.position - enemyManager.transform.position;
            direction.y = 0;
            direction.Normalize();

            if (direction == Vector3.zero)
            {
                direction = transform.forward;
            }

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            enemyManager.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, enemyManager.rotationSpeed / Time.deltaTime);
        }
    }

    private void RollForComboChance(EnemyManager enemyManager)
    {
        float comboChance = Random.Range(0, 100);

        if(enemyManager.allowAIToPerformCombo && comboChance <= enemyManager.comboLikelyhood)
        {
            if(currentAttack != null)
            {
                willDoComboNextAttack = true;
                currentAttack = currentAttack.comboAction;
            }
            else
            {
                willDoComboNextAttack = false;
                currentAttack = null;
            }
        }
    }
}
