using System;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
  //  public Doors Instance;
    public Door ThisDoor;
    private Animator _animator;
    public bool IsOpen = false;

    public static Dictionary<LiftFloor, Door> ElevatorDoors = new Dictionary<LiftFloor, Door>()
    {
        {LiftFloor.FirstFloor, Door.ElevatorDoor1},
        {LiftFloor.SecondFloor, Door.ElevatorDoor2},
        {LiftFloor.ThirdFloor, Door.ElevatorDoor3},
        {LiftFloor.FourthFloor, Door.ElevatorDoor4},
    };

    public void Awake()
    {
     //   Instance = this;
        _animator = this.GetComponent<Animator>();
        IsOpen = false;
    }

    public void OpenDoor()
    {
        _animator.SetBool("Open", true);
        IsOpen = true;
    }

    public void CloseDoor()
    {
        _animator.SetBool("Open", false);
        IsOpen = false;
    }

    public void SetInbetweenFloors()
    {
        Elevator.Instance.CurrentLiftFloor = LiftFloor.InBetweenFloors;
        Elevator.Instance.MyAnimator.SetBool("IsMoving", true);
    }

    public void OpenGateDoor()
    {
        _animator.SetBool("Open", true);
    }
}
