using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum ClickableWoodsObjects { Null, };

public class ClickableWoodsObject : ClickableObject
{
    public ClickableWoodsObjects MyWoodsObject;

    public static Dictionary<ClickableWoodsObjects, InWorldObject> WoodsObjects = new Dictionary<ClickableWoodsObjects, InWorldObject>() 
    {
            {ClickableWoodsObjects.Null, InWorldObject.Null},          
    };

    public void Start()
    {
        if (MyWoodsObject == ClickableWoodsObjects.Null)
            Debug.LogWarning("This wood object has no name: " + Instance.name);

        MyObject = WoodsObjects[MyWoodsObject];

        base.Start();
    }
}

