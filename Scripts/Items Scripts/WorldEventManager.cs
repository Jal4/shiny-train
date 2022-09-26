using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEventManager : MonoBehaviour
{
    // Fog Wall
     UIBossHealth bossHealth;
     enemyBossManager boss;

    public bool bossFightIsActive;
    public bool bossHasBeenAwakened;
    public bool bossHasBeenDefeated;

    private void Awake(){
        bossHealth = FindObjectOfType<UIBossHealth>();
    }

    public void ActivateBossFight(){
        bossFightIsActive = true;
        bossHasBeenAwakened = true;
        bossHealth.SetUIHealthBarToActive();
        //fog wall stuff
    }

    public void BossHasBeenDefeated(){
        bossHasBeenDefeated = true;
        bossFightIsActive = false;
    }
}
