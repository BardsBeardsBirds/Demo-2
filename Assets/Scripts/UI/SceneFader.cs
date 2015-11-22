using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    private Animator _animator;
    public static bool HasLoadedGame = false;
    public int LoadingSlot;

    public bool ToBlack
    {
        get { return _animator.GetBool("ToBlack"); }
        set { _animator.SetBool("ToBlack", value); }
    }
    public bool ToAlpha
    {
        get 
        {
            return _animator.GetBool("ToAlpha"); 
        }
        set
        {
            _animator.SetBool("ToAlpha", value);
        }
    }

    public void Awake()
    {
        _animator = this.GetComponent<Animator>();
    }

    public void StartToBlack(int slotNumber)
    {
        ToBlack = true;
       LoadingSlot = slotNumber;
    }

    public void ToBlackEvents()
    {

        SaveAndLoadGame loadGame = new SaveAndLoadGame();
        loadGame.LoadGameData(LoadingSlot);
        HasLoadedGame = true;
        ToAlpha = true;
    }

    public void ToAlphaEvents()
    {

        ToBlack = false;
        CharacterControllerLogic.Instance.GoToIdleState();

    }

    public void HideFader()
    {
        ToAlpha = false;
    }
}