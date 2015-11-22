using System;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public static AreaManager Instance;
    public GameObject AmbientPlayer;
    public static Areas CurrentArea;
    public static AudioMixerGroup Mixer;

    public Area BartsHouse;
    public Area CitadelOfDoubt;
    public Area Gatehouse;
    public Area HigherGround;
    public Area InsideOutArtGallery;
    public Area LowerWoods;
    public Area MadamOppositasWagon;
    public Area ModonaBadlands;
    public Area RockyHeights;
    public Area SquanderLands;
    public Area TeaHouseCafe;
    public Area TheTwoSpoons;
    public Area Town;
    public Area WalnuthsWall;

    public List<GameObject> AmbientGOs = new List<GameObject>();

    public void Awake()
    {
        Instance = this;

        BartsHouse = new Area(Areas.Barts_House);
        CitadelOfDoubt = new Area(Areas.Citadel_of_Doubt);
        Gatehouse = new Area(Areas.Gatehouse);
        HigherGround = new Area(Areas.Higher_Ground);
        InsideOutArtGallery = new Area(Areas.Inside_Out_Art_Gallery);
        LowerWoods = new Area(Areas.Lower_Woods);
        MadamOppositasWagon = new Area(Areas.Madam_Oppositas_Wagon);
        ModonaBadlands = new Area(Areas.Modona_Badlands);
        RockyHeights = new Area(Areas.Rocky_Heights);
        SquanderLands = new Area(Areas.Squander_Lands);
        TeaHouseCafe = new Area(Areas.Tea_House_Cafe);
        TheTwoSpoons = new Area(Areas.The_Two_Spoons);
        Town = new Area(Areas.Town);
        WalnuthsWall = new Area(Areas.Walnuths_Wall);

        AmbientPlayer = GameObject.Find("AmbientPlayer");
        Mixer = GameManager.Instance.Mixer;
    }

   // public void StartAmbientSoundtrack(Areas currentArea, AudioClip audioClip, float transitionIn)
   // {
   ////     Debug.LogError("previous: " + PreviousArea + "and now: " + currentArea);
   //     if (Emmon.Instance.CurrentArea == currentArea)
   //         return;

   //     Emmon.Instance.PreviousArea = Emmon.Instance.CurrentArea;

   //     Emmon.Instance.CurrentArea = currentArea;

   //     for (int i = 0; i < AmbientPlayer.transform.childCount; i++)
   //     {
   //         GameObject go = AmbientPlayer.transform.GetChild(i).gameObject;
   //         if (go.name == Emmon.Instance.CurrentArea.ToString())
   //         {

   //             AudioMixerSnapshot snapshot = AmbientSoundtracks.Instance.FindSoundtrack(Emmon.Instance.CurrentArea);
   //             snapshot.TransitionTo(transitionIn);
   //             AudioSource audioSource = go.GetComponent<AudioSource>();
   //             audioSource.clip = audioClip;
   //             audioSource.Play();
   //             AmbientGOs.Add(go);
   //         }
   //     }
   // }
}
