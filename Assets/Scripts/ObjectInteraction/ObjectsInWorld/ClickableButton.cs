using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum ClickableButtons { Null, ElevatorButtonUp, ElevatorButtonDown, };
public class ClickableButton : ClickableObject
{
    public ClickableButtons MyButton;

    public static Dictionary<ClickableButtons, InWorldObject> ButtonObjects = new Dictionary<ClickableButtons, InWorldObject>() 
    {
            {ClickableButtons.Null, InWorldObject.Null},      
            {ClickableButtons.ElevatorButtonUp, InWorldObject.ElevatorUp},      
            {ClickableButtons.ElevatorButtonDown, InWorldObject.ElevatorDown},      
 
    };

    public void Start()
    {
        if (MyButton == ClickableButtons.Null)
            Debug.LogWarning("This button object has no name: " + Instance.name);

        MyObject = ButtonObjects[MyButton];

        base.Start();
    }
}

