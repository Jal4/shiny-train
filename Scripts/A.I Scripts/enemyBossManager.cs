using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBossManager : MonoBehaviour
{
    UIBossHealth bossHealthBar;
    EnemyStats enemyStats;
    public string bossName;

    public void Awake(){
        bossHealthBar = FindObjectOfType<UIBossHealth>();
        enemyStats = GetComponent<EnemyStats>();
    }

    private void Start(){
        bossHealthBar.SetBossName(bossName);
        bossHealthBar.SetBossMaxHealth(enemyStats.maxHealth);
    }

    public void UpdateBossHealth(int currentHealth) {
        bossHealthBar.SetBossCurrentHealth(currentHealth);
    }
    //Handle Switching phase
    //handle attack pattern change
}
