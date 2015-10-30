using System.Collections.Generic;

public static class WorldEvents
{
  //  public static int[] SavedOnNoSlots = new int[4];
    public static int SavedOnSlot1 = -1;
    public static int SavedOnSlot2 = -1;
    public static int SavedOnSlot3 = -1;
    public static int SavedOnSlot4 = -1;

    public static bool EndCelebration = false;

    //spoke to characters
    public static bool PassedIntroduction = false;
    public static bool SpokeToAy = false;
    public static bool SpokeToMrB = false;
    public static bool SpokeToObstructor = false;
    public static bool SpokeToOpposita = false;

    //after golden screech
    public static bool IsAfterGoldenScreech = false;
    public static bool NeedsToKnowWhatSacrificeIs = false;
    public static bool KnowsWhatSacrificeIs = false;


    //opposita and getting the gallery key
    public static bool BlewUpMisterB = false;
    public static bool OppositaIsCrying = false;
    public static bool OppositaRevealedScissors = false;

    //gallery
    public static bool LookingForGalleryVisitors = false;
    public static int PeopleNotGoingToGallery = 0;

    public static bool OpenedGate = false;

    public static bool AskedAyAboutGallery = false;

    //Side Quests
    public static bool DecipheredSentinelsMessage = false;
    
    //Items
    public static bool ReceivedBookOfMusicalWildlife = false;

}