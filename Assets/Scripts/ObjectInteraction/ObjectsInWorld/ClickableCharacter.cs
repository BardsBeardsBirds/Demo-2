using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ClickableCharacter : ClickableObject 
{
    public Character MyCharacter;

    public static Dictionary<Character, InWorldObject> CharacterObjects = new Dictionary<Character, InWorldObject>() 
    {
            {Character.Null, InWorldObject.Null},      
            {Character.Ay, InWorldObject.AyTheTearCollector},      
            {Character.Bart, InWorldObject.Bart},      
            {Character.Benny, InWorldObject.BennyTwospoons},      
            {Character.Leon, InWorldObject.LeonTurmeric},      
            {Character.MrB, InWorldObject.MrB},      
            {Character.Obstructor, InWorldObject.Obstructor},      
            {Character.Opposita, InWorldObject.MadameOpposita},      
            {Character.Sentinel, InWorldObject.Sentinel},      
    };

    public void Start()
    {
        if (MyCharacter == Character.Null)
            Debug.LogWarning("This Character has no name: " + Instance.name);

        MyObject = CharacterObjects[MyCharacter];

        base.Start();  
    }
}
