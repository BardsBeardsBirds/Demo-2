﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MouseClickOnObject : MonoBehaviour
{
    public MouseClickOnObject Instance;
    public static bool MouseIsOnInvestigateButton = false;
    public static bool MouseIsOnInteractionButton = false;

    public ObjectsInLevel MyObject;
    public static ObjectsInLevel CurrentObject;
    public float depthIntoScene = 10;   

    public float defaultDepthIntoScene = 5;
    public float selectScale = .3f;

    private Text _descriptionText;

    private ActionPanel _actionPanel;

    #region ObjectsInLevel

    //This is the line that appears when the player hovers over an object
    public static Dictionary<ObjectsInLevel, string> ObjectLines = new Dictionary<ObjectsInLevel, string>() 
    {
        {ObjectsInLevel.Null, "Object is null"},      
        {ObjectsInLevel.AyTheTearCollector, "Ay the Tear Collector"},   
        {ObjectsInLevel.Bart, "Bart"},      
        {ObjectsInLevel.BennyTwospoons, "Benny Twospoons"},      
        {ObjectsInLevel.LeonTurmeric, "Leon"},      
        {ObjectsInLevel.MadameOpposita, "Madame Opposita"},      
        {ObjectsInLevel.MrB, "Mr. B"},      
        {ObjectsInLevel.Obstructor, "Mysterious Obstructor"},      
        {ObjectsInLevel.Sentinel, "Sentinel"},      

        {ObjectsInLevel.AysMagicDynamiteShake, "Ay's Magic Dynamite Shake"},
        {ObjectsInLevel.AysSecretIngredients, "Ay's secret ingredients"},
        {ObjectsInLevel.Axe, "Axe"},
        {ObjectsInLevel.Brush, "Brush"},
        {ObjectsInLevel.BrushWithPaint, "Paint"},
        {ObjectsInLevel.BucketWithPaint, "Bucket with paint"},
        {ObjectsInLevel.Carrot, "carrot"},
        {ObjectsInLevel.ClownMask, "Nauseating clown mask"},
        {ObjectsInLevel.ClownNose, "Clown nose"},
        {ObjectsInLevel.CupOfCoffee, "Cup of coffee"},
        {ObjectsInLevel.CupOfTea, "Cup of tea"},
        {ObjectsInLevel.GalleryKey, "Big key"},
        {ObjectsInLevel.Hammer, "Hammer"},
        {ObjectsInLevel.MaskRemains, "Mask remains"},
        {ObjectsInLevel.PartyHat, "Party hat"},
        {ObjectsInLevel.Purse, "Purse"},
        {ObjectsInLevel.RoughneckShot, "Roughneck shot"},
        {ObjectsInLevel.Scissors, "Scissors"},
        {ObjectsInLevel.SelfMadeMask, "Self made mask"},
        {ObjectsInLevel.SpeakingTrumpet, "Speaking trumpet"},
        {ObjectsInLevel.TeaLeaves, "Tea leaves"},
        {ObjectsInLevel.GoldenScreech, "Golden screech"},

        {ObjectsInLevel.CopperBowl, "Copper bowl"},
        {ObjectsInLevel.Teapot, "Leon's teapot"},

        {ObjectsInLevel.GalleryPrivateDoor, "Private door"},
        {ObjectsInLevel.ElevatorDoor1, "Elevator door"},
        {ObjectsInLevel.ElevatorDoor2, "Elevator door"},
        {ObjectsInLevel.ElevatorDoor3, "Elevator door"},
        {ObjectsInLevel.ElevatorDoor4, "Elevator door"},

        {ObjectsInLevel.ElevatorUp, "Go up button"},
        {ObjectsInLevel.ElevatorDown, "Go down button"},

    };

    public static Dictionary<ObjectsInLevel, string> ObjectInteractionLines = new Dictionary<ObjectsInLevel, string>() 
    {
        {ObjectsInLevel.Null, "Object is null"},      
        {ObjectsInLevel.AyTheTearCollector, "Talk to Ay the Tear Collector"},   
        {ObjectsInLevel.Bart, "Talk to Bart"},      
        {ObjectsInLevel.BennyTwospoons, "Talk to Benny Twospoons"},      
        {ObjectsInLevel.LeonTurmeric, "Talk to Leon"},      
        {ObjectsInLevel.MadameOpposita, "Talk to Madame Opposita"},      
        {ObjectsInLevel.MrB, "Talk to Mr. B"},      
        {ObjectsInLevel.Obstructor, "Talk to Mysterious Obstructor"},      
        {ObjectsInLevel.Sentinel, "Talk to Sentinel"}, 

        {ObjectsInLevel.AysMagicDynamiteShake, "Interact with Ay's Magic Dynamite Shake"},
         {ObjectsInLevel.AysSecretIngredients, "Interact with Ay's secret ingredients"},
        {ObjectsInLevel.Axe, "Interact with axe"},
        {ObjectsInLevel.Brush, "Interact with brush"},
        {ObjectsInLevel.BrushWithPaint, "Interact with brush with paint"},
        {ObjectsInLevel.BucketWithPaint, "Interact with bucket with paint"},
        {ObjectsInLevel.Carrot, "Interact with carrot"},
        {ObjectsInLevel.ClownMask, "Interact with nauseating clown mask"},
        {ObjectsInLevel.ClownNose, "Interact with clown nose"},
        {ObjectsInLevel.CupOfCoffee, "Interact with cup of coffee"},
        {ObjectsInLevel.CupOfTea, "Interact with cup of tea"},
        {ObjectsInLevel.GalleryKey, "Interact with big key"},
        {ObjectsInLevel.Hammer, "Interact with hammer"},
        {ObjectsInLevel.MaskRemains, "Interact with mask remains"},
        {ObjectsInLevel.PartyHat, "Interact with party hat"},
        {ObjectsInLevel.Purse, "Interact with purse"},
        {ObjectsInLevel.RoughneckShot, "Interact with roughneck shot"},
        {ObjectsInLevel.Scissors, "Interact with scissors"},
        {ObjectsInLevel.SelfMadeMask, "Interact with self made mask"},
        {ObjectsInLevel.SpeakingTrumpet, "Interact with speaking trumpet"},
        {ObjectsInLevel.TeaLeaves, "Interact with tea leaves"},
        {ObjectsInLevel.GoldenScreech, "Interact with the Golden Screech"},
        
        {ObjectsInLevel.CopperBowl, "Interact with copper bowl"},
        {ObjectsInLevel.Teapot, "Interact with Leon's teapot"},

        {ObjectsInLevel.GalleryPrivateDoor, "Interact with private door"},
        {ObjectsInLevel.ElevatorDoor1, "Open elevator door"},
        {ObjectsInLevel.ElevatorDoor2, "Open elevator door"},
        {ObjectsInLevel.ElevatorDoor3, "Open elevator door"},
        {ObjectsInLevel.ElevatorDoor4, "Open elevator door"},

        {ObjectsInLevel.ElevatorUp, "Go up"},
        {ObjectsInLevel.ElevatorDown, "Go down"},
    
};

    public static Dictionary<ObjectsInLevel, string> ObjectInvestigationLines = new Dictionary<ObjectsInLevel, string>() 
    {
        {ObjectsInLevel.Null, "Object is null"},      
        {ObjectsInLevel.AyTheTearCollector, "Investigate Ay the Tear Collector"},   
        {ObjectsInLevel.Bart, "Investigate Bart"},      
        {ObjectsInLevel.BennyTwospoons, "Investigate Benny Twospoons"},      
        {ObjectsInLevel.LeonTurmeric, "Investigate Leon"},      
        {ObjectsInLevel.MadameOpposita, "Investigate Madame Opposita"},      
        {ObjectsInLevel.MrB, "Investigate Mr. B"},      
        {ObjectsInLevel.Obstructor, "Investigate Mysterious Obstructor"},      
        {ObjectsInLevel.Sentinel, "Investigate Sentinel"}, 
      
        {ObjectsInLevel.AysMagicDynamiteShake, "Investigate Ay's Magic Dynamite Shake"},
        {ObjectsInLevel.AysSecretIngredients, "Investigate Ay's secret ingredients"},
        {ObjectsInLevel.Axe, "Investigate axe"},
        {ObjectsInLevel.Brush, "Investigate brush"},
        {ObjectsInLevel.BrushWithPaint, "Investigate brush with paint"},
        {ObjectsInLevel.BucketWithPaint, "Investigate bucket with paint"},
        {ObjectsInLevel.Carrot, "Investigate carrot"},
        {ObjectsInLevel.ClownMask, "Investigate nauseating clown mask"},
        {ObjectsInLevel.ClownNose, "Investigate clown nose"},
        {ObjectsInLevel.CupOfCoffee, "Investigate cup of coffee"},
        {ObjectsInLevel.CupOfTea, "Investigate cup of tea"},
        {ObjectsInLevel.GalleryKey, "Investigate big key"},
        {ObjectsInLevel.Hammer, "Investigate hammer"},
        {ObjectsInLevel.MaskRemains, "Investigate mask remains"},
        {ObjectsInLevel.PartyHat, "Investigate party hat"},
        {ObjectsInLevel.Purse, "Investigate purse"},
        {ObjectsInLevel.RoughneckShot, "Investigate roughneck shot"},
        {ObjectsInLevel.Scissors, "Investigate scissors"},
        {ObjectsInLevel.SelfMadeMask, "Investigate self made mask"},
        {ObjectsInLevel.SpeakingTrumpet, "Investigate speaking trumpet"},
        {ObjectsInLevel.TeaLeaves, "Investigate tea leaves"},
        {ObjectsInLevel.GoldenScreech, "Investigate the Golden Screech"},

        {ObjectsInLevel.CopperBowl, "Investigate copper bowl"},
        {ObjectsInLevel.Teapot, "Investigate Leon's teapot"},

        {ObjectsInLevel.GalleryPrivateDoor, "Investigate private door"},
        {ObjectsInLevel.ElevatorDoor1, "Investigate elevator door"},
        {ObjectsInLevel.ElevatorDoor2, "Investigate elevator door"},
        {ObjectsInLevel.ElevatorDoor3, "Investigate elevator door"},
        {ObjectsInLevel.ElevatorDoor4, "Investigate elevator door"},

        {ObjectsInLevel.ElevatorUp, "Investigate go up button"},
        {ObjectsInLevel.ElevatorDown, "Investigate go down button"},
    };

    #endregion


    public void Start()
    {
        if (MyObject == ObjectsInLevel.Null)
            Debug.LogWarning("This object has no name: " + Instance.name);

        Instance = this;

        _descriptionText = GameManager.Instance.UICanvas.ObjectDescriptionText;
        _actionPanel = new ActionPanel();
    }

    public void OnMouseDown()
    {
        if (GameManager.GamePlayingMode == GameManager.GameMode.Paused) // don't show if paused.
            return;

        ActionPanel.LastHoveredObject = MyObject;

        if (UIDrawer.IsDraggingItem)
        {
            //   GameManager.Instance.IIventoryItemWithObject.CombineItems(GameManager.Instance.MyInventory.TheDraggedItem, MyObject);

            bool tryCombine = false;
            tryCombine = GameManager.Instance.IIventoryItemWithObject.CombineItems(GameManager.Instance.MyInventory.TheDraggedItem, MyObject);

            if (tryCombine)
            {
                Debug.LogWarning("We can combine these two!! Dragging from slot no " + UIDrawer.DraggingFromSlotNo);
                GameManager.Instance.MyInventory.EndDragging(UIDrawer.DraggingFromSlotNo);
            }

        }
        else
        {
            ActionPanel.IsInInventory = false;
            _actionPanel.MoveActionPanelToClickedObject(false);   //show the action panel
        }
            //_actionPanel.MoveActionPanelToClickedObject(ActionPanel.ItemInteractionType.ObjectInWorld);   //show the action panel
    }

    public void OnMouseExit()
    {
        if(UIDrawer.IsDraggingItem)
        {
            _descriptionText.text = UIDrawer.DraggingItem.ItemName;
            _descriptionText.enabled = true;
        }
        else if (!MouseIsOnInvestigateButton && !MouseIsOnInteractionButton)
            GameManager.Instance.UICanvas.HideObjectDescriptionText();
    }

    public void OnMouseUp()
    {
        ActionPanel.LastHoveredObject = ObjectsInLevel.Null;

        if (MouseIsOnInvestigateButton || MouseIsOnInteractionButton)
        {
            AudioManager.Instance.UISoundsScript.PlayClick();   // sound
            _actionPanel.PlayActionPanelForClickedObject(MyObject, this.transform);
            GameManager.Instance.UICanvas.HideObjectDescriptionText();
        }
        else
            ActionPanel.HideActionPanel();
    }

    public void OnMouseOver()
    {
        if (GameManager.GamePlayingMode == GameManager.GameMode.Paused) // don't show if paused.
            return;

        if (GameManager.Instance.UICanvas.Hovering != MainCanvas.Hoverings.MouseInWorld)
            return;
        
        CurrentObject = MyObject;

        _descriptionText.enabled = true;
        GameManager.Instance.UICanvas.NewObjectDescription();

        if (ActionPanel.LastHoveredObject == CurrentObject)
            return;

        if (!MouseIsOnInteractionButton || !MouseIsOnInvestigateButton)
        {
            if(UIDrawer.IsDraggingItem)
            {
                _descriptionText.text = "Use "
                    + GameManager.Instance.MyInventory.TheDraggedItem.ItemName + " with " + ObjectLines[MyObject];
            }
            else
            {
                _descriptionText.text = ObjectLines[MyObject];
                MyConsole.WriteToConsole(ObjectLines[MyObject]);
            }
        }
    }
}
