using System.Collections.Generic;
using UnityEngine;

public class LoadGamePanel : MonoBehaviour
{
    public LoadGameSlot Slot1;
    public LoadGameSlot Slot2;
    public LoadGameSlot Slot3;
    public LoadGameSlot Slot4;

    public List<LoadGameSlot> GameSlots = new List<LoadGameSlot>();
    
    private Animator _animator;
    
    public bool PanelOpen
    {
        get { return _animator.GetBool("IsOpen"); }
        set { _animator.SetBool("IsOpen", value); }
    }

    public void Awake()
    {
        _animator = GetComponent<Animator>();

        GameSlots.Add(Slot1);
        GameSlots.Add(Slot2);
        GameSlots.Add(Slot3);
        GameSlots.Add(Slot4);

        for (int i = 0; i < GameSlots.Count; i++)
        {
            if (GameSlots[i] == null)
                Debug.LogError("Cannot find load slot " + (i + 1));
        }
    }
}

