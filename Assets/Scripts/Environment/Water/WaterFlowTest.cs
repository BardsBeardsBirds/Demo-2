using UnityEngine;
using System.Collections;
using UnityStandardAssets.Water;

public class WaterFlowTest : MonoBehaviour 
{
    public static WaterFlowTest Instance;
    public WaterBase WaterBase;
    public GameObject WaterGO;
    public Material WaterMaterial;

    private bool _changeDirection1To2;
    private bool _changeDirection1To3;
    private bool _changeDirection2To1;
    private bool _changeDirection2To3;
    private bool _changeDirection3To1;
    private bool _changeDirection3To2;

    private Vector4 _direction1;
    private Vector4 _direction2;
    private Vector4 _direction3;
    private Vector4 _riverDirection;

	void Start () 
    {
        Instance = this;

        ResetRiverDirections();
        _riverDirection = new Vector4(15, -60, 10, -20);

        WaterGO = GameObject.Find("Daylight Water");
    //    Debug.Log(WaterBase + " and " + WaterGO.GetComponent<WaterBase>());
        WaterGO.GetComponent<Renderer>().sharedMaterial.SetVector("WaveSpeed", _riverDirection);
	}
	
	void Update () 
    {

        if (_changeDirection1To2)
        {
            ChangeRiverFlow(1, _direction2);
        }
        if (_changeDirection1To3)
        {
            ChangeRiverFlow(1, _direction3);
        }
        if (_changeDirection2To1)
        {
            ChangeRiverFlow(2, _direction1);
        }
        if (_changeDirection2To3)
        {
            ChangeRiverFlow(2, _direction3);
        }
        if (_changeDirection3To1)
        {
            ChangeRiverFlow(3, _direction1);
        }
        if (_changeDirection3To2)
        {
            ChangeRiverFlow(3, _direction2);
        }

	}

    public void ChangeRiverFlow(int from, Vector4 to)
    {
        if (from == 1)
        {
            _riverDirection = Vector4.Lerp(_riverDirection, to, 15f * Time.deltaTime);
            WaterGO.GetComponent<Renderer>().sharedMaterial.SetVector("WaveSpeed", _riverDirection);
            //Debug.Log("1: " + _riverDirection + " en " + to);

            if (to == _direction2)
            {
                if (_riverDirection.y < -28 && _riverDirection.y > -32)
                {
                    ResetRiverDirections();
                    Debug.Log("1 to 2. reached the end");
                     _changeDirection1To2 = false;
                }
            }
            else if (to == _direction3)
            {
                if (_riverDirection.y > 38f && _riverDirection.y < 42)
                {
                    ResetRiverDirections();
                    Debug.Log("1 to 3. reached the end");
                    _changeDirection1To3 = false;
                }
            }            
        }
        else if (from == 2)
        {
            _riverDirection = Vector4.Lerp(_riverDirection, to, 15f * Time.deltaTime);
            WaterGO.GetComponent<Renderer>().sharedMaterial.SetVector("WaveSpeed", _riverDirection);
            Debug.Log("2: " + _riverDirection + " en " + to);

            if (to == _direction1)
            {
                if (_riverDirection.y < -58f && _riverDirection.y > -62f)
                {
                    ResetRiverDirections();
                    Debug.Log("2 to 1. reached the end");
                    _changeDirection2To1 = false;
                }
            }
            else if (to == _direction3)
            {
                if (_riverDirection.y > 38f && _riverDirection.y < 42)
                {
                    ResetRiverDirections();
                    Debug.Log("2 to 3. reached the end");
                    _changeDirection2To3 = false;
                }
            }  
        }
        else if (from == 3)
        {
            _riverDirection = Vector4.Lerp(_riverDirection, to, 15f * Time.deltaTime);
            WaterGO.GetComponent<Renderer>().sharedMaterial.SetVector("WaveSpeed", _riverDirection);
            //Debug.Log("3: " + _riverDirection + " en " + to);

            if (to == _direction1)
            {
                if (_riverDirection.y < -58f && _riverDirection.y > -62)
                {
                    ResetRiverDirections();
                    Debug.Log("3 to 1. reached the end");
                    _changeDirection3To1 = false;
                }
            }
            else if (to == _direction2)
            {
                if (_riverDirection.y < -28 && _riverDirection.y > -32)
                {
                    ResetRiverDirections();
                    Debug.Log("3 to 2. reached the end");
                    _changeDirection3To2 = false;
                }
            }
        }
        else
            Debug.LogWarning("some unknown river flow!");
    }

    public void From1To2()
    {
        _changeDirection1To2 = true;
        _changeDirection1To3 = false;
        _changeDirection2To1 = false;
        _changeDirection2To3 = false;
        _changeDirection3To1 = false;
        _changeDirection3To2 = false;
        WaterZone.OldZone = WaterZones.Zone2;
    }

    public void From1To3()
    {
        _changeDirection1To2 = false;
        _changeDirection1To3 = true;
        _changeDirection2To1 = false;
        _changeDirection2To3 = false;
        _changeDirection3To1 = false;
        _changeDirection3To2 = false;
        WaterZone.OldZone = WaterZones.Zone3;
    }

    public void From2To1()
    {
        _changeDirection1To2 = false;
        _changeDirection1To3 = false;
        _changeDirection2To1 = true;
        _changeDirection2To3 = false;
        _changeDirection3To1 = false;
        _changeDirection3To2 = false;
        WaterZone.OldZone = WaterZones.Zone1;
    }

    public void From2To3()
    {
        _changeDirection1To2 = false;
        _changeDirection1To3 = false;
        _changeDirection2To1 = false;
        _changeDirection2To3 = true;
        _changeDirection3To1 = false;
        _changeDirection3To2 = false;
        WaterZone.OldZone = WaterZones.Zone3;
    }

    public void From3To1()
    {
        _changeDirection1To2 = false;
        _changeDirection1To3 = false;
        _changeDirection2To1 = false;
        _changeDirection2To3 = false;
        _changeDirection3To1 = true;
        _changeDirection3To2 = false;
        WaterZone.OldZone = WaterZones.Zone1;
    }

    public void From3To2()
    {
        _changeDirection1To2 = false;
        _changeDirection1To3 = false;
        _changeDirection2To1 = false;
        _changeDirection2To3 = false;
        _changeDirection3To1 = false;
        _changeDirection3To2 = true;
        WaterZone.OldZone = WaterZones.Zone2;
    }

    public void ResetRiverDirections()
    {
        _direction1 = new Vector4(15, -60, 10, -20);
        _direction2 = new Vector4(55, -30, 20, -10);
        _direction3 = new Vector4(20, 40, 10, 10);
    }
}
