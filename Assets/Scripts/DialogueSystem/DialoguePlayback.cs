using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialoguePlayback : MonoBehaviour
{
    public static Character NPC;
    public static DialoguePlayback Instance;
    public static SpokenLine CurrentSpokenLine;

    public static bool EndingDialogue = false;
    public static bool LastLineOfTheBlock = false;

    public static int DeleteLineID = 0;

    public static List<SpokenLine> CurrentDialogueLines = new List<SpokenLine>();

    private static string _currentDialogueLine;

    public static List<char> AutoWriteChars = new List<char>();

    public void Awake()
    {
        _currentDialogueLine = "";
        Instance = this;
    }

    public void ShowDialogueLines()
    {
        Text lineText = GameManager.Instance.UICanvas.DialogueLineImage.GetComponentInChildren<Text>();
        lineText.enabled = true;
    }

    public void HideDialogueLines()
    {
        Text lineText = GameManager.Instance.UICanvas.DialogueLineImage.GetComponentInChildren<Text>();
        lineText.text = "";
        lineText.enabled = false;
    }

    public void SetCurrentDialogueLine(string currentDialogueLine)
    {
        _currentDialogueLine = currentDialogueLine;

        Text lineText = GameManager.Instance.UICanvas.DialogueLineImage.GetComponentInChildren<Text>();
        lineText.text = _currentDialogueLine;
        lineText.text = "";
        lineText.enabled = true;

        StartCoroutine(AutoType(lineText));
    }

    IEnumerator AutoType(Text lineText)
    {
        AutoWriteChars.Clear();

        foreach (char letter in _currentDialogueLine.ToCharArray())
        {
            AutoWriteChars.Add(letter);
        }

        for (int i = 0; i < AutoWriteChars.Count; i++)
        {
            DialogueTimer.IsTyping = true;

            lineText.text += AutoWriteChars[i];

            if (i == AutoWriteChars.Count - 1)
            {
                DialogueTimer.IsTyping = false;
                AutoWriteChars.Clear();
                break;
            }
            yield return new WaitForSeconds(.015f);
        }
    }

    public static void TriggerDialogue(int dialogueOptionID)
    {
        Debug.Log("Laten we deze dialoog spelen: " + NPC + " " + dialogueOptionID);

        if (NPC == Character.Ay)
            AyTheTearCollector.TriggerDialogue(dialogueOptionID);
        else if (NPC == Character.Bart)
            BartTumblescream.TriggerDialogue(dialogueOptionID);
        else if (NPC == Character.Benny)
            BennyTwospoons.TriggerDialogue(dialogueOptionID);
        else if (NPC == Character.Leon)
            LeonTurmeric.TriggerDialogue(dialogueOptionID);
        else if (NPC == Character.MrB)
            MrB.TriggerDialogue(dialogueOptionID);
        else if (NPC == Character.Obstructor)
            Obstructor.TriggerDialogue(dialogueOptionID);
        else if (NPC == Character.Opposita)
            MadameOpposita.TriggerDialogue(dialogueOptionID);
        else if (NPC == Character.Sentinel)
            Sentinel.TriggerDialogue(dialogueOptionID);
        else
            Debug.LogError("Please set up dialogue for " + NPC);
    }

    public void PlaybackDialogue(int dialogueOptionID)
    {
        DialoguePlayback.TriggerDialogue(dialogueOptionID); //starts loading all the lines
    //    Debug.Log("We chose option " + dialogueOption + " with option id " + dialogueOptionID + ". The last lineID was: " + DialoguePlayback.LastLineID);

        DialogueTimer.ChosenOptionID = dialogueOptionID;

        StartCoroutine(DialogueRoutine());

        DialogueMenu.HideDialogueOptions();
        ShowDialogueLines();
    }

    public void PlaybackDialogueWithoutOptions(int dialogueOptionID)
    {
        DialoguePlayback.TriggerDialogue(dialogueOptionID); //starts loading all the lines

        DialogueTimer.ChosenOptionID = dialogueOptionID;

        StartCoroutine(DialogueRoutine());

        ShowDialogueLines();
    }

    public static IEnumerator DialogueRoutine()
    {

        for (int i = 0; i < DialoguePlayback.CurrentDialogueLines.Count; i++)
        {
            LastLineOfTheBlock = false;

            CurrentSpokenLine = GameManager.CharacterDialogueLists[NPC][DialoguePlayback.CurrentDialogueLines[i].ID];
            SpokenLine spokenLine = CurrentSpokenLine;

            DialogueColour.SetTextColour(spokenLine);

            Instance.SetCurrentDialogueLine(spokenLine.Text);

            ThirdPersonCamera.Instance.DialogueCameraAngles[NPC].GetComponent<DialogueCamera>().FindAngle(ThirdPersonCamera.Instance.MyCamera, spokenLine);

            Debug.Log("currently going over : " + GameManager.NPCs[NPC].gameObject.name + "/" + spokenLine.ID);

            string audioFile = GameManager.NPCs[NPC].gameObject.name + "/" + spokenLine.ID;
            AudioManager.Instance.PlayDialogueAudio(audioFile);

            //animation
            SetTalkingListening(spokenLine.ID);

            if (i + 1 == DialoguePlayback.CurrentDialogueLines.Count)
            {
                LastLineOfTheBlock = true;
                DialoguePlayback.ClearDialogueList();
                DialogueMenu.ClearDialogueOptionLists();

                if (EndingDialogue)
                {
                    CharacterControllerLogic.Instance.GoToTalkingLastLineState();
                    Debug.LogWarning("BEINDIG" + CharacterControllerLogic.Instance.State);
                    EndingDialogue = false;
                }
            }
            float timerLength = (float)DialogueTimer.AudioClipLength;

            yield return new WaitForSeconds((float)timerLength);

            while (DialogueTimer.IsTyping)
            {
                yield return null;
            }


        }
    }

    private static void SetTalkingListening(int id)
    {
        SpokenLine spokenLine = GameManager.CharacterDialogueLists[NPC][id];

        if (spokenLine.Speaker == NPC)
        {
            //GameManager.NPCs[NPC].GetComponent<Animator>().SetBool("Listening", false);
            //GameManager.NPCs[NPC].GetComponent<Animator>().SetBool("Talking", true);
            CharacterControllerLogic.Instance.SetTalkingBool(false);
        }
        else
        {
            //GameManager.NPCs[NPC].GetComponent<Animator>().SetBool("Listening", true);
            //GameManager.NPCs[NPC].GetComponent<Animator>().SetBool("Talking", false);
            CharacterControllerLogic.Instance.SetTalkingBool(false);
        }
    }

    public static void AddToDialogue(SpokenLine spokenLine)
    {
        CurrentDialogueLines.Add(spokenLine);

        if (DeleteLineID != 0)
        {
            DeleteLine(DeleteLineID); 
            DeleteLineID = 0;
        }
    }

    public static void DeleteLine(int deleteLineID)
    {
        SpokenLine spokenLine = GameManager.CharacterDialogueLists[NPC][deleteLineID];  //something might be wrong here
        DialogueManager.AddToPassedDialogueLines(spokenLine);
    }

    public static void DialogueNumberToSituation(int id)
    {
        switch (NPC)
        {
            case Character.Ay:
                    AyTheTearCollector.Instance.DialogueLineNumberToSituation(id);
                break;
            case Character.Bart:
                BartTumblescream.Instance.DialogueLineNumberToSituation(id);
                break;
            case Character.Benny:
                BennyTwospoons.Instance.DialogueLineNumberToSituation(id);
                break;
            case Character.Leon:
                LeonTurmeric.Instance.DialogueLineNumberToSituation(id);
                break;
            case Character.MrB:
                MrB.Instance.DialogueLineNumberToSituation(id);
                break;
            case Character.Obstructor:
                Obstructor.Instance.DialogueLineNumberToSituation(id);
                break;
            case Character.Opposita:
                MadameOpposita.Instance.DialogueLineNumberToSituation(id);
                break;
            case Character.Sentinel:
                    Sentinel.Instance.DialogueLineNumberToSituation(id);
                break;
            default: //in all other dialogue options
                Debug.LogError("I don't know this dialogue situation: Situation " + NPC);
                break;
        }
    }

    public static void ClearDialogueList()
    {
        CurrentDialogueLines.Clear();
    }

    #region ObjectCommentary
    public void PlaybackCommentary(DialogueType dialogueType, InWorldObject objectInLevel)
    {
        Debug.LogWarning(dialogueType + " " + objectInLevel);
        StartCoroutine(ObjectCommentary.CommentaryRoutine(dialogueType, objectInLevel));
    }

    public void PlaybackCommentary(DialogueType dialogueType, Item inventoryItem)
    {
        StartCoroutine(InventoryCommentary.InventoryCommentaryRoutine(dialogueType, inventoryItem));
    }

    public void PlaybackCommentary()
    {
        MyConsole.WriteToConsole("Lets get closer");
        StartCoroutine(ObjectCommentary.LetsGetCloserRoutine());
    }

    public void PlaybackCombineItemsWithWorld(Item inventoryItem, InWorldObject worldObject)
    {
        StartCoroutine(GameManager.Instance.IIventoryItemWithObject.CombineItemRoutine(inventoryItem, worldObject));
    }

    public void PlaybackCombineItemsInventory(Item inventoryItem, Item subjectedInventoryItem)
    {
        StartCoroutine(GameManager.Instance.IIventoryItemWithObject.CombineItemRoutine(inventoryItem, subjectedInventoryItem));
    }

    #endregion
}