using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;
    public bool DialogueIsPlaying = false;
    private DialogueTimer _dialogueTimer;
    private ObjectInteractionTimer _objectInteractionTimer;

    public void Awake()
    {
        Instance = this;
        _dialogueTimer = new DialogueTimer();
        _objectInteractionTimer = new ObjectInteractionTimer();
    }

    public void Update()
    {
        if (DialogueIsPlaying && DialogueManager.ThisDialogueType == DialogueType.AyDialogue ||
            DialogueIsPlaying && DialogueManager.ThisDialogueType == DialogueType.BartDialogue ||
            DialogueIsPlaying && DialogueManager.ThisDialogueType == DialogueType.BennyDialogue ||
            DialogueIsPlaying && DialogueManager.ThisDialogueType == DialogueType.LeonDialogue ||
            DialogueIsPlaying && DialogueManager.ThisDialogueType == DialogueType.MrBDialogue ||
            DialogueIsPlaying && DialogueManager.ThisDialogueType == DialogueType.ObstructorDialogue ||
            DialogueIsPlaying && DialogueManager.ThisDialogueType == DialogueType.OppositaDialogue ||
            DialogueIsPlaying && DialogueManager.ThisDialogueType == DialogueType.SentinelDialogue)
            _dialogueTimer.Update();
        else if (DialogueIsPlaying && DialogueManager.ThisDialogueType == DialogueType.ObjectInvestigation ||
            DialogueIsPlaying && DialogueManager.ThisDialogueType == DialogueType.ObjectInteraction ||
            DialogueIsPlaying && DialogueManager.ThisDialogueType == DialogueType.InventoryInvestigation ||
            DialogueIsPlaying && DialogueManager.ThisDialogueType == DialogueType.InventoryInteraction ||
            DialogueIsPlaying && DialogueManager.ThisDialogueType == DialogueType.InventoryCombination ||
            DialogueIsPlaying && DialogueManager.ThisDialogueType == DialogueType.ItemWorldCombination || 
            DialogueIsPlaying && DialogueManager.ThisDialogueType == DialogueType.RandomNo)
        {
            _objectInteractionTimer.Update();
        }
        else if(DialogueIsPlaying)
        {
            Debug.LogError("Please implement this type of dialogu: " + DialogueManager.ThisDialogueType);
        }
    }

    public void PlayDialogueTimer(float dialogueLength)     //TODO: We can probably improve the speed here
    {
        DialogueType dialogueType = DialogueManager.ThisDialogueType;

        if (dialogueType == DialogueType.AyDialogue ||
            dialogueType == DialogueType.BartDialogue ||
            dialogueType == DialogueType.BennyDialogue ||
            dialogueType == DialogueType.LeonDialogue ||
            dialogueType == DialogueType.MrBDialogue ||
            dialogueType == DialogueType.ObstructorDialogue ||
            dialogueType == DialogueType.OppositaDialogue ||
            dialogueType == DialogueType.SentinelDialogue)
            _dialogueTimer.SetDialogueTimerLength(dialogueLength);
        else if (dialogueType == DialogueType.ObjectInvestigation ||
                    dialogueType == DialogueType.ObjectInteraction ||
                    dialogueType == DialogueType.InventoryInvestigation ||
                    dialogueType == DialogueType.InventoryInteraction ||
                    dialogueType == DialogueType.InventoryCombination ||
                    dialogueType == DialogueType.ItemWorldCombination ||
                    dialogueType == DialogueType.RandomNo)
            _objectInteractionTimer.SetDialogueTimerLength(dialogueLength);
                else
        {
            Debug.LogError("Please implement this type of dialogu: " + dialogueType);
        }

        DialogueIsPlaying = true;
    }

    public void CreateRotator(Transform from, Transform target, float speed, float timerLength)
    {
        GameObject rotatorGO = new GameObject();
        RotateTowards rotateTowards = rotatorGO.AddComponent<RotateTowards>();
        rotateTowards.From = from;
        rotateTowards.Target = target;
        rotateTowards.Speed = speed;
        rotateTowards.Timer = timerLength;
    }

    public static IEnumerator WaitUntilEndOfClip(float clipLength)
    {
        yield return new WaitForSeconds((float)clipLength);
    }
}