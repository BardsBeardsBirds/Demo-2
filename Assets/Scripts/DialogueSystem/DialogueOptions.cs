using System;
using UnityEngine;

public class DialogueOptions : MonoBehaviour
{
    DialogueOptions Instance;
    public static int Offset;

    public GameObject DownButton;
    public GameObject UpButton;

    public void Awake()
    {
        Offset = 0;
        Instance = this;

        if (DownButton == null)
            Debug.LogError("Please assign the down button");

        if (UpButton == null)
            Debug.LogError("Please assign the up button");
    }

    public void ShowButtons()
    {
        if (DialogueMenu.CanGoUp())
            UpButton.SetActive(true);
        else
            UpButton.SetActive(false);

        if (DialogueMenu.CanGoDown())
            DownButton.SetActive(true);
        else
            DownButton.SetActive(false);
    }

    public void HideButtons()
    {
        UpButton.SetActive(false);
        DownButton.SetActive(false);
    }

    public void Up()
    {
        Offset--;
        DialogueMenu.ClearVisibleOptionList();
        DialogueMenu.FindVisibleDialogueOptions(DialogueMenu.Character);
        DialogueMenu.ShowDialogueOptions();
    }

    public void Down()
    {
        Offset++;
        DialogueMenu.ClearVisibleOptionList();
        DialogueMenu.FindVisibleDialogueOptions(DialogueMenu.Character);
        DialogueMenu.ShowDialogueOptions();
    }
}