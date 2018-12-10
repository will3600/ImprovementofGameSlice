using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
    public GameObject SphereLeft;
    public GameObject SphereRight;

    private void OnTriggerEnter()
    {
        SphereLeft.SetActive(true);
        SphereRight.SetActive(true);
    }
}	
