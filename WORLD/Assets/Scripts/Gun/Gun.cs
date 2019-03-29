using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private ParticleSystem muzzleFlash;

    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private float range = 100;

    [SerializeField]
    private GameObject impactEffect;

    [SerializeField]
    private GameObject gunSprite;
    [SerializeField]
    private GameObject gunModel;

    [SerializeField]
    private AudioSource hitsound;

    public void Shoot()
    {
        RaycastHit hit;
        muzzleFlash.Play();

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            TargetMaterialImpact target = hit.transform.GetComponent<TargetMaterialImpact>();
            if (target != null)
            {
                target.TakeDamage(damage);
                hitsound.Play();
            }

            Target Btarget = hit.transform.GetComponent<Target>();
            if (Btarget != null)
            {
                Btarget.TakeDamage(damage);
                hitsound.Play();
            }

            BossTarget Ctarget = hit.transform.GetComponent<BossTarget>();
            if (Ctarget != null)
            {
                Ctarget.TakeDamage(damage);
                hitsound.Play();
            }

            GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2);
        }
    }

    public void OnPickup(Transform parentTransform)
    {
        //Parent the gun to the camera and set in the right position
        transform.SetParent(parentTransform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        gunSprite.SetActive(true);
        gunModel.SetActive(false);
    }
}