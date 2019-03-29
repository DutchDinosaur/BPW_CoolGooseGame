using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[SerializeField]
    //private BoxCollider enemyDetectRange;
    [SerializeField]
    private EnemyBulletShooter shooter;
    [SerializeField]
    private EnemyAnim anim;

    public bool isAngry = false;

    void FixedUpdate()
    {
        if (isAngry)
        {
            shooter.IsRingShooting = true;
            shooter.IsShooting = true;
            anim.isActive = true;
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
