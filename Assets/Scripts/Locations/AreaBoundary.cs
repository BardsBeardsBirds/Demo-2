using UnityEngine;
using System.Collections;

public class AreaBoundary : MonoBehaviour 
{
    public Areas Name;
    public Area ThisArea;
  //  public AudioClip AreaSoundtrack;
    public void Start() //should happen after Awake in AreaManager
    {
        switch (Name)
        {
            case Areas.Null:
                Debug.LogError("There is an area not assigned");
                break;
            case Areas.Barts_House:
                ThisArea = AreaManager.Instance.BartsHouse;
                break;
            case Areas.Citadel_of_Doubt:
                ThisArea = AreaManager.Instance.CitadelOfDoubt;
                break;
            case Areas.Gatehouse:
                ThisArea = AreaManager.Instance.Gatehouse;
                break;
            case Areas.Higher_Ground:
                ThisArea = AreaManager.Instance.HigherGround;
                break;
            case Areas.Inside_Out_Art_Gallery:
                ThisArea = AreaManager.Instance.InsideOutArtGallery;
                break;
            case Areas.Lower_Woods:
                ThisArea = AreaManager.Instance.LowerWoods;
                break;
            case Areas.Madam_Oppositas_Wagon:
                ThisArea = AreaManager.Instance.MadamOppositasWagon;
                break;
            case Areas.Modona_Badlands:
                ThisArea = AreaManager.Instance.ModonaBadlands;
                break;
            case Areas.Rocky_Heights:
                ThisArea = AreaManager.Instance.RockyHeights;
                break;
            case Areas.Squander_Lands:
                ThisArea = AreaManager.Instance.SquanderLands;
                break;
            case Areas.Tea_House_Cafe:
                ThisArea = AreaManager.Instance.TeaHouseCafe;
                break;
            case Areas.The_Two_Spoons:
                ThisArea = AreaManager.Instance.TheTwoSpoons;
                break;
            case Areas.Town:
                ThisArea = AreaManager.Instance.Town;
                break;
            case Areas.Walnuths_Wall:
                ThisArea = AreaManager.Instance.WalnuthsWall;
                break;
            default:
                Debug.LogError("There is an area not assigned");
                break;
        }
    }

    public void OnTriggerEnter () 
    {
     //   float transitionIn = AmbientSoundtracks.Instance.FindTransitionInTime(this.Name);
     //   AreaManager.Instance.StartAmbientSoundtrack(this.Name, AreaSoundtrack, transitionIn);

       // Debug.Log("We are now in: " + AreaManager.CurrentArea);
        if (AreaManager.CurrentArea != ThisArea.Name)
        {
            AreaManager.CurrentArea = ThisArea.Name;

            if (AreaNameDisplay.Instance.IsInAnimation())
            {
                AreaNameDisplay.Instance.RestartAnimation(ThisArea.StringName);
            }
            else
            {
                AreaNameDisplay.Instance.DisplayAreaName(ThisArea.StringName);
            }

        }
	}

    //private string FindName()
    //{
    //    var soundtrackName = "";

    //    if (Name == Areas.Barts_House)
    //        soundtrackName = "Crater Environment";
    //    else if (Name == Areas.Town)
    //        soundtrackName = "The Two Spoons";
    //    else
    //        MyConsole.WriteToConsole("Unknown area!");
    //    return soundtrackName;
    //}
}
