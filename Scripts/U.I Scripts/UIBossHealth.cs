using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBossHealth : MonoBehaviour
{
    Slider slider;
    public Text bossName;

    public void Awake() {
        
        slider = GetComponentInChildren<Slider>();
        bossName = GetComponentInChildren<Text>();
    }

    public void Start() {
        
        SetUiHealthBarToInactive();
    }
    public void SetBossName(string name) {
        
        bossName.text  = name;
    }

    public void SetUIHealthBarToActive(){
        
        slider.gameObject.SetActive(true);
    }

    public void SetUiHealthBarToInactive(){
        
        slider.gameObject.SetActive(false);
    }

    public void SetBossMaxHealth(int maxHealth) {
        
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void SetBossCurrentHealth(int currentHealth) {
        
        slider.value = currentHealth;
    }
}
