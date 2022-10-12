using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [Tooltip("wordt als eerst gebruikt")]
    public Transform trans_Destination;

    [Tooltip("word pas gebruikt als trans_Destination niet ingevult is")]
    public Vector3 vec_Destination;

    public ParticleSystem ParticleSystem;

    Vector3 destination;

    void OnTriggerEnter(Collider other)
    {
        if (!trans_Destination == null)
        {
            destination = trans_Destination.position;
        }
        else
        {
            destination = trans_Destination.position;
        }
        StartCoroutine(Wait(other));
    }

    IEnumerator Wait(Collider other)
    {
        other.transform.parent.position = destination;

        var particle =
            Instantiate(ParticleSystem,
            other.transform.parent.position + other.transform.parent.forward,
            transform.rotation);
        particle.transform.parent = other.transform.parent;

        yield return new WaitForSeconds(1);

        Destroy (particle);
    }
}
