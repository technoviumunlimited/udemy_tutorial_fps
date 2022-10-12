using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NotToLo : MonoBehaviour
{
    [Tooltip("Zorg er voor dat alle opjecten in de lijst niet lager kunnen dan LowistPoint")]
    public List<Transform> transformList = new List<Transform>();
    public float LowistPoint = -2;

    List<Vector3> StartPosition = new List<Vector3>();
    
    void Start()
    {
        for (int i = 0; i < transformList.Count; i++) 
        {
            StartPosition.Add( transformList[i].position);
        }
    }

    void Update()
    {
        for (int i = 0; i < transformList.Count; i++) 
        {
           
            if(transformList[i] == null) 
            {
                
            }
           else
            {
                if(transformList[i].position.y <= LowistPoint)
                {
                    transformList[i].position = StartPosition[i];
                }
            }
        }
    }
}
