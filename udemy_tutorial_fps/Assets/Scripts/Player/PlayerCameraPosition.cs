using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraPosition : MonoBehaviour
{
    public Transform cameraPosition;

    private void Update()
    {
        transform.position = cameraPosition.position;
        //transform.rotation = cameraPosition.rotation;
    }
}
