using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawn : MonoBehaviour
{
    public GameObject weapon;
    private bool isWeaponActive;
    private void Start()
    {
      
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            weapon.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            weapon.SetActive(false);
        }
        
    } 
   
}

