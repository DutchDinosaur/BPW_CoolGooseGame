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
    [SerializeField]
    private int jumpForce = 25;
    [SerializeField]
    private float jumpSustain = .5f;
    [SerializeField]
    private float addedDownwardsAcceleration = 6;
    [SerializeField]
    private float Gravity = 9.8f;

    private Vector2 Rotation;

    private bool isgrounded;

    [SerializeField]
    private AudioSource walksound;

    private void Start()
    {
        Physics.gravity = new Vector3(0, -Gravity, 0);

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
        rb.AddForce(transform.forward * Input.LStick.y * xAndYSpeed.y + transform.right * Input.LStick.x * xAndYSpeed.x);
        if (rb.velocity.x > 1 || rb.velocity.z > 1)
        {
            walksound.enabled = true;
        }
        else { walksound.enabled = false; }

        //Rotation
        Rotation += new Vector2(Input.RStick.y, Input.RStick.x);
        if (yUpperAndLowerRotationClamp.x <= Rotation.x) { Rotation -= new Vector2(Input.RStick.y, 0); }
        if (yUpperAndLowerRotationClamp.y >= Rotation.x) { Rotation -= new Vector2(Input.RStick.y, 0); }

        CameraTransform.eulerAngles = new Vector3(-Rotation.x * xAndYRotationSpeed.x, Rotation.y * xAndYRotationSpeed.y, 0);
        PlayerTransform.eulerAngles = new Vector3(0, Rotation.y * xAndYRotationSpeed.y, 0);

    }


    void Jump()
    {
        //Jump
        if (Input.AButton && isgrounded == true)
        {
            rb.AddForce(0, jumpForce, 0);
        }

        if (Input.AButton && rb.velocity.y > 0)
        {
            rb.AddForce(0, jumpSustain, 0);
        }

        if (rb.velocity.y < 0)
        {
            //rb.mass += addedDownwardsAcceleration;
            Physics.gravity -= new Vector3(0, addedDownwardsAcceleration, 0);
        }

        if (isgrounded == true)
        {
            //rb.mass = .1f;
            Physics.gravity = new Vector3(0, -Gravity, 0);
        }
    }

    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Jumpable")
        {
            isgrounded = true;
        }
        if (Collision.gameObject.tag == "Void")
        {
            Application.LoadLevel(Application.loadedLevel);
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