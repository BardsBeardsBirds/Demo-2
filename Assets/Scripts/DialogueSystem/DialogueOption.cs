using System;
using UnityEngine;

public class DialogueOption : MonoBehaviour
{
    DialogueOption Instance;

    public void Awake()
    {
        Instance = this;
    }

    public void ChooseDialogueOption()
    {
        GameManager.Instance.UICanvas.MyDialogueOptions.HideButtons();        
        string lastCharacter = Instance.gameObject.name.Substring(Instance.gameObject.name.Length - 1, 1);
        int i = Convert.ToInt32(lastCharacter);
        Debug.LogWarning("we chose option number " + lastCharacter + ": " + DialogueMenu.CurrentVisibleDialogueOptionsID[i - 1]);

        DialoguePlayback.Instance.PlaybackDialogue(DialogueMenu.CurrentVisibleDialogueOptionsID[i - 1]);   //the lines dispayed

        DialogueOptions.Offset = 0;
    }
}

