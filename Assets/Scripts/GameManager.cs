using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public DayNightCycle DayCycle;

    void Awake()
    {
        Instance = this;

        DayCycle = new DayNightCycle();
        DayCycle.InitialiseCycle();
    }

    public void Update()
    {
        DayCycle.PassTime();
    }
}
