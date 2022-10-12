using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
   
    public float Speed;
    public float SpeedBackwards;
    public float SteeringSpeed;
    public float groundDrag;
    public float airDrag;
    public LayerMask WatIsGround;

    float Vertical;
    float Horizontal;
    float YRotation;
    float speedCar;
    Vector3 lastPosition = Vector3.zero;
     Rigidbody rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        YRotation = transform.rotation.y;
    }

    void Update()
    {
        input();
    }

    void input()
    {
        Vertical=  Input.GetAxis("Vertical");
        Horizontal= Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {        
        SpeedCar();
                
        if(Physics.Raycast(transform.position, -transform.up, 2, WatIsGround))
        {
            RijdenGround();
        }
        else
        { 
            RijdenAir();
        }
       
    }
    void RijdenAir()
    {
        rb.drag = airDrag;
       
        YRotation = YRotation +  (Horizontal * SteeringSpeed * speedCar);
        Vector3 temp = transform.rotation.eulerAngles;
        temp.y = YRotation;
        transform.rotation = Quaternion.Euler(temp);
        
    }

    void RijdenGround()
    {
        rb.drag = groundDrag;

        
        Vector3 temp = transform.rotation.eulerAngles;
        temp.y = YRotation;
        transform.rotation = Quaternion.Euler(temp);
        
        
        if(Vertical >= 0) // voor uit
        {
            rb.AddForce(this.transform.forward * Speed * Vertical * 100);

            YRotation = YRotation +  (Horizontal * SteeringSpeed * speedCar);
        }
        else if(Vertical < 0) // achter uit
        {
            rb.AddForce(this.transform.forward * SpeedBackwards * Vertical * 100);

            YRotation = YRotation - (Horizontal * SteeringSpeed * speedCar * 2f);
        } 
    }
       
    void SpeedCar()
    {
        speedCar = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
    }
    
}










