using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class ColectBals : MonoBehaviour
{
    int Counter = 0;

    public TextMeshProUGUI Text;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ballen")
        {
            Counter++;
           Destroy(other.GetComponent<Collider>().gameObject);
        }
        Text.text = Counter.ToString();
    }
}
