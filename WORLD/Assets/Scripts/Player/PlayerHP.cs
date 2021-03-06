﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int HP = 5;

    public int maxHP = 10;

    public Text HPText;

    public int enemyBulletDamage = 1;

    [SerializeField]
    private AudioSource hppick;

    [SerializeField]
    private AudioSource damage;

    //private GameObject 

    private void FixedUpdate()
    {
        HPText.text = "HP : " + HP.ToString() + "/10";
    }

    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Bullet_Enemy")
        {
            takeDamagePlayer(enemyBulletDamage);
            Destroy(Collision.gameObject);
            damage.Play();
        }

        if (Collision.gameObject.tag == "HEAL")
        {
            if (HP <= maxHP)
            {
                HP += 2;
                Destroy(Collision.gameObject);
                hppick.Play();
            }
        }

        if (Collision.gameObject.tag == "HEALFULL")
        {
            if (HP <= maxHP-2)
            {
                HP = maxHP;
                Destroy(Collision.gameObject);
                hppick.Play();
            }
        }
    }

    public void takeDamagePlayer(int amount)
    {
        HP -= amount;

        if (HP <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
