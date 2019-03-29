﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bOSS : MonoBehaviour
{
    //[SerializeField]
    //private BoxCollider enemyDetectRange;
    [SerializeField]
    private GameObject[] shooters;
    [SerializeField]
    private EnemyAnim anim;

    [SerializeField]
    private BossTarget targetScript;

    [SerializeField]
    private GameObject[] geese;

    public bool isAngry = false;

    [SerializeField]
    private int AttackTime;
    private int counter;

    public int bossHP;
    public Text bossHPText;

    private void Start()
    {
        bossHPText.text = "";
    }

    void FixedUpdate()
    {
        if (isAngry && anim.isActive == false)
        {
            for (int i = 0; i < shooters.Length; i++)
            {
                shooters[i].gameObject.SetActive(true);
            }
            anim.isActive = true;
        }

        counter += 1;
        if (counter >= AttackTime && anim.isActive == true)
        {
            counter = 0;
            if (shooters[3].GetComponent<EnemyBulletShooter>().IsShooting == true)
            {
                shooters[3].GetComponent<EnemyBulletShooter>().IsRingShooting = false;
                shooters[3].GetComponent<EnemyBulletShooter>().IsShooting = false;
            }
            else
            {
                shooters[3].GetComponent<EnemyBulletShooter>().IsRingShooting = true;
                shooters[3].GetComponent<EnemyBulletShooter>().IsShooting = true;
            }
        }

        if (geese[0] == null && geese[1] == null && geese[2] == null)
        {
            shooters[3].GetComponent<EnemyBulletShooter>().IsRingShooting = false;
            shooters[3].GetComponent<EnemyBulletShooter>().IsShooting = true;
            targetScript.isActive = true;
            isAngry = false;
        }

        if (anim.isActive == true)
        {
            bossHP = 0;
            for (int i = 0; i < geese.Length; i++)
            {
                if (geese[i] != null) { bossHP += geese[i].GetComponent<TargetMaterialImpact>().health; }
            }
            bossHP += targetScript.health;
            bossHPText.text = "Valentijn Muijers Destroyer Of Worlds:" + bossHP.ToString() + " /100";
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isAngry = true;
        }
    }
}
