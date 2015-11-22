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


    public int Rupee;

    public DateTime SaveDateTime;

    public Areas CurrentArea;

/// <summary>
/// Events
/// </summary>
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

  //  public string SaveDate = DateTime.Now.ToString("MM-dd-yyyy");
  //  public string SaveTime = DateTime.Now.ToString("HH:mm");

    /// <summary>
    /// Inventory Items
    /// </summary>
    /// 

    //unique  
    public int Axe;
    public int AysSecretIngredients;
    public int BookOfMusicalWildlife;
    public int Brush;
    public int BrushWithPaint;
    public int BucketWithPaint;
    public int ClownMask;
    public int ClownNose;
    public int GalleryKey;
    public int GoldenScreech;
    public int Hammer;
    public int MaskRemains;
    public int PartyHat;
    public int Purse;
    public int Scissors;
    public int SelfMadeMask;
    public int SpeakingTrumpet;
    public int TeaLeaves;
        //consumable
    public int AysMagicDynamiteShake;
    public int Carrot;
    public int CupOfCoffee;
    public int CupOfTea;
    public int RoughneckShot;


}
