using System.Collections.Generic;
using UnityEngine;

public class LeonTurmeric : MonoBehaviour
{
    public static int CharacterSituation;
    public static LeonTurmeric Instance;
    public Animator Animator;

    private static List<int> LastOptionsBefore14002 = new List<int>() { 14001, 14020, 14030, 14040, 14050, 14060, 14080 };
    private static List<int> LastOptionsBefore14020 = new List<int>() { 14001, 14002, 14030, 14040, 14050, 14060, 14080 };
    private static List<int> LastOptionsBefore14030 = new List<int>() { 14001, 14002, 14020, 14030, 14040, 14050, 14060, 14080 };
    private static List<int> LastOptionsBefore14040 = new List<int>() { 14001, 14002, 14020, 14030, 14060 };
    private static List<int> LastOptionsBefore14050 = new List<int>() { 14001, 14002, 14020, 14030, 14040, 14060 };
    private static List<int> LastOptionsBefore14055 = new List<int>() { 14001, 14002, 14020, 14030, 14040, 14050, 14060, 14080 };
    private static List<int> LastOptionsBefore14060 = new List<int>() { 14001, 14002, 14020, 14030, 14040, 14050, 14080 };
    private static List<int> LastOptionsBefore14080 = new List<int>() { 14001, 14002, 14020, 14030, 14050, 14060, 14080 };

    private static List<int> LastOptionsBefore14100 = new List<int>() { 14100, 14110, 14114 };
    private static List<int> LastOptionsBefore14110 = new List<int>() { 14100, 14110, 14114 };
    private static List<int> LastOptionsBefore14114 = new List<int>() { 14100, 14110, 14114 };
    private static List<int> LastOptionsBefore14120 = new List<int>() { 14100, 14110, 14114 };

    private static Dictionary<int, List<int>> PrecedingOptions = new Dictionary<int, List<int>>()
    { 
        {14002, LastOptionsBefore14002},
        {14020, LastOptionsBefore14020},
        {14030, LastOptionsBefore14030},
        {14040, LastOptionsBefore14040},
        {14050, LastOptionsBefore14050},
        {14055, LastOptionsBefore14055},
        {14060, LastOptionsBefore14060},
        {14080, LastOptionsBefore14080},
        {14100, LastOptionsBefore14100},
        {14110, LastOptionsBefore14110},
        {14114, LastOptionsBefore14114},
        {14120, LastOptionsBefore14120},


    };

    public void Start()
    {
        Instance = this;

        Animator = GetComponentInChildren<Animator>();
    }

    public void StartDialogue()
    {
        DialogueManager.StartDialogueState(Character.Leon, 0);
    }

