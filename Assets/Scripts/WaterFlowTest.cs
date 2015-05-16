using UnityEngine;
using System.Collections;
using UnityStandardAssets.Water;

public class WaterFlowTest : MonoBehaviour {

    public GameObject WaterGO;
    public WaterTile WaterSettings;
    public Material WaterMaterial;

    private bool _changeWaterDirection1;
    private bool _changeWaterDirection2;

    private Vector4 _direction1;
    private Vector4 _direction2;
    private Vector4 _riverDirection;

	void Start () 
    {
        ResetRiverDirections();
        _riverDirection = new Vector4(40, -80, 20, -40);

        WaterGO = GameObject.Find("Water4Advanced 1");
        WaterSettings = WaterGO.GetComponentInChildren<WaterTile>();
        Vector3 fl = WaterGO.GetComponent<WaterBase>().sharedMaterial.GetVector("_BumpDirection");
        WaterGO.GetComponent<WaterBase>().sharedMaterial.SetVector("_BumpDirection", _riverDirection);

	}
	

	void Update () 
    {
   //     Debug.Log(WaterGO.GetComponent<WaterBase>().sharedMaterial.GetVector("_BumpDirection"));

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _changeWaterDirection1 = true;
            _changeWaterDirection2 = false;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            _changeWaterDirection2 = true;
            _changeWaterDirection1 = false;

        }

        if (_changeWaterDirection1)
        {
            _riverDirection = Vector4.Lerp(_riverDirection, _direction2, 1f * Time.deltaTime);
            WaterGO.GetComponent<WaterBase>().sharedMaterial.SetVector("_BumpDirection", _riverDirection);
            Debug.Log("1: " + _riverDirection + " en " + _direction2);

            if (_direction1.y > 38f)
            {
                ResetRiverDirections();
                Debug.Log("1. reached the end");

                _changeWaterDirection1 = false;
            }
        }

        if (_changeWaterDirection2)
        {
            _riverDirection = Vector4.Lerp(_riverDirection, _direction1, 1f * Time.deltaTime);
            WaterGO.GetComponent<WaterBase>().sharedMaterial.SetVector("_BumpDirection", _riverDirection);
            Debug.Log("2: " + _riverDirection + " en " + _direction1);

            if (_direction2.y < -75f)
            {
                ResetRiverDirections();
                Debug.Log("2. reached the end");

                _changeWaterDirection2 = false;
            }
        }
	}

    public void ResetRiverDirections()
    {
        _direction1 = new Vector4(40, -80, 20, -40);
        _direction2 = new Vector4(40, 40, 20, 20); 
    }
}
