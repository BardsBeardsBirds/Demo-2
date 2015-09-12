using UnityEngine;
using System.Collections;

public class WaterWheelVertical : MonoBehaviour
{
    public GameObject PivotObject;

    void Start()
    {
        PivotObject = this.gameObject;
    }


    void Update()
    {
        transform.RotateAround(PivotObject.transform.position, Vector3.right, -25 * Time.deltaTime);
    }
}
