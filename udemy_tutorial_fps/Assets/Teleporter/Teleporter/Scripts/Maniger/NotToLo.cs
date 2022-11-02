using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotToLo : MonoBehaviour
{
    [
        Tooltip(
            "Zorg er voor dat alle opjecten in de lijst niet lager kunnen dan LowistPoint")
    ]
    public List<Transform> transformList = new List<Transform>();

    public PlayerMove PlayerMove;

    public float LowistPoint = -2;

    List<Vector3> StartPosition = new List<Vector3>();

    void Start()
    {   
        PlayerMove.Jump();
        for (int i = 0; i < transformList.Count; i++)
        {
            StartPosition.Add(transformList[i].position);
        }
    }

    void Update()
    {
        for (int i = 0; i < transformList.Count; i++)
        {
            if (transformList[i] == null)
            {
                transformList.Remove(transformList[i]);
            }
            else
            {
                if (transformList[i].position.y <= LowistPoint)
                {
                    transformList[i].position = StartPosition[i];
                }
            }
        }
    }
    
}
