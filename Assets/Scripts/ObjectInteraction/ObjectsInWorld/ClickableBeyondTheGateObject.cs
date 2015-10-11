using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum ClickableBeyondTheGateObjects { Null,  };

public class ClickableBeyondTheGateObject : ClickableObject
{
    public ClickableBeyondTheGateObjects MyBeyondTheGateObject;

    public static Dictionary<ClickableBeyondTheGateObjects, InWorldObject> BeyondTheGateObjects = new Dictionary<ClickableBeyondTheGateObjects, InWorldObject>() 
    {
            {ClickableBeyondTheGateObjects.Null, InWorldObject.Null},      
    
    };

    public void Start()
    {
        if (MyBeyondTheGateObject == ClickableBeyondTheGateObjects.Null)
            Debug.LogWarning("This BeyondTheGate object has no name: " + Instance.name);

        MyObject = BeyondTheGateObjects[MyBeyondTheGateObject];

        base.Start();
    }
}

