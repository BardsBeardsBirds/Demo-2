using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum ClickableSquanderLandsObjects { Null, CopperBowl, };

public class ClickableSquanderLandsObject : ClickableObject
{
    public ClickableSquanderLandsObjects MySquanderLandsObject;

    public static Dictionary<ClickableSquanderLandsObjects, InWorldObject> SquanderLandsObjects = new Dictionary<ClickableSquanderLandsObjects, InWorldObject>() 
    {
            {ClickableSquanderLandsObjects.Null, InWorldObject.Null},      
            {ClickableSquanderLandsObjects.CopperBowl, InWorldObject.CopperBowl},      
    
    };

    public void Start()
    {
        if (MySquanderLandsObject == ClickableSquanderLandsObjects.Null)
            Debug.LogWarning("This SquanderLands object has no name: " + Instance.name);

        MyObject = SquanderLandsObjects[MySquanderLandsObject];

        base.Start();
    }
}

