using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    private bool collect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !collect)
        {

            PlayerController.instance.activeGun.GetAmmo();

            Destroy(gameObject);

            collect = true;
        }
    }
}
