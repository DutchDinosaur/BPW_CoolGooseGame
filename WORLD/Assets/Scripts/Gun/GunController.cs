﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    private Transform gunPosition;
    [SerializeField]
    private InputManager Input;

    [SerializeField]
    private int shootSpeed;

    private int shootCounter;

    private Gun currentGun = null;

    [SerializeField]
    private AudioSource shooting;

    void FixedUpdate()
    {
        if (currentGun != null)
        {
            if (shootCounter < shootSpeed)
            {
                shootCounter += 1;
            }

            if (Input.ShootButton && shootCounter >= shootSpeed)
            {
                currentGun.Shoot();
                shootCounter = 0;
            }

            if (Input.ShootButton)
            {
                shooting.enabled = true;
            } else { shooting.enabled = false; }
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        Gun gun = col.gameObject.GetComponent<Gun>();
        if (gun != null)
        {
            currentGun = gun;
            currentGun.OnPickup(gunPosition);
        }
    }
}