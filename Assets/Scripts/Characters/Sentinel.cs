using System.Collections.Generic;
using UnityEngine;

public class Sentinel : MonoBehaviour
{
    public static int CharacterSituation = 1;
    public static Sentinel Instance;
    public Animator Animator;

    private static Dictionary<int, List<int>> PrecedingOptions = new Dictionary<int, List<int>>()
    { 

    };

    public void Start()
    {
        Instance = this;
        Animator = GetComponentInChildren<Animator>();
    }

    public void StartDialogue()
    {
        DialogueManager.StartDialogueState(Character.Sentinel, 0);
    }

    public void DialogueLineNumberToSituation(int optionID)   //the last line of dialogue determines which situation will follow
    {
        switch (optionID)
        {
            //opening options
            case 1:
                FindDialogueSituation(1);
                break;
            case 2:
                FindDialogueSituation(2);
                break;
            default:
                FindDialogueSituation(0);
                break;
        }
    }

    public void FindDialogueSituation(int dialogueSituation)
    {
        CharacterControllerLogic.Instance.GoToTalkingState();

        switch (dialogueSituation)
        {
            case 1: //SITUATION 1
                if (DialogueManager.IsDialoguePassed(18030))
                {
                    if(WorldEvents.DecipheredSentinelsMessage)
                    {
                        DialoguePlayback.DeleteLineID = 18050;

                        AddToDialogue(18050);
                        AddToDialogue(18051);
                        AddToDialogue(18052);

                        DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(18050);
                    }
                    else
                    {
                        AddToDialogue(18040);
                        AddToDialogue(18041);
                        AddToDialogue(18042);

                        DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(18040);
                    }
                }
                else if (DialogueManager.IsDialoguePassed(18020))
                {
                    DialoguePlayback.DeleteLineID = 18030;

                    AddToDialogue(18030);
                    AddToDialogue(18031);
                    AddToDialogue(18032);
                    AddToDialogue(18033);
                    AddToDialogue(18034);
                    AddToDialogue(18035);
                    AddToDialogue(18036);
                    AddToDialogue(18037);


                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(18030);
                }
                else if (DialogueManager.IsDialoguePassed(18010))
                {
                    DialoguePlayback.DeleteLineID = 18020;

                    AddToDialogue(18020);
                    AddToDialogue(18021);
                    AddToDialogue(18022);

                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(18020);
                }                
                else if (DialogueManager.IsDialoguePassed(18001))
                {
                    Debug.Log("We passed it!");
                    DialoguePlayback.DeleteLineID = 18010;

                    AddToDialogue(18010);
                    AddToDialogue(18011);
                    AddToDialogue(18012);
                    AddToDialogue(18013);
                    AddToDialogue(18014);
                    AddToDialogue(18015);
                    AddToDialogue(18016);


                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(18010);
                }
                else
                {
                    Debug.Log("We did not pass it!");
                    DialoguePlayback.DeleteLineID = 18001;

                    AddToDialogue(18001);
                    AddToDialogue(18002);
                    AddToDialogue(18003);
                    AddToDialogue(18004);

                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(18001);
                }
                Debug.Log(DialogueManager.IsDialoguePassed(18001));
                DialoguePlayback.EndingDialogue = true;

                break;
            case 2: //SITUATION 2
                if(DialogueManager.IsDialoguePassed(18100))
                {
                    AddToDialogue(18110);
                    AddToDialogue(18111);

                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(18110);

                }
                else
                {
                    AddToDialogue(18100);
                    AddToDialogue(18101);
                    AddToDialogue(18102);
                    AddToDialogue(18103);
                    DialoguePlayback.DeleteLineID = 18100;

                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(18100);
                }
                DialoguePlayback.EndingDialogue = true;

                break;

            default: //in all other dialogue options
                DialogueMenu.FindVisibleDialogueOptions(Character.Sentinel);
                break;
        }
    }

    public static void TriggerDialogue(int dialogueOptionID)
    {
       
    }

    private static void AddToDialogue(int dialogueID)
    {
        DialoguePlayback.AddToDialogue(dialogueID);
    }

    private bool IsLastBefore(int lastLine, int dialogueOptionID)
    {
        if (PrecedingOptions[dialogueOptionID].Contains(lastLine))
            return true;

        return false;
    }
}
