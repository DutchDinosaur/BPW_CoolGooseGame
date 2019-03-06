using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletShooter : MonoBehaviour
{

    public bool IsRotating;
    [SerializeField]
    private float rotateSpeed;

    [Space(15)]
    public bool IsWavyRotating;
    [SerializeField]
    private float wavyRotateSpeed;
    [SerializeField]
    private Vector2 wavyRotateMinNMax;
    private float wavyRotation;
    private bool wavyRotateUp;

    [Space(15)]
    [SerializeField]
    private int shootCountdownTime;
    private int shootCountdown;

    [Space(15)]
    [SerializeField]
    private bool IsWavyShooting;
    [SerializeField]
    private float wavyShootSpeed;
    [SerializeField]
    private Vector2 wavyShootMinNMax;
    private bool wavyShootUp;

    [Space(15)]
    [SerializeField]
    private Transform bulletParent;
    [SerializeField]
    private Transform poolTransform;
    [SerializeField]
    private Pool pool;

    private int bulletsShot = 0;

    void FixedUpdate()
    {
        if (IsRotating) { Rotate(); }
        if (IsWavyRotating) { wavyRotate(); }
        if (IsWavyShooting) { wavyShoot(); }

        if (shootCountdown >= shootCountdownTime)
        {
            Shoot();
            shootCountdown = 0;
        }
        shootCountdown += 1;
    }

    void Shoot()
    {
        if (poolTransform.childCount <= 1)
        {
            GameObject bulletToDespawn = bulletParent.GetChild(0).gameObject; ;
            bulletToDespawn.transform.SetParent(poolTransform);
            bulletToDespawn.SetActive(false);
        }
        GameObject bullet = pool.GetBullet(bulletParent);
        bullet.transform.rotation = transform.rotation;
        bullet.transform.position = transform.position;
    }

    void Rotate()
    {
        transform.Rotate(0, rotateSpeed, 0);
    }

    void wavyRotate()
    {
        if (wavyRotation < wavyRotateMinNMax.x)
        {
            wavyRotateUp = true;
        } else if (wavyRotation > wavyRotateMinNMax.y)
        {
            wavyRotateUp = false;
        }

        if (wavyRotateUp)
        {
            wavyRotation += wavyRotateSpeed;
        }
        else
        {
            wavyRotation -= wavyRotateSpeed;
        }
        

        transform.Rotate(0, wavyRotation, 0);
    }

    void wavyShoot()
    {
        if (shootCountdownTime < wavyShootMinNMax.x)
        {
            wavyShootUp = true;
        }
        else if (shootCountdownTime > wavyShootMinNMax.y)
        {
            wavyShootUp = false;
        }

        if (wavyShootUp)
        {
            shootCountdownTime += (int)wavyShootSpeed;
        }
        else
        {
            shootCountdownTime -= (int)wavyShootSpeed;
        }
    }
}
