using System.Collections.Generic;
using UnityEngine;

public class SaveGamePanel : MonoBehaviour
{
    public SaveGameSlot Slot1;
    public SaveGameSlot Slot2;
    public SaveGameSlot Slot3;
    public SaveGameSlot Slot4;

    public List<SaveGameSlot> GameSlots = new List<SaveGameSlot>();

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

