using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ClickableDoor : ClickableObject
{
    public Door MyDoor;

    public static Dictionary<Door, InWorldObject> DoorObjects = new Dictionary<Door, InWorldObject>() 
    {
            {Door.None, InWorldObject.Null},      
            {Door.GalleryDoor, InWorldObject.GalleryPrivateDoor},      
            {Door.ElevatorDoor1, InWorldObject.ElevatorDoor1},      
            {Door.ElevatorDoor2, InWorldObject.ElevatorDoor2},      
            {Door.ElevatorDoor3, InWorldObject.ElevatorDoor3},      
            {Door.ElevatorDoor4, InWorldObject.ElevatorDoor4},      
            {Door.BigGateDoor, InWorldObject.BigGateDoor},       
            {Door.SmallGateDoor, InWorldObject.SmallGateDoor},       
    };

    public void Start()
    {
        if (MyDoor == Door.None)
            Debug.LogWarning("This Door has no name: " + Instance.name);

        MyObject = DoorObjects[MyDoor];

        base.Start();
    }
}

