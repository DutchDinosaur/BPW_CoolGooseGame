using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private float speed;

    //public Pool pool;


    //void Start()
    //{
    //    Invoke("ReturnBullet", 1);
    //}

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    //void ReturnBullet()
    //{
    //    pool.ReturnBullet(gameObject);
    //}
}
