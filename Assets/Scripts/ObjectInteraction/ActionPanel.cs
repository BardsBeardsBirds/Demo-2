using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionPanel
{
    public ItemDatabase Database;

    private GameObject _investigateButton;
    private GameObject _interactionButton;
    private GameObject _actionPanelGO;

    public static Item ThisItem;
    public static bool IsInInventory = false;

    public static InWorldObject LastHoveredObject;

    public void MoveActionPanelToClickedObject(bool isInInventory) // move action panel
    {
        if (CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.Talking || CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.TalkingLastLine)
            return;

        DialogueManager.ThisDialogueType = DialogueType.None;

        if (GameObject.Find("InteractionButton") != null)
            return;

        if (!isInInventory)
            _actionPanelGO = GameObject.Find("ActionPanelObjects");
        else
            _actionPanelGO = GameObject.Find("ActionPanelInventory");

        SetUpActionPanel();
    }

    public void PlayActionPanelForClickedObject(InWorldObject naam, Transform trans)   //Objects in world.
    {
        if (ClickableObject.MouseIsOnInvestigateButton)
            InvestigateObject(naam);
        else if (ClickableObject.MouseIsOnInteractionButton)
        {
            bool inRange = CalculateDistanceWitNPC(naam, trans);
            if (inRange)
                InteractWithObject(naam);
            else
            {
                DialogueManager.ThisDialogueType = DialogueType.ObjectInteraction;  ///??? not in range?
                DialoguePlayback.Instance.PlaybackCommentary();
            }
        }

        GameManager.Destroy("InteractionButton");
        GameManager.Destroy("InvestigateButton");

        ClickableObject.MouseIsOnInvestigateButton = false;
        ClickableObject.MouseIsOnInteractionButton = false;
    }

    public void PlayActionPanelForClickedObject(Item item, int slotNumber)  //Inventory
    {
        if (ClickableObject.MouseIsOnInvestigateButton)
            InvestigateItem(item);
        else if (ClickableObject.MouseIsOnInteractionButton)
        {
            InteractWithItem(item, slotNumber);
        }

        GameManager.Destroy("InteractionButton");
        GameManager.Destroy("InvestigateButton");

        ClickableObject.MouseIsOnInvestigateButton = false;
        ClickableObject.MouseIsOnInteractionButton = false;
    }

    public static void HideActionPanel()
    {
        GameManager.Destroy("InteractionButton");
        GameManager.Destroy("InvestigateButton");

        ClickableObject.MouseIsOnInvestigateButton = false;
        ClickableObject.MouseIsOnInteractionButton = false;
    }

    public void InvestigateObject(InWorldObject naam)//items in the world
    {
        DialogueManager.ThisDialogueType = DialogueType.ObjectInvestigation;
        MyConsole.WriteToConsole("Start Investigation of " + ClickableObject.ObjectLines[naam]);
        DialoguePlayback.Instance.PlaybackCommentary(DialogueType.ObjectInvestigation, naam);
    }

    public void InteractWithObject(InWorldObject naam) //items in the world
    {
        DialogueManager.ThisDialogueType = DialogueType.ObjectInteraction;
        MyConsole.WriteToConsole("Start Interaction with " + ClickableObject.ObjectLines[naam]);
        DialoguePlayback.Instance.PlaybackCommentary(DialogueType.ObjectInteraction, naam); //SOUND
    }

    public void InvestigateItem(Item item)//items in the inventory
    {
        DialogueManager.ThisDialogueType = DialogueType.InventoryInvestigation;
        MyConsole.WriteToConsole("Start Investigation of " + item.ItemName);
        DialoguePlayback.Instance.PlaybackCommentary(DialogueType.InventoryInvestigation, item);
        GameManager.Instance.UICanvas.HideObjectDescriptionText();
    }

    public void InteractWithItem(Item item, int SlotNumber) //items in the inventory
    {
        DialogueManager.ThisDialogueType = DialogueType.InventoryInteraction;
        MyConsole.WriteToConsole("Start Interaction with " + item.ItemName);
        if(item.Class == ItemClass.Consumable)
        {
            //Consume the item
            GameManager.Instance.MyInventory.Items[SlotNumber].ItemAmount--;
        }

        DialoguePlayback.Instance.PlaybackCommentary(DialogueType.InventoryInteraction, item); //SOUND
        GameManager.Instance.UICanvas.HideObjectDescriptionText();
    }

    public bool CalculateDistanceWitNPC(InWorldObject naam, Transform trans)
    {
    //    float distance = Vector3.Distance(trans.position, GameManager.Player.transform.position);
       // Debug.Log("Distance: " + distance);

        //if (naam == ObjectsInLevel.BennyTwospoons || naam == ObjectsInLevel.AyTheTearCollector || naam == ObjectsInLevel.Sentinel)
       //     if (distance > 8)
        //        return false;

        return true;
    }

    public static void ShowHoverInteractionLine(DialogueType dialogueType)
    {
        if (dialogueType == DialogueType.ObjectInteraction)
        {
            GameManager.Instance.UICanvas.ObjectDescriptionText.text = ClickableObject.ObjectInteractionLines[ClickableObject.CurrentObject];
            GameManager.Instance.UICanvas.NewObjectDescription();
        }
        else
        {
            int id = InventoryCommentary.FindInteractionHoverLines(ThisItem);
            Debug.Log("Hover INTERACTION: " + id + " " + dialogueType);

            GameManager.Instance.UICanvas.ObjectDescriptionText.text = GameManager.InventoryInteractionDialogue[id].Text;

            GameManager.Instance.UICanvas.NewObjectDescription();
        }
    }

    public static void ShowHoverInvestigationLine(DialogueType dialogueType)
    {
        if (dialogueType == DialogueType.ObjectInvestigation)
        {
            GameManager.Instance.UICanvas.ObjectDescriptionText.text = ClickableObject.ObjectInvestigationLines[ClickableObject.CurrentObject];
            GameManager.Instance.UICanvas.NewObjectDescription();
        }
        else        //in inventory
        {
            int id = InventoryCommentary.FindInvestigationHoverLines(ThisItem);
            Debug.Log("Hover INVESTIGATION: " + id + " " + dialogueType);
     //       GameManager.Instance.UICanvas.ObjectDescriptionText.text = "Implement later";
            GameManager.Instance.UICanvas.ObjectDescriptionText.text = GameManager.InventoryInvestigationDialogue[id].Text;

            GameManager.Instance.UICanvas.NewObjectDescription();
        }
    }

    private void SetUpActionPanel()
    {
        _interactionButton = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI/InteractionButton")) as GameObject;
        _interactionButton.gameObject.name = "InteractionButton";
        _interactionButton.transform.SetParent(_actionPanelGO.transform);
        _interactionButton.transform.position = new Vector3(Input.mousePosition.x + 22, Input.mousePosition.y + 22, 0);

        _investigateButton = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI/InvestigateButton")) as GameObject;
        _investigateButton.gameObject.name = "InvestigateButton";
        _investigateButton.transform.SetParent(_actionPanelGO.transform);
        _investigateButton.transform.position = new Vector3(Input.mousePosition.x - 22, Input.mousePosition.y - 22, 0);
    }
}

