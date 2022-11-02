using System.Collections;
using System.Collections.Generic;
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
