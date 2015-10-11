using UnityEngine;

public enum ElevatorDirection { None, Up, Down};

    public class ElevatorButton : MonoBehaviour
    {
        public static ElevatorDirection Direction;

        public void Pressed()
        {
            if (Elevator.Instance.CurrentLiftFloor == LiftFloor.InBetweenFloors)
            {
                Debug.Log("We are in motion. Please wait for the elevator to reach its destination.");
                return;
            }
            Debug.Log(Direction + " " + Elevator.Instance.CurrentLiftFloor);

            if (Direction == ElevatorDirection.Up)
            {
                if (Elevator.Instance.CurrentLiftFloor == LiftFloor.FourthFloor)
                {
                    Debug.Log("We are already at the top floor.");
                    return;
                } 
                else if (Elevator.Instance.CurrentLiftFloor == LiftFloor.FirstFloor)
                {
                    Elevator.Instance.MyAnimator.SetInteger("GoalFloor", 2);                   
                    CloseElevatorDoor();
                    Debug.Log("To the second.");

                }
                else if (Elevator.Instance.CurrentLiftFloor == LiftFloor.SecondFloor)
                {
                    Elevator.Instance.MyAnimator.SetInteger("GoalFloor", 3);
                    CloseElevatorDoor();
                    Debug.Log("To the third.");
                }
                else if (Elevator.Instance.CurrentLiftFloor == LiftFloor.ThirdFloor)
                {
                    Elevator.Instance.MyAnimator.SetInteger("GoalFloor", 4);
                    CloseElevatorDoor();
                    Debug.Log("To the fourth floor.");
                }

            }
            else if(Direction == ElevatorDirection.Down)
            {
                if (Elevator.Instance.CurrentLiftFloor == LiftFloor.FirstFloor)
                {
                    Debug.Log("We are already at the lowest floor.");
                    return;
                }
                if (Elevator.Instance.CurrentLiftFloor == LiftFloor.SecondFloor)
                {
                    Elevator.Instance.MyAnimator.SetInteger("GoalFloor", 1);
                    CloseElevatorDoor();
                    Debug.Log("To the first.");

                }
                else if (Elevator.Instance.CurrentLiftFloor == LiftFloor.ThirdFloor)
                {
                    Elevator.Instance.MyAnimator.SetInteger("GoalFloor", 2);
                    CloseElevatorDoor();
                    Debug.Log("To the second.");
                }
                else if (Elevator.Instance.CurrentLiftFloor == LiftFloor.FourthFloor)
                {
                    Elevator.Instance.MyAnimator.SetInteger("GoalFloor", 3);
                    CloseElevatorDoor();
                    Debug.Log("To the third.");
                }
                Debug.Log("We go down one floor.");
            }
        }

        private void CloseElevatorDoor()    //close the door of the floor we are. If the door is already closed, then just bring the elevator into motion.
        {
            Debug.Log("close a door");
            Door door = Doors.ElevatorDoors[Elevator.Instance.CurrentLiftFloor];
            switch (door)
            {
                case Door.ElevatorDoor1:
                    if (InGameObjectManager.Instance.ElevatorDoor1.IsOpen)
                        InGameObjectManager.Instance.ElevatorDoor1.CloseDoor();
                    else
                        InGameObjectManager.Instance.ElevatorDoor1.SetInbetweenFloors();
                    break;
                case Door.ElevatorDoor2:
                    if (InGameObjectManager.Instance.ElevatorDoor2.IsOpen)
                        InGameObjectManager.Instance.ElevatorDoor2.CloseDoor();
                    else
                        InGameObjectManager.Instance.ElevatorDoor2.SetInbetweenFloors();                    
                    break;
                case Door.ElevatorDoor3:
                    if (InGameObjectManager.Instance.ElevatorDoor3.IsOpen)
                        InGameObjectManager.Instance.ElevatorDoor3.CloseDoor();
                    else
                        InGameObjectManager.Instance.ElevatorDoor3.SetInbetweenFloors();
                    break;
                case Door.ElevatorDoor4:
                    if (InGameObjectManager.Instance.ElevatorDoor4.IsOpen)
                        InGameObjectManager.Instance.ElevatorDoor4.CloseDoor();
                    else
                        InGameObjectManager.Instance.ElevatorDoor4.SetInbetweenFloors();
                    break;
                default:
                    Debug.LogWarning("something is wrong with the currently assigned elevator door");
                    break;
            }
        }
    }

