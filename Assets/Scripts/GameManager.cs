using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public DayNightCycle DayCycle;

    public GameObject Player;

    void Awake()
    {
        Instance = this;

        DayCycle = new DayNightCycle();
        DayCycle.InitialiseCycle();

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        DayCycle.PassTime();
    }
}
