using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActevateMenu : MonoBehaviour
{

    public GameObject Menu;
    bool MenuActiv = false;

    void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && MenuActiv == false)
        {
            actevateMenu();
        }
        else if(Input.GetKeyDown(KeyCode.Escape )&& MenuActiv == true)
        {
            DeActevateMenu();
        }
    }

    void actevateMenu()
    {
        Menu.SetActive(true);
        MenuActiv = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void DeActevateMenu()
    {
        Menu.SetActive(false);
        MenuActiv = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}


