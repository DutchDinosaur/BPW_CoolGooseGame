using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTarget : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private GameObject[] objectToDestroy;
    [SerializeField]
    private GameObject deathEffect;

    public bool isActive = false;


    public void TakeDamage(int amount)
    {
        if (isActive)
        {
            health -= amount;

            if (health <= 0)
            {
                Die();
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
