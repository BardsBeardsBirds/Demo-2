using UnityEngine;
using System.Collections;

public class WaterWheelHorizontal : MonoBehaviour 
{
    public GameObject PivotObject;

	void Start () 
    {
        PivotObject = this.gameObject;
	}
	

    void Update () 
    {
        transform.RotateAround(PivotObject.transform.position, Vector3.down, -70 * Time.deltaTime);
	}
}
