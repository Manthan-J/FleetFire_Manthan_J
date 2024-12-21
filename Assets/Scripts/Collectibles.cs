using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
   private WeaponControls weaponcontrol;
   private HealthSystem healthSystem;
   void OnTriggerEnter(Collider other)
   {
    weaponcontrol=GameObject.Find("Pistol").GetComponent<WeaponControls>();
    healthSystem=GameObject.Find("Player").GetComponent<HealthSystem>();
    if(other.tag=="CollectibleAmmo")
    {
        weaponcontrol.ClipCount++;
        Destroy(other.gameObject);
    }
    if(other.tag=="CollectibleHealth")
    {
    //     if(healthSystem.health>80 && healthSystem.health<100)
    //     healthSystem.health =100;
    //     else if(healthSystem.health>0 && healthSystem.health<80)
    //     {
            healthSystem.health+=20;
        // }
        Destroy(other.gameObject);
    }
    // Debug.Log(other.gameObject);
   }
}
