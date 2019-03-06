using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private bool DisableMouseInput = true;
    [Space(15)]
    [Header("KeyCodes")]
    [SerializeField]
    private KeyCode[] WASD = new KeyCode[] {KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D};
    [SerializeField]
    private KeyCode[] ArrowKeys = new KeyCode[] { KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow };

    [Space(60)]
    //[HideInInspector]
    public Vector2 LStick;
    //[HideInInspector]
    public Vector2 RStick;
    //[HideInInspector]
    public bool AButton;
    //[HideInInspector]
    public bool ShootButton;

    void FixedUpdate()
    {
        //Lstick
        LStick = new Vector2(0,0);
        LStick += KeysToVector2Dir(WASD[0], WASD[1], WASD[2], WASD[3]);
        LStick += new Vector2(Input.GetAxis("Lstick_X"), Input.GetAxis("Lstick_Y"));
        LStick = ClampTo1(LStick);

        //Rstick
        RStick = new Vector2(0, 0);
        RStick += KeysToVector2Dir(ArrowKeys[0], ArrowKeys[1], ArrowKeys[2], ArrowKeys[3]);
        RStick += new Vector2(Input.GetAxis("Rstick_X"), Input.GetAxis("Rstick_Y"));
        if (DisableMouseInput == false)
        {
            float mouseX = Input.GetAxis("Mouse_X") ;
            float mouseY = Input.GetAxis("Mouse_Y") ;
            RStick += new Vector2(mouseX, mouseY);
        }
        RStick = ClampTo1(RStick);
        
        //Jump
        if ( Input.GetKey(KeyCode.Space) || Input.GetButton("AButton"))
        {
            AButton = true;
        }
        else { AButton = false; }

        //gunstuffs
        if (Input.GetAxis("Rtrigger") != 0 || Input.GetMouseButton(0))
        {
            ShootButton = true;
        } else { ShootButton = false;  }
    }

    Vector2 KeysToVector2Dir(KeyCode Up, KeyCode Left, KeyCode Down, KeyCode Right)
    {
        Vector2 Dir = new Vector2(0, 0);
        if (Input.GetKey(Left))
        {
            Dir.x -= 1;
        }
        if (Input.GetKey(Right))
        {
            Dir.x += 1;
        }
        if (Input.GetKey(Up))
        {
            Dir.y += 1;
        }
        if (Input.GetKey(Down))
        {
            Dir.y -= 1;
        }

        return Dir;
    }

    Vector2 ClampTo1(Vector2 Vector)
    {
        if (Vector.x > 1) { Vector.x = 1; }
        if (Vector.x < -1) { Vector.x = -1; }
        if (Vector.y > 1) { Vector.y = 1; }
        if (Vector.y < -1) { Vector.y = -1; }
        return Vector;
    }

}