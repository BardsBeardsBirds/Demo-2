using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClickableObject : MonoBehaviour
{
    public ClickableObject Instance;
    public static bool MouseIsOnInvestigateButton = false;
    public static bool MouseIsOnInteractionButton = false;

    public InWorldObject MyObject;
    public static InWorldObject CurrentObject;

    private float depthIntoScene = 10;   
    private float defaultDepthIntoScene = 5;
    private float selectScale = .3f;

    public Text DescriptionText;

    private ActionPanel _actionPanel;

    #region ObjectsInLevel
    //This is the line that appears when the player hovers over an object
    public static Dictionary<InWorldObject, string> ObjectLines = new Dictionary<InWorldObject, string>() 
    {
        {InWorldObject.Null, "Object is null"},      
        {InWorldObject.AyTheTearCollector, "Ay the Tear Collector"},   
        {InWorldObject.Bart, "Bart"},      
        {InWorldObject.BennyTwospoons, "Benny Twospoons"},      
        {InWorldObject.LeonTurmeric, "Leon"},      
        {InWorldObject.MadameOpposita, "Madame Opposita"},      
        {InWorldObject.MrB, "Mr. B"},      
        {InWorldObject.Obstructor, "Mysterious Obstructor"},      
        {InWorldObject.Sentinel, "Sentinel"},      

        {InWorldObject.AysMagicDynamiteShake, "Ay's Magic Dynamite Shake"},
        {InWorldObject.AysSecretIngredients, "Ay's secret ingredients"},
        {InWorldObject.Axe, "Axe"},
        {InWorldObject.Brush, "Brush"},
        {InWorldObject.BrushWithPaint, "Paint"},
        {InWorldObject.BucketWithPaint, "Bucket with paint"},
        {InWorldObject.Carrot, "carrot"},
        {InWorldObject.ClownMask, "Nauseating clown mask"},
        {InWorldObject.ClownNose, "Clown nose"},
        {InWorldObject.CupOfCoffee, "Cup of coffee"},
        {InWorldObject.CupOfTea, "Cup of tea"},
        {InWorldObject.GalleryKey, "Big key"},
        {InWorldObject.Hammer, "Hammer"},
        {InWorldObject.MaskRemains, "Mask remains"},
        {InWorldObject.PartyHat, "Party hat"},
        {InWorldObject.Purse, "Purse"},
        {InWorldObject.RoughneckShot, "Roughneck shot"},
        {InWorldObject.Scissors, "Scissors"},
        {InWorldObject.SelfMadeMask, "Self made mask"},
        {InWorldObject.SpeakingTrumpet, "Speaking trumpet"},
        {InWorldObject.TeaLeaves, "Tea leaves"},
        {InWorldObject.GoldenScreech, "Golden screech"},

        {InWorldObject.CopperBowl, "Copper bowl"},
        {InWorldObject.Teapot, "Leon's teapot"},

        {InWorldObject.GalleryPrivateDoor, "Private door"},
        {InWorldObject.ElevatorDoor1, "Elevator door"},
        {InWorldObject.ElevatorDoor2, "Elevator door"},
        {InWorldObject.ElevatorDoor3, "Elevator door"},
        {InWorldObject.ElevatorDoor4, "Elevator door"},

        {InWorldObject.ElevatorUp, "Go up button"},
        {InWorldObject.ElevatorDown, "Go down button"},

    };

    public static Dictionary<InWorldObject, string> ObjectInteractionLines = new Dictionary<InWorldObject, string>() 
    {
        {InWorldObject.Null, "Object is null"},      
        {InWorldObject.AyTheTearCollector, "Talk to Ay the Tear Collector"},   
        {InWorldObject.Bart, "Talk to Bart"},      
        {InWorldObject.BennyTwospoons, "Talk to Benny Twospoons"},      
        {InWorldObject.LeonTurmeric, "Talk to Leon"},      
        {InWorldObject.MadameOpposita, "Talk to Madame Opposita"},      
        {InWorldObject.MrB, "Talk to Mr. B"},      
        {InWorldObject.Obstructor, "Talk to Mysterious Obstructor"},      
        {InWorldObject.Sentinel, "Talk to Sentinel"}, 

        {InWorldObject.AysMagicDynamiteShake, "Interact with Ay's Magic Dynamite Shake"},
         {InWorldObject.AysSecretIngredients, "Interact with Ay's secret ingredients"},
        {InWorldObject.Axe, "Interact with axe"},
        {InWorldObject.Brush, "Interact with brush"},
        {InWorldObject.BrushWithPaint, "Interact with brush with paint"},
        {InWorldObject.BucketWithPaint, "Interact with bucket with paint"},
        {InWorldObject.Carrot, "Interact with carrot"},
        {InWorldObject.ClownMask, "Interact with nauseating clown mask"},
        {InWorldObject.ClownNose, "Interact with clown nose"},
        {InWorldObject.CupOfCoffee, "Interact with cup of coffee"},
        {InWorldObject.CupOfTea, "Interact with cup of tea"},
        {InWorldObject.GalleryKey, "Interact with big key"},
        {InWorldObject.Hammer, "Interact with hammer"},
        {InWorldObject.MaskRemains, "Interact with mask remains"},
        {InWorldObject.PartyHat, "Interact with party hat"},
        {InWorldObject.Purse, "Interact with purse"},
        {InWorldObject.RoughneckShot, "Interact with roughneck shot"},
        {InWorldObject.Scissors, "Interact with scissors"},
        {InWorldObject.SelfMadeMask, "Interact with self made mask"},
        {InWorldObject.SpeakingTrumpet, "Interact with speaking trumpet"},
        {InWorldObject.TeaLeaves, "Interact with tea leaves"},
        {InWorldObject.GoldenScreech, "Interact with the Golden Screech"},
        
        {InWorldObject.CopperBowl, "Interact with copper bowl"},
        {InWorldObject.Teapot, "Interact with Leon's teapot"},

        {InWorldObject.GalleryPrivateDoor, "Interact with private door"},
        {InWorldObject.ElevatorDoor1, "Open elevator door"},
        {InWorldObject.ElevatorDoor2, "Open elevator door"},
        {InWorldObject.ElevatorDoor3, "Open elevator door"},
        {InWorldObject.ElevatorDoor4, "Open elevator door"},

        {InWorldObject.ElevatorUp, "Go up"},
        {InWorldObject.ElevatorDown, "Go down"},
    
};

    public static Dictionary<InWorldObject, string> ObjectInvestigationLines = new Dictionary<InWorldObject, string>() 
    {
        {InWorldObject.Null, "Object is null"},      
        {InWorldObject.AyTheTearCollector, "Investigate Ay the Tear Collector"},   
        {InWorldObject.Bart, "Investigate Bart"},      
        {InWorldObject.BennyTwospoons, "Investigate Benny Twospoons"},      
        {InWorldObject.LeonTurmeric, "Investigate Leon"},      
        {InWorldObject.MadameOpposita, "Investigate Madame Opposita"},      
        {InWorldObject.MrB, "Investigate Mr. B"},      
        {InWorldObject.Obstructor, "Investigate Mysterious Obstructor"},      
        {InWorldObject.Sentinel, "Investigate Sentinel"}, 
      
        {InWorldObject.AysMagicDynamiteShake, "Investigate Ay's Magic Dynamite Shake"},
        {InWorldObject.AysSecretIngredients, "Investigate Ay's secret ingredients"},
        {InWorldObject.Axe, "Investigate axe"},
        {InWorldObject.Brush, "Investigate brush"},
        {InWorldObject.BrushWithPaint, "Investigate brush with paint"},
        {InWorldObject.BucketWithPaint, "Investigate bucket with paint"},
        {InWorldObject.Carrot, "Investigate carrot"},
        {InWorldObject.ClownMask, "Investigate nauseating clown mask"},
        {InWorldObject.ClownNose, "Investigate clown nose"},
        {InWorldObject.CupOfCoffee, "Investigate cup of coffee"},
        {InWorldObject.CupOfTea, "Investigate cup of tea"},
        {InWorldObject.GalleryKey, "Investigate big key"},
        {InWorldObject.Hammer, "Investigate hammer"},
        {InWorldObject.MaskRemains, "Investigate mask remains"},
        {InWorldObject.PartyHat, "Investigate party hat"},
        {InWorldObject.Purse, "Investigate purse"},
        {InWorldObject.RoughneckShot, "Investigate roughneck shot"},
        {InWorldObject.Scissors, "Investigate scissors"},
        {InWorldObject.SelfMadeMask, "Investigate self made mask"},
        {InWorldObject.SpeakingTrumpet, "Investigate speaking trumpet"},
        {InWorldObject.TeaLeaves, "Investigate tea leaves"},
        {InWorldObject.GoldenScreech, "Investigate the Golden Screech"},

        {InWorldObject.CopperBowl, "Investigate copper bowl"},
        {InWorldObject.Teapot, "Investigate Leon's teapot"},

        {InWorldObject.GalleryPrivateDoor, "Investigate private door"},
        {InWorldObject.ElevatorDoor1, "Investigate elevator door"},
        {InWorldObject.ElevatorDoor2, "Investigate elevator door"},
        {InWorldObject.ElevatorDoor3, "Investigate elevator door"},
        {InWorldObject.ElevatorDoor4, "Investigate elevator door"},

        {InWorldObject.ElevatorUp, "Investigate go up button"},
        {InWorldObject.ElevatorDown, "Investigate go down button"},
    };
    #endregion

    public void Start()
    {
        if (MyObject == InWorldObject.Null)
            Debug.LogWarning("This object has no name: " + Instance.name);

        Instance = this;

        DescriptionText = GameManager.Instance.UICanvas.ObjectDescriptionText;
        _actionPanel = new ActionPanel();
    }

    public void OnMouseDown()
    {
        if (GameManager.GamePlayingMode == GameManager.GameMode.Paused) // don't show if paused.
            return;

        ActionPanel.LastHoveredObject = MyObject;

        if (UIDrawer.IsDraggingItem)
        {
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
    }

    public void OnMouseExit()
    {
        if(UIDrawer.IsDraggingItem)
        {
            DescriptionText.text = UIDrawer.DraggingItem.ItemName;
            DescriptionText.enabled = true;
        }
        else if (!MouseIsOnInvestigateButton && !MouseIsOnInteractionButton)
            GameManager.Instance.UICanvas.HideObjectDescriptionText();
    }

    public void OnMouseUp()
    {
        ActionPanel.LastHoveredObject = InWorldObject.Null;

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

        DescriptionText.enabled = true;
        GameManager.Instance.UICanvas.NewObjectDescription();

        if (ActionPanel.LastHoveredObject == CurrentObject)
            return;

        if (!MouseIsOnInteractionButton || !MouseIsOnInvestigateButton)
        {
            if(UIDrawer.IsDraggingItem)
            {
                DescriptionText.text = "Use "
                    + GameManager.Instance.MyInventory.TheDraggedItem.ItemName + " with " + ObjectLines[MyObject];
            }
            else
            {
                DescriptionText.text = ObjectLines[MyObject];
                MyConsole.WriteToConsole(ObjectLines[MyObject]);
            }
        }
    }
}
