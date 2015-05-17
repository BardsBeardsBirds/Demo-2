using UnityEngine;

public class WaterZone : MonoBehaviour
{
    public static WaterZones OldZone;
    public WaterZones ThisZone;
    private WaterZones _newZone;

    public void Awake()
    {
        _newZone = ThisZone;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        if (_newZone == OldZone)
            return;

        if(OldZone == WaterZones.Zone1)
        {
            if(_newZone == WaterZones.Zone2)
                WaterFlowTest.Instance.From1To2();
            else
                WaterFlowTest.Instance.From1To3();
        }
        else if (OldZone == WaterZones.Zone2)
        {
            if (_newZone == WaterZones.Zone1)
                WaterFlowTest.Instance.From2To1();
            else
                WaterFlowTest.Instance.From2To3();
        }
        else if (OldZone == WaterZones.Zone3)
        {
            if (_newZone == WaterZones.Zone1)
                WaterFlowTest.Instance.From3To1();
            else
                WaterFlowTest.Instance.From3To2();
        }
    }
}

public enum WaterZones
{
    Zone1,
    Zone2,
    Zone3
}

