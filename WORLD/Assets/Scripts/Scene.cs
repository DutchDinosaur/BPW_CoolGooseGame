using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    [SerializeField]
    private GameObject Boss;
    [SerializeField]
    private int menuTime = 100;

    private int timer;



    private void FixedUpdate()
    {
        if (Boss == null)
        {
            timer += 1;
            if (timer >= menuTime)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SwitchScene(0);
            }
        }
    }

    public void SwitchScene(int level)
    {
        SceneManager.LoadScene(level);
        //Application.LoadLevel(level);
    }
}
