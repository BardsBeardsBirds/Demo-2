using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestScreen : MonoBehaviour 
{
    public static TestScreen Instance;

    private static ItemDatabase _itemDatabase;
    public InputField InputIDField;

    public Button PassedIntroduction;
    public Button EndCelebration;
    public Button SpokeToAy;
    public Button SpokeToMrB;
    public Button SpokeToObstructor;
    public Button SpokeToOpposita;
    public Button LookingForGalleryVisitors;
    public Button IsAfterGoldenScreech;
    public Button NeedsToKnowWhatSacrificeIs;
    public Button KnowsWhatSacrificeIs;
    public Button BlewUpMisterB;


    private void Start()
    {
        Instance = this;

        _itemDatabase = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        if(InputIDField == null)
        {
            Debug.LogWarning("Please assign the InputIDField for the test screen");
        }
    }

    public void AddItemByID()
    {
        int itemID = 0;
        int.TryParse(InputIDField.text, out itemID);

        Debug.Log("Try to add " + itemID);
        Item item = null;

        for (int i = 0; i < _itemDatabase.Items.Count; i++)
        {
            if (_itemDatabase.Items[i].ID == itemID)
            {
                item = _itemDatabase.Items[i];
                ItemManager.AddItem(item.IType);
                InputIDField.text = "";
                return;
            }
        }

        Debug.LogWarning("could not add " + InputIDField.text);
    }

    public void WhatDialoguesDidWePass()
    {
        for (int i = 0; i < DialogueManager.PassedDialogueLines.Count; i++)
        {
            Debug.Log(DialogueManager.PassedDialogueLines[i]);
        }
    }

    public void DoPassedIntroduction()
    {
        WorldEvents.PassedIntroduction = (WorldEvents.PassedIntroduction == true) ? false : true;
        Debug.Log("Did we pass the intruction?: " + WorldEvents.PassedIntroduction);
        ChangeCheckmark(PassedIntroduction, WorldEvents.PassedIntroduction);
    }

    public void DoEndCelebration()
    {
        WorldEvents.EndCelebration = (WorldEvents.EndCelebration == true) ? false : true;
        Debug.Log("End celebration is now: " + WorldEvents.EndCelebration);
        ChangeCheckmark(EndCelebration, WorldEvents.EndCelebration);

        WorldEvents.PassedIntroduction = true;
        ChangeCheckmark(PassedIntroduction, WorldEvents.PassedIntroduction);
    }

    public void DoSpokeToAy()
    {
        WorldEvents.SpokeToAy = (WorldEvents.SpokeToAy == true) ? false : true;
        Debug.Log("Spoke to Ay is now: " + WorldEvents.SpokeToAy);
        ChangeCheckmark(SpokeToAy, WorldEvents.SpokeToAy);

        WorldEvents.PassedIntroduction = true;
        ChangeCheckmark(PassedIntroduction, WorldEvents.PassedIntroduction);
    }

    public void DoSpokeToMrB()
    {
        WorldEvents.SpokeToMrB = (WorldEvents.SpokeToMrB == true) ? false : true;
        Debug.Log("Spoke to Mr B. is now: " + WorldEvents.SpokeToMrB);
        ChangeCheckmark(SpokeToMrB, WorldEvents.SpokeToMrB);

        WorldEvents.PassedIntroduction = true;
        ChangeCheckmark(PassedIntroduction, WorldEvents.PassedIntroduction);
    }

    public void DoSpokeToObstructor()
    {
        WorldEvents.SpokeToObstructor = (WorldEvents.SpokeToObstructor == true) ? false : true;
        Debug.Log("Spoke to Obstructor is now: " + WorldEvents.SpokeToObstructor);
        ChangeCheckmark(SpokeToObstructor, WorldEvents.SpokeToObstructor);

        WorldEvents.PassedIntroduction = true;
        ChangeCheckmark(PassedIntroduction, WorldEvents.PassedIntroduction);
    }

    public void DoSpokeToOpposita()
    {
        WorldEvents.SpokeToOpposita = (WorldEvents.SpokeToOpposita == true) ? false : true;
        Debug.Log("Spoke to Opposita is now: " + WorldEvents.SpokeToOpposita);
        ChangeCheckmark(SpokeToOpposita, WorldEvents.SpokeToOpposita);

        WorldEvents.PassedIntroduction = true;
        ChangeCheckmark(PassedIntroduction, WorldEvents.PassedIntroduction);
    }

    public void DoLookingForGalleryVisitors()
    {
        WorldEvents.LookingForGalleryVisitors = (WorldEvents.LookingForGalleryVisitors == true) ? false : true;
        Debug.Log("Looking for gallery visitors? " + WorldEvents.LookingForGalleryVisitors);
        ChangeCheckmark(LookingForGalleryVisitors, WorldEvents.LookingForGalleryVisitors);

        WorldEvents.PassedIntroduction = true;
        ChangeCheckmark(PassedIntroduction, WorldEvents.PassedIntroduction);

        WorldEvents.SpokeToMrB = true;
        ChangeCheckmark(SpokeToMrB, WorldEvents.SpokeToMrB);
    }

    public void DoIsAfterGoldenScreech()
    {
        WorldEvents.IsAfterGoldenScreech = (WorldEvents.IsAfterGoldenScreech == true) ? false : true;
        Debug.Log("Are we after the Goden Screech? " + WorldEvents.IsAfterGoldenScreech);
        ChangeCheckmark(IsAfterGoldenScreech, WorldEvents.IsAfterGoldenScreech);

        WorldEvents.PassedIntroduction = true;
        ChangeCheckmark(PassedIntroduction, WorldEvents.PassedIntroduction);

        WorldEvents.SpokeToMrB = true;
        ChangeCheckmark(SpokeToMrB, WorldEvents.SpokeToMrB);

        WorldEvents.LookingForGalleryVisitors = false;
        ChangeCheckmark(LookingForGalleryVisitors, WorldEvents.LookingForGalleryVisitors);
    }

    public void DoNeedsToKnowWhatSacrificeIs()
    {
        WorldEvents.NeedsToKnowWhatSacrificeIs = (WorldEvents.NeedsToKnowWhatSacrificeIs == true) ? false : true;
        Debug.Log("Are we trying to find out what the sacrifice is? " + WorldEvents.NeedsToKnowWhatSacrificeIs);
        ChangeCheckmark(NeedsToKnowWhatSacrificeIs, WorldEvents.NeedsToKnowWhatSacrificeIs);

        WorldEvents.PassedIntroduction = true;
        ChangeCheckmark(PassedIntroduction, WorldEvents.PassedIntroduction);

        WorldEvents.SpokeToObstructor = true;
        ChangeCheckmark(SpokeToObstructor, WorldEvents.SpokeToObstructor);

        WorldEvents.SpokeToMrB = true;
        ChangeCheckmark(SpokeToMrB, WorldEvents.SpokeToMrB);

        WorldEvents.LookingForGalleryVisitors = false;
        ChangeCheckmark(LookingForGalleryVisitors, WorldEvents.LookingForGalleryVisitors);
    }

    public void DoKnowsWhatSacrificeIs()
    {
        WorldEvents.KnowsWhatSacrificeIs = (WorldEvents.KnowsWhatSacrificeIs == true) ? false : true;
        Debug.Log("Do we know what the sacrifice is? " + WorldEvents.KnowsWhatSacrificeIs);
        ChangeCheckmark(KnowsWhatSacrificeIs, WorldEvents.KnowsWhatSacrificeIs);

        WorldEvents.PassedIntroduction = true;
        ChangeCheckmark(PassedIntroduction, WorldEvents.PassedIntroduction);

        WorldEvents.SpokeToObstructor = true;
        ChangeCheckmark(SpokeToObstructor, WorldEvents.SpokeToObstructor);

        WorldEvents.SpokeToMrB = true;
        ChangeCheckmark(SpokeToMrB, WorldEvents.SpokeToMrB);

        WorldEvents.LookingForGalleryVisitors = false;
        ChangeCheckmark(LookingForGalleryVisitors, WorldEvents.LookingForGalleryVisitors);
    }

    public void DoBlewUpMisterB()
    {
        WorldEvents.BlewUpMisterB = (WorldEvents.BlewUpMisterB == true) ? false : true;
        Debug.Log("Did we blow up Mister B with the Dynamite Shake? " + WorldEvents.BlewUpMisterB);
        ChangeCheckmark(BlewUpMisterB, WorldEvents.BlewUpMisterB);

        WorldEvents.PassedIntroduction = true;
        ChangeCheckmark(PassedIntroduction, WorldEvents.PassedIntroduction);

        WorldEvents.SpokeToMrB = true;
        ChangeCheckmark(SpokeToMrB, WorldEvents.SpokeToMrB);

        InGameObjectManager.Instance.ItemEnablerGO.EnableItem(ItemType.Purse);
        InGameObjectManager.Instance.ItemEnablerGO.EnableItem(ItemType.GalleryKey);
    }

    public void ChangeCheckmark(Button button, bool isEventTrue)
    {
        if(isEventTrue)
            button.GetComponentInChildren<Text>().text = "X";
        else
            button.GetComponentInChildren<Text>().text = " ";
    }
}
