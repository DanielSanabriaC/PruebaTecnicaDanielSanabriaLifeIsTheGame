using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bullet;

    public bool canAutoFire;

    public float fireRate;
    [HideInInspector]
    public float fireCounter;

    public int currentAmo,pickupAmout;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fireCounter > 0)
        {
            fireCounter -= Time.deltaTime;
        }
    }


    public void GetAmmo()
    {
        currentAmo += pickupAmout;

        UIController.instance.ammoText.text = "Ammo: " + currentAmo;
    }


}
