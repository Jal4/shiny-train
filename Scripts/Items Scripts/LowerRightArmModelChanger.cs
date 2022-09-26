using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerRightArmModelChanger : MonoBehaviour
{
    public List<GameObject> Models;

    private void Awake()
    {
        GetAllModels();
    }

    private void GetAllModels()
    {
        int childrenGameObjects = transform.childCount;

        for (int i = 0; i < childrenGameObjects; i++)
        {
            Models.Add(transform.GetChild(i).gameObject);
        }
    }

    public void UnequipAllModels()
    {
        foreach (GameObject gameObject in Models)
        {
            gameObject.SetActive(false);
        }
    }

    public void EquipModelByName(string ModelName)
    {
        for (int i = 0; i < Models.Count; i++)
        {
            if (Models[i].name == ModelName)
            {
                Models[i].SetActive(true);
            }
        }
    }
}
