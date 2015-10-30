using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveGameData
{
    public bool IsThisANewGame;

    public int SavesNoSlot1;
    public int SavesNoSlot2;
    public int SavesNoSlot3;
    public int SavesNoSlot4;




    public bool EndCelebration;

    //spoke to characters
    public bool PassedIntroduction;
    public bool SpokeToAy;
    public bool SpokeToMrB;
    public bool SpokeToObstructor;
    public bool SpokeToOpposita;

    //after golden screech
    public bool IsAfterGoldenScreech;
    public bool NeedsToKnowWhatSacrificeIs;
    public bool KnowsWhatSacrificeIs;

    public bool AskedAyAboutGallery;

    //opposita and getting the gallery key
    public bool BlewUpMisterB;
    public bool OppositaIsCrying;
    public bool OppositaRevealedScissors;

    //gallery
    public bool LookingForGalleryVisitors;
    public int PeopleNotGoingToGallery;

    public bool OpenedGate;

    //Side Quests
    public bool DecipheredSentinelsMessage;

    //Items
    public bool ReceivedBookOfMusicalWildlife;
    
    public int Rupee;

    public DateTime SaveDateTime;
  //  public string SaveDate = DateTime.Now.ToString("MM-dd-yyyy");
  //  public string SaveTime = DateTime.Now.ToString("HH:mm");
}