    public void DialogueLineNumberToSituation(int optionID)   //the last line of dialogue determines which situation will follow
    {
        if (IsLastBefore(optionID, 14002) && WorldEvents.LookingForGalleryVisitors)
            DialogueMenu.AddToDialogueOptions(14002);
        if (IsLastBefore(optionID, 14020)) 
            if ((!GameManager.Instance.MyInventory.LookForItem(ItemType.CupOfTea)))
            DialogueMenu.AddToDialogueOptions(14020);
        if (IsLastBefore(optionID, 14030))
            if((!GameManager.Instance.MyInventory.LookForItem(ItemType.CupOfCoffee)))
            DialogueMenu.AddToDialogueOptions(14030);
        if (IsLastBefore(optionID, 14040))
            DialogueMenu.AddToDialogueOptions(14040);
        if (IsLastBefore(optionID, 14050) && DialogueManager.IsDialoguePassed(14040))
            DialogueMenu.AddToDialogueOptions(14050);
        if (IsLastBefore(optionID, 14060) && WorldEvents.NeedsToKnowWhatSacrificeIs)
            DialogueMenu.AddToDialogueOptions(14060);
        if (IsLastBefore(optionID, 14080) && DialogueManager.IsDialoguePassed(14050))
            DialogueMenu.AddToDialogueOptions(14080);
        if (IsLastBefore(optionID, 14055))
            DialogueMenu.AddToDialogueOptions(14055);

        if (IsLastBefore(optionID, 14100))
            DialogueMenu.AddToDialogueOptions(14100);
        if (IsLastBefore(optionID, 14110))
            DialogueMenu.AddToDialogueOptions(14110);
        if (IsLastBefore(optionID, 14114))
            DialogueMenu.AddToDialogueOptions(14114);
        if (IsLastBefore(optionID, 14120))
        {
            DialogueMenu.AddToDialogueOptions(14120);

        }

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
                AddToDialogue(14001);
                DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(14001);

                break;
            case 2: //SITUATION 2
                if (DialogueManager.IsDialoguePassed(14100) && DialogueManager.IsDialoguePassed(14110) && DialogueManager.IsDialoguePassed(14114))
                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(14120);
                else
                {
                    DialogueMenu.AddToDialogueOptions(14100);
                    DialogueMenu.AddToDialogueOptions(14110);
                    DialogueMenu.AddToDialogueOptions(14114);
                    DialogueMenu.AddToDialogueOptions(14120);
                    DialogueMenu.FindVisibleDialogueOptions(Character.Leon);
                }
                break;
            default: //in all other dialogue options
                DialogueMenu.FindVisibleDialogueOptions(Character.Leon);
                break;
        }
    }

    public static void TriggerDialogue(int dialogueOptionID)
    {
        if (dialogueOptionID == 14002)
        {
            DialoguePlayback.DeleteLineID = 14002;

            AddToDialogue(14002);
            AddToDialogue(14003);
            AddToDialogue(14004);
            AddToDialogue(14005);
            AddToDialogue(14006);
            AddToDialogue(14007);
            AddToDialogue(14008);
            AddToDialogue(14009);
            AddToDialogue(14010);
            AddToDialogue(14011);

            WorldEvents.PeopleNotGoingToGallery = WorldEvents.PeopleNotGoingToGallery + 1;
        }

        if (dialogueOptionID == 14020)
        {
            AddToDialogue(14020);
            AddToDialogue(14021);
            AddToDialogue(14022);
            AddToDialogue(14023);
            AddToDialogue(14024);
            AddToDialogue(14025);
            AddToDialogue(14026);
            AddToDialogue(14027);

            ItemManager.AddItem(ItemType.CupOfTea);
        }

        if (dialogueOptionID == 14030)
        {
            AddToDialogue(14030);
            AddToDialogue(14031);
            AddToDialogue(14032);
            AddToDialogue(14033);
            AddToDialogue(14034);
            AddToDialogue(14035);

            ItemManager.AddItem(ItemType.CupOfCoffee);
        }

        if (dialogueOptionID == 14040)
        {
            DialoguePlayback.DeleteLineID = 14040;

            AddToDialogue(14041);
            AddToDialogue(14042);
        }

        if (dialogueOptionID == 14050)
        {
            DialoguePlayback.DeleteLineID = 14050;

            AddToDialogue(14050);
            AddToDialogue(14051);
            AddToDialogue(14052);
            AddToDialogue(14053);
            AddToDialogue(14054);
        }

        if (dialogueOptionID == 14060)
        {
            DialoguePlayback.DeleteLineID = 14060;

            AddToDialogue(14060);
            AddToDialogue(14061);
            AddToDialogue(14062);
            AddToDialogue(14063);
            AddToDialogue(14064);
            AddToDialogue(14065);
            AddToDialogue(14066);
            AddToDialogue(14067);
            AddToDialogue(14068);
            AddToDialogue(14069);
            AddToDialogue(14070);
            AddToDialogue(14071);
        }

        if (dialogueOptionID == 14080)
        {
            DialoguePlayback.DeleteLineID = 14080;

            AddToDialogue(14080);
            AddToDialogue(14081);
        }

        if (dialogueOptionID == 14055)  // exit option
        {
            AddToDialogue(14055);

            DialoguePlayback.EndingDialogue = true;
        }

        if (dialogueOptionID == 14100)
        {
            DialoguePlayback.DeleteLineID = 14100;

            AddToDialogue(14100);
            AddToDialogue(14101);
            AddToDialogue(14102);

            if (DialogueManager.IsDialoguePassed(14110) && DialogueManager.IsDialoguePassed(14114))
            {
                AddToDialogue(14120);

                DialoguePlayback.EndingDialogue = true;
            }
        }

        if (dialogueOptionID == 14110)
        {
            DialoguePlayback.DeleteLineID = 14110;

            AddToDialogue(14110);
            AddToDialogue(14111);
            AddToDialogue(14112);
            AddToDialogue(14113);

            if (DialogueManager.IsDialoguePassed(14100) && DialogueManager.IsDialoguePassed(14114))
            {
                AddToDialogue(14120);

                DialoguePlayback.EndingDialogue = true;
            }
        }

        if (dialogueOptionID == 14114)
        {
            DialoguePlayback.DeleteLineID = 14114;

            AddToDialogue(14114);
            AddToDialogue(14115);

            if (DialogueManager.IsDialoguePassed(14100) && DialogueManager.IsDialoguePassed(14110))
            {
                AddToDialogue(14120);

                DialoguePlayback.EndingDialogue = true;
            }
        }

        if (dialogueOptionID == 14120)
        {
            AddToDialogue(14120);

            DialoguePlayback.EndingDialogue = true;
        }
    }

    private static void AddToDialogue(int dialogueID)
    {
        Debug.Log("Adding to dialogue: " + dialogueID);
        DialoguePlayback.AddToDialogue(dialogueID);
    }

    private bool IsLastBefore(int lastLine, int dialogueOptionID)
    {
        if (PrecedingOptions[dialogueOptionID].Contains(lastLine))
            return true;

        return false;
    }
}
