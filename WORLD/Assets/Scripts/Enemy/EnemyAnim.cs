using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    [SerializeField]
    private float AnimSpeed;
    [SerializeField]
    private Vector2 AnimConstraints;
    [SerializeField]
    private Vector2 mooveConstraints;

    private Transform player;

    private bool IsMovingUp = true;

    public bool isActive = false;

    public float speed = 1.5f;

    Vector3 newPosition;

    private void Start()
    {
        newPosition = PositionChange();
        player = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {
        if (isActive) { moove(); transform.LookAt(player); }
    }

    void moove()
    {
        if (transform.localPosition.y >= AnimConstraints.y)
        {
            IsMovingUp = false;
        }
        if (transform.localPosition.y <= AnimConstraints.x)
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


        if ((Vector3.Distance(transform.localPosition, newPosition) - Mathf.Abs(newPosition.y - transform.position.y)) < 1.5f)
            newPosition = PositionChange();

        transform.localPosition = Vector3.Lerp(transform.localPosition, newPosition, Time.deltaTime * speed);
    }

    Vector3 PositionChange()
    {
        return new Vector3(Random.Range(mooveConstraints.x, mooveConstraints.y), transform.localPosition.y, Random.Range(mooveConstraints.x, mooveConstraints.y));
    }
}
