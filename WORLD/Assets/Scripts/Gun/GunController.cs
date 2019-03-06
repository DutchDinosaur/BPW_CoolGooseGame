using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    private Transform gunPosition;
    [SerializeField]
    private InputManager Input;

    private Gun currentGun = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Shoot if you have a gun in hand
        if (currentGun != null)
        {
            if (Input.ShootButton)
            {
                currentGun.Shoot();
            }
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        //Pick up the gun
        Gun gun = col.gameObject.GetComponent<Gun>();
        if (gun != null)
        {
            currentGun = gun;
            currentGun.OnPickup(gunPosition);
        }
    }
}