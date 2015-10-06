using System;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public static Elevator Instance;

    public Animator MyAnimator;
    public LiftFloor CurrentLiftFloor;

    public void Awake()
    {
        Instance = this;

        MyAnimator = GetComponent<Animator>();
        CurrentLiftFloor = LiftFloor.FirstFloor;
    }

    public void SetToFloorOne()
    {
        CurrentLiftFloor = LiftFloor.FirstFloor;
        EndMoving();
    }

    public void SetToFloorTwo()
    {
        CurrentLiftFloor = LiftFloor.SecondFloor;
        EndMoving();
    }

    public void SetToFloorThree()
    {
        CurrentLiftFloor = LiftFloor.ThirdFloor;
        EndMoving();
    }

    public void SetToFloorFour()
    {
        CurrentLiftFloor = LiftFloor.FourthFloor;
        EndMoving();
    }

    private void EndMoving()
    {
        Elevator.Instance.MyAnimator.SetBool("IsMoving", false);
    }
}
