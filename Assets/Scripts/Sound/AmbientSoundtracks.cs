﻿using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class AmbientSoundtracks : MonoBehaviour
{
    public static AmbientSoundtracks Instance;
    public AudioMixerSnapshot InTheTwoSpoons;

    public float bpm = 60;

    private float _transitionIn;
    private float _transitionOut;
    private float _quarterNote;

    public Dictionary<Areas, AudioMixerSnapshot> AmbientSoundtrackClips = new Dictionary<Areas, AudioMixerSnapshot>()
    {
    };

    public void Start()
    {
        Instance = GameObject.Find("AmbientPlayer").GetComponent<AmbientSoundtracks>(); 
        _quarterNote = 60 / bpm;
        _transitionIn = _quarterNote * 5;
        _transitionOut = _quarterNote * 5;

        AmbientSoundtrackClips.Add(Areas.The_Two_Spoons, InTheTwoSpoons);
    }

    public AudioMixerSnapshot FindSoundtrack(Areas currentArea)
    {
        AudioMixerSnapshot snapshot = AmbientSoundtrackClips[currentArea];

        return snapshot;
    }

    public float FindTransitionInTime(Areas currentArea)
    {
        if (currentArea == Areas.The_Two_Spoons)
            _transitionIn = _quarterNote;
        else
            _transitionIn = _quarterNote * 5;
        return _transitionIn;
    }

    public float FindTransitionOutTime(Areas currentArea)
    {
        if (currentArea == Areas.The_Two_Spoons)
            _transitionOut = _quarterNote;
        else
            _transitionOut = _quarterNote * 5;

        return _transitionOut;
    }
}


