using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    [SerializeField]
    private float AnimSpeed;
    [SerializeField]
    private Vector2 AnimConstraints;

    private bool IsMovingUp = true;

    public bool isActive = false;

    void FixedUpdate()
    {
        if (isActive) { moove(); }
    }

    void moove()
    {
        if (transform.position.y >= AnimConstraints.y)
        {
            IsMovingUp = false;
        }
        if (transform.position.y <= AnimConstraints.x)
        {
            IsMovingUp = true;
        }


        if (IsMovingUp)
        {
            transform.Translate(0, AnimSpeed, 0);
        }
        else
        {
            transform.Translate(0, -AnimSpeed, 0);
        }
    }
}
