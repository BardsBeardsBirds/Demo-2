using System;
using UnityEngine;

public class ElevatorFloor : MonoBehaviour
{
    public void OnTriggerEnter (Collider other) 
    {
        //Debug.Log(other.tag);
        if (other.gameObject.GetComponent<Emmon>() != null)
        {
            other.transform.parent = gameObject.transform;
        }
    }
 
    public void OnTriggerExit (Collider other)
    {
        if (other.gameObject.GetComponent<Emmon>() != null)
        {
            other.transform.parent = null;
        }
    }
}

