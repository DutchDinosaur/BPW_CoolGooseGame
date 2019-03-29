using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossTarget : MonoBehaviour
{
    public int health;
    [SerializeField]
    private GameObject[] objectToDestroy;
    [SerializeField]
    private GameObject deathEffect;


    public bool isActive = false;

    public Text bossHPText;


    public void TakeDamage(int amount)
    {
        if (isActive)
        {
            health -= amount;

            if (health <= 0)
            {
                Die();
                bossHPText.text = "Valentijn Muijers  Destroyer Of Worlds:0 /100";
            }
        }
       
    }

    public void Die()
    {
        GameObject death = GameObject.Instantiate(deathEffect);
        death.transform.position = transform.position;

        for (int i = 0; i < objectToDestroy.Length; i++)
        {
            Destroy(objectToDestroy[i]);
        }
    }
}
