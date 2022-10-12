using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCer : MonoBehaviour
{
    public GameObject Player;

    public DriveCar DriveCar;

    public GameObject Camera;

    public Animator Animator;

    bool InCar = false;

    void OnTriggerStay(Collider other)
    {
        if (
            other.name == "Player OBJ" &&
            Input.GetKeyDown(KeyCode.E) &&
            InCar == false
        )
        {
            Player.SetActive(false);
            Camera.SetActive(true);
            Animator.SetTrigger("Enter");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InCar == true)
        {
            Animator.SetTrigger("Exsit");
        }
    }

    void exsitCar() // word geactifeert door animator "Exsit"
    {
        Player.SetActive(true);
        Camera.SetActive(false);
        DriveCar.enabled = false;
        InCar = false;
        Player.transform.position = this.transform.position;
    }

    void enterCar() // word geactifeert door animator "Enter"
    {
        DriveCar.enabled = true;
        InCar = true;
    }
}
