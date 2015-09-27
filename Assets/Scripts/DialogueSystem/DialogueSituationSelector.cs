using System;
using UnityEngine;


public class DialogueSituationSelector
{
    public static int CharacterSituation = 1;

    public static void LoadAySituations()
    {
        CharacterSituation = 1;

        if (WorldEvents.SpokeToAy)
            CharacterSituation = 2;
        if (WorldEvents.EndCelebration)
            CharacterSituation = 3;

        AyTheTearCollector.CharacterSituation = CharacterSituation;
        AyTheTearCollector.Instance.DialogueLineNumberToSituation(CharacterSituation);
        DialogueMenu.ShowDialogueOptions();
    }

    public static void LoadBartSituations()
    {
        CharacterSituation = 1;

        if (WorldEvents.SpokeToMrB)
            CharacterSituation = 2;

        BartTumblescream.CharacterSituation = CharacterSituation;
        BartTumblescream.Instance.DialogueLineNumberToSituation(CharacterSituation);
        DialogueMenu.ShowDialogueOptions();
    }

    public static void LoadBennyTwospoonsSituations()
    {
        CharacterSituation = 1;
        if (WorldEvents.EndCelebration)
            CharacterSituation = 2;

        BennyTwospoons.CharacterSituation = CharacterSituation;
        BennyTwospoons.Instance.DialogueLineNumberToSituation(CharacterSituation);   
        DialogueMenu.ShowDialogueOptions();
    }

    public static void LoadLeonTurmericSituations()
    {
        CharacterSituation = 1;
        if (WorldEvents.EndCelebration)
            CharacterSituation = 2;

        LeonTurmeric.CharacterSituation = CharacterSituation;
        LeonTurmeric.Instance.DialogueLineNumberToSituation(CharacterSituation);   
        DialogueMenu.ShowDialogueOptions();
    }

    public static void LoadMadameOppositaSituations()
    {
        CharacterSituation = 1;
        if (WorldEvents.SpokeToMrB && WorldEvents.LookingForGalleryVisitors)
            CharacterSituation = 2;
        if (WorldEvents.SpokeToMrB && !WorldEvents.LookingForGalleryVisitors)
            CharacterSituation = 3;
        if (WorldEvents.EndCelebration)
            CharacterSituation = 4;
        Debug.Log(CharacterSituation);
        MadameOpposita.CharacterSituation = CharacterSituation;
        MadameOpposita.Instance.DialogueLineNumberToSituation(CharacterSituation);
        DialogueMenu.ShowDialogueOptions();
    }

    public static void LoadMrBSituations()
    {
        CharacterSituation = 1;
        if (WorldEvents.SpokeToMrB)
            CharacterSituation = 2;
        if (WorldEvents.EndCelebration)
            CharacterSituation = 3;
        MrB.CharacterSituation = CharacterSituation;
        MrB.Instance.DialogueLineNumberToSituation(CharacterSituation);
        DialogueMenu.ShowDialogueOptions();
    }
    public static void LoadObstructorSituations()
    {
        CharacterSituation = 1;

        Obstructor.CharacterSituation = CharacterSituation;
        Obstructor.Instance.DialogueLineNumberToSituation(CharacterSituation);
        DialogueMenu.ShowDialogueOptions();
    }
    public static void LoadSentinelSituations()
    {
        CharacterSituation = 1;
        if (WorldEvents.EndCelebration)
            CharacterSituation = 2;
        Sentinel.CharacterSituation = CharacterSituation;
        Sentinel.Instance.DialogueLineNumberToSituation(CharacterSituation);
        DialogueMenu.ShowDialogueOptions();
    }
}


