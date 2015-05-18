using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public GameObject Pointer;
    public DayNightCycle Cycle;
    public float PointerTimer;

    public void Start()
    {
        Cycle = GameManager.Instance.DayCycle;
      //  PointerTimer = (360f / Cycle.DayDurationInSeconds);
        PointerTimer = (360f / (Cycle.DayDurationInSeconds / 2));
    }

    public void TurnPointer()
    {
        Pointer.transform.Rotate(0, 0, -PointerTimer * Time.deltaTime);
    }
}