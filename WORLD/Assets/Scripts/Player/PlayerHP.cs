using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int HP = 5;

    public Text HPText;

    public int enemyBulletDamage = 1;

    private void FixedUpdate()
    {
        HPText.text = "HP : " + HP.ToString();
    }

    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Bullet_Enemy")
        {
            takeDamagePlayer(enemyBulletDamage);
            Destroy(Collision.gameObject);
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
