using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    //public static Pool Instance

    [SerializeField]
    private GameObject enemyBulletPrefab;
    public int bulletsToSpawnInPool;

    private void Start()
    {
        //Instance = this;

        for (int i = 0; i < bulletsToSpawnInPool; i++)
        {
            Instantiate(enemyBulletPrefab,transform);
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject bulletToDisble = transform.GetChild(i).gameObject;
            bulletToDisble.SetActive(false);
        }

    }

    public GameObject GetBullet(Transform tr)
    {
        GameObject bullet = gameObject.transform.GetChild(0).gameObject;
        bullet.transform.SetParent(tr);
        bullet.SetActive(true);

        return bullet;
    }

}