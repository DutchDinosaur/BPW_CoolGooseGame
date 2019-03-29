using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMaterialImpact : MonoBehaviour
{
    public int health;
    [SerializeField]
    private GameObject deathEffect;
    [SerializeField]
    private GameObject[] objectToDestroy;
    [SerializeField]
    private SkinnedMeshRenderer renderer;

    private Material normalMat;
    [SerializeField]
    private Material damageMat;

    private float timeStamp;

    private void Start()
    {
        normalMat = renderer.material;
    }

    private void FixedUpdate()
    {
        if (timeStamp + 2 > Time.time)
        {
            renderer.material = normalMat;
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        renderer.material = damageMat;

        timeStamp = Time.time;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        GameObject death = GameObject.Instantiate(deathEffect);
        death.transform.position = transform.position;
        Destroy(death, 2);

        for (int i = 0; i < objectToDestroy.Length; i++)
        {
            Destroy(objectToDestroy[i]);
        }
    }
}
