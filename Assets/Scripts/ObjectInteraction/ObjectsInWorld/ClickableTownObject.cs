using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum ClickableTownObjects { Null, Scarecrow, Teapot};

public class ClickableTownObject : ClickableObject
{
    public ClickableTownObjects MyTownObject;

    public static Dictionary<ClickableTownObjects, InWorldObject> TownObjects = new Dictionary<ClickableTownObjects, InWorldObject>() 
    {
            {ClickableTownObjects.Null, InWorldObject.Null},      
            {ClickableTownObjects.Scarecrow, InWorldObject.Scarecrow},      
            {ClickableTownObjects.Teapot, InWorldObject.Teapot},      
    
    };

    public void Start()
    {
        if (MyTownObject == ClickableTownObjects.Null)
            Debug.LogWarning("This town object has no name: " + Instance.name);

        MyObject = TownObjects[MyTownObject];

        base.Start();
    }
}

