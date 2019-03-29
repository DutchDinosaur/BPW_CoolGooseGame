using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletShooter : MonoBehaviour
{
    [Header("Shoot")]
    public bool IsShooting;

    [Header("Rotate")]
    public bool IsRotating;
    [SerializeField]
    private float rotateSpeed;

    [Header("Wavy Rotate")]
    public bool IsWavyRotating;
    [SerializeField]
    private float wavyRotateSpeed;
    [SerializeField]
    private Vector2 wavyRotateMinNMax;
    private float wavyRotation;
    private bool wavyRotateUp;

    [Header("Shoot Countdown")]
    [SerializeField]
    private int shootCountdownTime;
    private int shootCountdown;

    [Header("Wavy Shoot")]
    public bool IsWavyShooting;
    [SerializeField]
    private float wavyShootSpeed;
    [SerializeField]
    private Vector2 wavyShootMinNMax;
    private bool wavyShootUp;

    [Header("Ring Shoot")]
    public bool IsRingShooting;
    [SerializeField]
    private int ringShootCountdownTime;
    [SerializeField]
    private int ringShootAmount;
    private int ringShootCountdown;

    [Header("Other")]
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
        if (IsRingShooting) { ringShoot(); }

        if (shootCountdown >= shootCountdownTime && IsShooting)
        {
            Shoot();
            shootCountdown = 0;
        }
        shootCountdown += 1;
    }

    void ringShoot()
    {
        if (ringShootCountdown >= ringShootCountdownTime)
        {
            for (int i = 0; i < ringShootAmount; i++)
            {
                transform.Rotate(0, 360/ ringShootAmount, 0);
                Shoot();
            }
            ringShootCountdown = 0;
        }
        ringShootCountdown += 1;
    }

    void Shoot()
    {
        if (bulletParent.childCount == 0 && poolTransform.childCount == 1)
        {
            return;
        }

        if (poolTransform.childCount == 1)
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
