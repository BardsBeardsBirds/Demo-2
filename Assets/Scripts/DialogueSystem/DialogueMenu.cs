using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueMenu : MonoBehaviour
{
    public static int NumberOfOptions = 4;
    public static Character Character;

    public static string[] VisibleDialogueOptions = new string[]
    {
        "option1",
        "option2",
        "option3",
        "option4",
        "option5",
    };

    public static List<int> CurrentVisibleDialogueOptionsID = new List<int>();
    public static List<int> AllDialogueOptionsID = new List<int>();

    public static void ShowDialogueOptions()
    {
        int numberOfOptions = CurrentVisibleDialogueOptionsID.Count;

        for (int i = 0; i < numberOfOptions; i++)
        {
            string goName = "DialogueOption" + (i + 1);
            GameObject dialogueOption = GameObject.Find(goName);

            dialogueOption.GetComponent<Button>().enabled = true;
            Text Optiontext = dialogueOption.GetComponentInChildren<Text>();
            Optiontext.text = VisibleDialogueOptions[i];
        }

        if (AllDialogueOptionsID.Count > numberOfOptions)
            GameManager.Instance.UICanvas.MyDialogueOptions.ShowButtons(); 
    }

    public static void HideDialogueOptions()
    {
        for (int i = 0; i < 5; i++)
        {
            string goName = "DialogueOption" + (i + 1);
            GameObject dialogueOption = GameObject.Find(goName);
     //       dialogueOption.GetComponent<Image>().enabled = false;
            dialogueOption.GetComponent<Button>().enabled = false;
            Text Optiontext = dialogueOption.GetComponentInChildren<Text>();
            Optiontext.text = "";
        }
    }

    public static void AddToDialogueOptions(int dialogueOptionID)
    {
        if (!DialogueManager.IsDialoguePassed(dialogueOptionID))
        {
        //    DialogueMenu.CurrentVisibleDialogueOptionsID.Add(dialogueOptionID);
            AllDialogueOptionsID.Add(dialogueOptionID);
            Debug.Log("Adding option: " + dialogueOptionID + ". In the full list are " + AllDialogueOptionsID.Count);
        }   
    }

    public static void FindVisibleDialogueOptions(Character character)  
    {
        Character = character;

        PickVisibleDialogueOptions();
        Debug.Log("in total in the list: " + AllDialogueOptionsID.Count + ".  ");
        for (int i = 0; i < CurrentVisibleDialogueOptionsID.Count; i++)
        {
            VisibleDialogueOptions[i] = GameManager.CharacterDialogueLists[character][CurrentVisibleDialogueOptionsID[i]].Text;
        }
    }

    public static void PickVisibleDialogueOptions()
    {
        int offset = DialogueOptions.Offset;

        //for (int i = 0; i < VisibleDialogueOptions.Length; i++)    // we pick at max 5 options to be visible
        for (int i = 0; i < AllDialogueOptionsID.Count; i++)    // we pick at max 5 options to be visible
        {
            CurrentVisibleDialogueOptionsID.Add(AllDialogueOptionsID[i + offset]);
            if (i == 4)
            {
        //        Debug.Log(i);
                return;
            }
        }
    }

    public static bool CanGoDown()
    {
        bool canGoDown = true;

        if (VisibleDialogueOptions.Length + DialogueOptions.Offset == AllDialogueOptionsID.Count)
            canGoDown = false;
        //Debug.Log("can we go down? " + canGoDown);
        return canGoDown;
    }

    public static bool CanGoUp()
    {
        bool canGoUp = true;

        if (DialogueOptions.Offset == 0)
            canGoUp = false;
        //Debug.Log("can we go up? " + canGoUp);
        return canGoUp;
    }

    public static void ClearDialogueOptionLists()
    {
        ClearVisibleOptionList();
        ClearFullOptionList();
    }

    public static void ClearVisibleOptionList()
    {
        CurrentVisibleDialogueOptionsID.Clear();
    }

    public static void ClearFullOptionList()
    {
        AllDialogueOptionsID.Clear();
    }
}

