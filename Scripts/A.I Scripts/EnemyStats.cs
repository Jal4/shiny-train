using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    EnemyAnimatorManager animator;
    enemyBossManager enemyBossManager;
    
    public int baseHealth = 100;
    public bool isBoss;
    
    public UIEnemyHealthBar enemyhealthBar;

    private void Awake()
    {
        animator = GetComponentInChildren<EnemyAnimatorManager>();
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
        enemyBossManager = GetComponent<enemyBossManager>();
    }

    private void Start()
    {
        if(!isBoss) {
            enemyhealthBar.SetMaxHealth(maxHealth);
        }
    }

    private int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    public void TakeDamageNoAnimation(int damage)
    {
        if(isDead) 
            return;
            
        currentHealth = currentHealth - damage;

        if(!isBoss) {
            
            enemyhealthBar.SetHealth(currentHealth);
        }
        else if (isBoss && enemyBossManager != null) {
            
            enemyBossManager.UpdateBossHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
        }
    }


    public void TakeDamage(int damage, string damageAnimation = "Damage_01")
    {
        if(isDead) 
            return;
        
        currentHealth = currentHealth - damage;

        if(!isBoss) {
            
            enemyhealthBar.SetHealth(currentHealth);
        }
        else if (isBoss && enemyBossManager != null) {
            
            enemyBossManager.UpdateBossHealth(currentHealth);
        }


        animator.PlayTargetAnimation(damageAnimation, true);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            animator.PlayTargetAnimation("Death_01", true);
        }
    }
}
