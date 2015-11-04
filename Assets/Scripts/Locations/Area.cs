using UnityEngine;
using System.Collections;

public class Area : MonoBehaviour 
{
    public Area Instance;
    public Areas Name;
    public AudioClip AreaSoundtrack;
    public void Awake()
    {
        Instance = this;
        if (Name == Areas.Null)
            Debug.LogError("There is an area not assigned");

        AreaSoundtrack = Resources.Load("Audio/Music/" + FindName()) as AudioClip;
    }

    public void OnTriggerEnter () 
    {
     //   float transitionIn = AmbientSoundtracks.Instance.FindTransitionInTime(this.Name);
     //   AreaManager.Instance.StartAmbientSoundtrack(this.Name, AreaSoundtrack, transitionIn);

       // Debug.Log("We are now in: " + AreaManager.CurrentArea);
        if (AreaManager.CurrentArea != Name)
        {
            AreaManager.CurrentArea = Name;

            if (AreaNameDisplay.Instance.IsInAnimation())
            {
                AreaNameDisplay.Instance.RestartAnimation(Name.ToString());
            }
            else
            {
                AreaNameDisplay.Instance.DisplayAreaName(Name.ToString());
            }

        }

        if (AreaSoundtrack == null)
        {
            MyConsole.WriteToConsole("This area has no soundtrack.");
            return;
        }

        if (Name == Areas.The_Two_Spoons)
        { }

        if (Name == Areas.Town)
        {
        }

	}

    private string FindName()
    {
        var soundtrackName = "";

        if (Name == Areas.Barts_House)
            soundtrackName = "Crater Environment";
        else if (Name == Areas.Town)
            soundtrackName = "The Two Spoons";
        else
            MyConsole.WriteToConsole("Unknown area!");
        return soundtrackName;
    }
}
