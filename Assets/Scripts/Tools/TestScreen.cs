using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TestScreen : MonoBehaviour 
{
    public static TestScreen Instance;

    private static ItemDatabase _itemDatabase;
    public InputField InputIDField;
    public InputField InputRupeeField;
    public InputField InputCharacterSituationField;

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
    public Button OpenedGate;


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

    public void ChangeRupee()
    {
        int rupee = 0;
        int.TryParse(InputRupeeField.text, out rupee);
        GameManager.Instance.OverrideMoney(rupee);
        InputRupeeField.text = "";
    }

    public void WhatDialoguesDidWePass()
    {
        for (int i = 0; i < DialogueManager.PassedDialogueLines.Count; i++)
        {
            Debug.Log(DialogueManager.PassedDialogueLines[i]);
        }
    }

    public void CharacterPosition()
    {
        int situation = 0;
        int.TryParse(InputCharacterSituationField.text, out situation);

        if (situation == 1)
        {
            GameManager.NPCs[Character.Ay].parent.position = new Vector3(-110.95f, 95.68f, 6.05f);
            GameManager.NPCs[Character.Bart].parent.position = new Vector3(-61.43f, 111.53f, -4.36f);
            GameManager.NPCs[Character.Benny].parent.position = new Vector3(-60.89f, 100f, 54.03f);
            GameManager.NPCs[Character.Leon].parent.position = new Vector3(-26.53f, 102.02f, 44.62f);
            GameManager.NPCs[Character.MrB].parent.position = new Vector3(-32.67f, 102.01f, 40.47f);
            GameManager.NPCs[Character.Obstructor].parent.position = new Vector3(52.18f, 106.18f, -15.78f);
            GameManager.NPCs[Character.Opposita].parent.position = new Vector3(-30.7f, 120.17f, -81.66f);
            GameManager.NPCs[Character.Sentinel].parent.position = new Vector3(-73.44f, 99.27f, 56.84f);
        }
        else if (situation == 2)
        {
            GameManager.NPCs[Character.Ay].parent.position = new Vector3(-36.8f, 100f, 213.16f);
            GameManager.NPCs[Character.Bart].parent.position = new Vector3(-17.12f, 100.75f, 209.25f);
            GameManager.NPCs[Character.Benny].parent.position = new Vector3(-22.4f, 100f, 205.32f);
            GameManager.NPCs[Character.Leon].parent.position = new Vector3(-26.28f, 100f, 205.55f);
            GameManager.NPCs[Character.MrB].parent.position = new Vector3(-33.75f, 100f, 207.15f);
            GameManager.NPCs[Character.Obstructor].parent.position = new Vector3(-19.72f, 100.75f, 206.91f);
            GameManager.NPCs[Character.Opposita].parent.position = new Vector3(-29.71f, 100f, 205.73f);
            GameManager.NPCs[Character.Sentinel].parent.position = new Vector3(-36.53f, 100f, 209.82f);
        }
        else
            Debug.LogWarning("this character situation does not exist: " + situation);

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

    public void DoOpenGate()
    {
        WorldEvents.OpenedGate = (WorldEvents.OpenedGate == true) ? false : true;
        Debug.Log("Did we open the gate? " + WorldEvents.OpenedGate);
        ChangeCheckmark(OpenedGate, WorldEvents.OpenedGate);

        InGameObjectManager.Instance.GateDoor.OpenGateDoor();

        WorldEvents.PassedIntroduction = true;
        ChangeCheckmark(PassedIntroduction, WorldEvents.PassedIntroduction);

        WorldEvents.SpokeToObstructor = true;
        ChangeCheckmark(SpokeToObstructor, WorldEvents.SpokeToObstructor);

        WorldEvents.SpokeToMrB = true;
        ChangeCheckmark(SpokeToMrB, WorldEvents.SpokeToMrB);

        WorldEvents.KnowsWhatSacrificeIs = true;
        ChangeCheckmark(KnowsWhatSacrificeIs, WorldEvents.KnowsWhatSacrificeIs);

        WorldEvents.IsAfterGoldenScreech = true;
        ChangeCheckmark(SpokeToMrB, WorldEvents.IsAfterGoldenScreech);

        WorldEvents.BlewUpMisterB = true;
        ChangeCheckmark(BlewUpMisterB, WorldEvents.BlewUpMisterB);
    }

    public void ChangeCheckmark(Button button, bool isEventTrue)
    {
        if(isEventTrue)
            button.GetComponentInChildren<Text>().text = "X";
        else
            button.GetComponentInChildren<Text>().text = " ";
    }
}
