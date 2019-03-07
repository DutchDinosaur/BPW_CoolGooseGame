using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private Transform PlayerTransform;
    [SerializeField]
    private Transform CameraTransform;
    [SerializeField]
    private InputManager Input;
    [Space(15)]
    [SerializeField]
    private Vector2 xAndYSpeed = new Vector2 ( 15 , 15 );
    [SerializeField]
    private Vector2 xAndYRotationSpeed = new Vector2(5, 5);
    [SerializeField]
    private Vector2 yUpperAndLowerRotationClamp = new Vector2(15, -15);
    [Space(15)]

    private Vector2 Rotation;

    private bool isgrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MovementAndRotation();
        Jump();
    }

    void MovementAndRotation()
    {
        //Movement
        rb.velocity = (transform.forward * Input.LStick.y * xAndYSpeed.y + transform.right * Input.LStick.x * xAndYSpeed.x);
        rb.AddForce(Vector3.down * 9.8f);

        //Rotation
        Rotation += new Vector2(Input.RStick.y, Input.RStick.x);
        if (yUpperAndLowerRotationClamp.x <= Rotation.x) { Rotation -= new Vector2(Input.RStick.y, 0); }
        if (yUpperAndLowerRotationClamp.y >= Rotation.x) { Rotation -= new Vector2(Input.RStick.y, 0); }

        CameraTransform.eulerAngles = new Vector3(-Rotation.x * xAndYRotationSpeed.x, Rotation.y * xAndYRotationSpeed.y, 0);
        PlayerTransform.eulerAngles = new Vector3(0, Rotation.y * xAndYRotationSpeed.y, 0);

    }

    void Jump()
    {

    }

    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Jumpable")
        {
            isgrounded = true;
        }
        if (Collision.gameObject.tag == "Void")
        {
            PlayerTransform.position = new Vector3(0,1,0);
        }
    }

    void OnCollisionExit(Collision Collision)
    {
        if (Collision.gameObject.tag == "Jumpable")
        {
            isgrounded = false;
        }
    }
}