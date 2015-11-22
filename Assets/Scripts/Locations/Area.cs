using UnityEngine;
using System.Collections;

public class Area
{
    private Areas _name;
    private string _stringName;

    public AudioClip AreaSoundtrack;

    public Areas Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string StringName
    {
        get { return _stringName; }
        set { _stringName = value; }
    }

    public Area(Areas name)
    {
        _name = name;
        _stringName = name.ToString();

        switch (name)
        {
            case Areas.Null:
                break;
            case Areas.Barts_House:
               // AreaSoundtrack = Resources.Load("Audio/Music/" + FindName()) as AudioClip;
                break;
            case Areas.Citadel_of_Doubt:
                break;
            case Areas.Gatehouse:
                break;
            case Areas.Higher_Ground:
                break;
            case Areas.Inside_Out_Art_Gallery:
                break;
            case Areas.Lower_Woods:
                break;
            case Areas.Madam_Oppositas_Wagon:
                break;
            case Areas.Modona_Badlands:
                break;
            case Areas.Rocky_Heights:
                break;
            case Areas.Squander_Lands:
                break;
            case Areas.Tea_House_Cafe:
                break;
            case Areas.The_Two_Spoons:
                break;
            case Areas.Town:
                break;
            case Areas.Walnuths_Wall:
                break;
            default:
                break;
        }

    }
}