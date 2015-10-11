using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum ClickablePickupables
{ 
    Null,
    AysMagicDynamiteShake, 
    AysSecretIngredients, 
    Axe, 
    Brush, 
    BrushWithPaint, 
    BucketWithPaint, 
    Carrot,
    ClownMask, 
    ClownNose,
    CupOfCoffee, 
    CupOfTea, 
    GalleryKey, 
    GoldenScreech, 
    Hammer, 
    MaskRemains, 
    PartyHat, 
    Purse, 
    RoughneckShot, 
    Scissors, 
    SelfMadeMask, 
    SpeakingTrumpet, 
    TeaLeaves 
};

public class ClickablePickupable : ClickableObject
{
    public ClickablePickupables MyPickupable;

    public static Dictionary<ClickablePickupables, InWorldObject> PickupableObjects = new Dictionary<ClickablePickupables, InWorldObject>() 
    {
            {ClickablePickupables.Null, InWorldObject.Null},            
            {ClickablePickupables.AysMagicDynamiteShake, InWorldObject.AysMagicDynamiteShake},            
            {ClickablePickupables.AysSecretIngredients, InWorldObject.AysSecretIngredients},            
            {ClickablePickupables.Axe, InWorldObject.Axe},            
            {ClickablePickupables.Brush, InWorldObject.Brush},            
            {ClickablePickupables.BrushWithPaint, InWorldObject.BrushWithPaint},            
            {ClickablePickupables.BucketWithPaint, InWorldObject.BucketWithPaint},            
            {ClickablePickupables.Carrot, InWorldObject.Carrot},            
            {ClickablePickupables.ClownMask, InWorldObject.ClownMask},            
            {ClickablePickupables.ClownNose, InWorldObject.ClownNose},            
            {ClickablePickupables.CupOfCoffee, InWorldObject.CupOfCoffee},            
            {ClickablePickupables.CupOfTea, InWorldObject.CupOfTea},            
            {ClickablePickupables.GalleryKey, InWorldObject.GalleryKey},            
            {ClickablePickupables.GoldenScreech, InWorldObject.GoldenScreech},            
            {ClickablePickupables.Hammer, InWorldObject.Hammer},            
            {ClickablePickupables.MaskRemains, InWorldObject.MaskRemains},            
            {ClickablePickupables.PartyHat, InWorldObject.PartyHat},            
            {ClickablePickupables.Purse, InWorldObject.Purse},            
            {ClickablePickupables.RoughneckShot, InWorldObject.RoughneckShot},            
            {ClickablePickupables.SelfMadeMask, InWorldObject.SelfMadeMask},            
            {ClickablePickupables.SpeakingTrumpet, InWorldObject.SpeakingTrumpet},            
            {ClickablePickupables.TeaLeaves, InWorldObject.TeaLeaves},            
    };

    public void Start()
    {
        if (MyPickupable == ClickablePickupables.Null)
            Debug.LogWarning("This pickupable object has no name: " + Instance.name);

        MyObject = PickupableObjects[MyPickupable];

        base.Start();
    }
}

