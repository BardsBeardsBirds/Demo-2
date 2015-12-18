using System.Collections.Generic;
using UnityEngine;

public class BennyTwospoons : MonoBehaviour
{
    public static int CharacterSituation;
    public static BennyTwospoons Instance;
    public Animator Animator;

    private static List<int> LastOptionsBefore13001 = new List<int>() { 13020, 13030, 13150 };
    private static List<int> LastOptionsBefore13010 = new List<int>() { 13001, 13020, 13030, 13150 };
    private static List<int> LastOptionsBefore13020 = new List<int>() { 13010 };
    private static List<int> LastOptionsBefore13030 = new List<int>() { 13010 };
    private static List<int> LastOptionsBefore13040 = new List<int>() { 13010 };
    private static List<int> LastOptionsBefore13100 = new List<int>() { 13001, 13020, 13030, 13150 };
    private static List<int> LastOptionsBefore13102 = new List<int>() { 13100, 13110, 13120, 13130, 13140 };
    private static List<int> LastOptionsBefore13110 = new List<int>() { 13100, 13102, 13110, 13120, 13130, 13140 };
    private static List<int> LastOptionsBefore13120 = new List<int>() { 13100, 13102, 13110, 13120, 13130, 13140 };
    private static List<int> LastOptionsBefore13130 = new List<int>() { 13100, 13102, 13110, 13120, 13130, 13140 };
    private static List<int> LastOptionsBefore13140 = new List<int>() { 13100, 13102, 13110, 13120, 13130, 13140 };
    private static List<int> LastOptionsBefore13150 = new List<int>() { 13100, 13102, 13110, 13120, 13130, 13140 };
    private static List<int> LastOptionsBefore13200 = new List<int>() { 13001, 13020, 13030, 13150 };
    private static List<int> LastOptionsBefore13300 = new List<int>() { 13001, 13020, 13030, 13150 };



    private static Dictionary<int, List<int>> PrecedingOptions = new Dictionary<int, List<int>>()
    { 
        {13001, LastOptionsBefore13001},
        {13010, LastOptionsBefore13010},
        {13020, LastOptionsBefore13020},
        {13030, LastOptionsBefore13030},
        {13040, LastOptionsBefore13040},
        {13100, LastOptionsBefore13100},
        {13102, LastOptionsBefore13102},
        {13110, LastOptionsBefore13110},
        {13120, LastOptionsBefore13120},
        {13130, LastOptionsBefore13130},
        {13140, LastOptionsBefore13140},
        {13150, LastOptionsBefore13150},
        {13200, LastOptionsBefore13200},
        {13300, LastOptionsBefore13300},

    };

    public void Start()
    {
        Instance = this;

        Animator = GetComponentInChildren<Animator>();
    }

    public void StartDialogue()
    {
        DialogueManager.StartDialogueState(Character.Benny, 0);
    }

    public void DialogueLineNumberToSituation(int optionID)   //the last line of dialogue determines which situation will follow
    {
        if (IsLastBefore(optionID, 13001))
            DialogueMenu.AddToDialogueOptions(13001);
        if (IsLastBefore(optionID, 13010))
            DialogueMenu.AddToDialogueOptions(13010);
        if (IsLastBefore(optionID, 13020))
            DialogueMenu.AddToDialogueOptions(13020);
        if (IsLastBefore(optionID, 13030))
            DialogueMenu.AddToDialogueOptions(13030);
        if (IsLastBefore(optionID, 13040))
            DialogueMenu.AddToDialogueOptions(13040);
        if (IsLastBefore(optionID, 13100))
            DialogueMenu.AddToDialogueOptions(13100);
        if (IsLastBefore(optionID, 13102))
            DialogueMenu.AddToDialogueOptions(13102);
        if (IsLastBefore(optionID, 13110))
            DialogueMenu.AddToDialogueOptions(13110);
        if (IsLastBefore(optionID, 13120))
            DialogueMenu.AddToDialogueOptions(13120);
        if (IsLastBefore(optionID, 13130))
            DialogueMenu.AddToDialogueOptions(13130);
        if (IsLastBefore(optionID, 13140))
            DialogueMenu.AddToDialogueOptions(13140);
        if (IsLastBefore(optionID, 13150))
            DialogueMenu.AddToDialogueOptions(13150);
        if (IsLastBefore(optionID, 13200))
            Debug.Log("Do we have a dynamite shake? " + GameManager.Instance.MyInventory.LookForItem(ItemType.AysMagicDynamiteShake));

            if (GameManager.Instance.MyInventory.LookForItem(ItemType.AysMagicDynamiteShake))
            {
                Debug.Log("Do we have a dynamite shake? " + GameManager.Instance.MyInventory.LookForItem(ItemType.AysMagicDynamiteShake));
                DialogueMenu.AddToDialogueOptions(13200);
            }
        if (IsLastBefore(optionID, 13300))
            DialogueMenu.AddToDialogueOptions(13300);


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
                DialogueMenu.AddToDialogueOptions(13001);
                DialogueMenu.AddToDialogueOptions(13010);
                DialogueMenu.AddToDialogueOptions(13100);

                if (GameManager.Instance.MyInventory.LookForItem(ItemType.AysMagicDynamiteShake))
                    DialogueMenu.AddToDialogueOptions(13200);
                DialogueMenu.AddToDialogueOptions(13300);
                DialogueMenu.FindVisibleDialogueOptions(Character.Benny);

                break;
            case 2: //SITUATION 2
                if (DialogueManager.IsDialoguePassed(13400))
                {
                    DialogueMenu.AddToDialogueOptions(13410);
                    DialogueMenu.AddToDialogueOptions(13411);
                    DialogueMenu.AddToDialogueOptions(13412);

                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(13410);

          //          DialoguePlayback.EndingDialogue = true;

      //              return 13410;
                }
                else
                {
                    DialoguePlayback.DeleteLineID = 13400;

                    DialogueMenu.AddToDialogueOptions(13400);
                    DialogueMenu.AddToDialogueOptions(13401);
                    DialogueMenu.AddToDialogueOptions(13402);

                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(13400);

         //           DialoguePlayback.EndingDialogue = true;
          //          return 13400;
                }
                           DialoguePlayback.EndingDialogue = true;


                break; 
            default: //in all other dialogue options
                DialogueMenu.FindVisibleDialogueOptions(Character.Benny);
                break;
        }
    }

    public static void TriggerDialogue(int dialogueOptionID)
    {
        if (dialogueOptionID == 13001)
        {
            DialoguePlayback.DeleteLineID = 13001;

            AddToDialogue(13001);
            AddToDialogue(13002);
            AddToDialogue(13003);
            AddToDialogue(13004);
            AddToDialogue(13005);
            AddToDialogue(13006);
            AddToDialogue(13007);
            AddToDialogue(13008);

            WorldEvents.PeopleNotGoingToGallery = WorldEvents.PeopleNotGoingToGallery + 1;
        }

        if (dialogueOptionID == 13010)
        {
            AddToDialogue(13010);
            AddToDialogue(13011);
        }

        if (dialogueOptionID == 13020)
        {
            AddToDialogue(13020);
            AddToDialogue(13021);
            AddToDialogue(13022);
            AddToDialogue(13023);
            AddToDialogue(13024);
            AddToDialogue(13025);
            AddToDialogue(13026);
            AddToDialogue(13027);
        }

        if (dialogueOptionID == 13030)
        {
            AddToDialogue(13030);
            AddToDialogue(13031);
            AddToDialogue(13032);
            AddToDialogue(13033);
        }

        if (dialogueOptionID == 13040)
        {
            AddToDialogue(13040);
            AddToDialogue(13041);
            AddToDialogue(13042);
            AddToDialogue(13043);
            AddToDialogue(13044);
            AddToDialogue(13045);
            AddToDialogue(13046);
            AddToDialogue(13047);

            DialoguePlayback.EndingDialogue = true;
        }

        if (dialogueOptionID == 13100)
        {
            AddToDialogue(13100);
            AddToDialogue(13101);
        }

        if (dialogueOptionID == 13102)
        {
            DialoguePlayback.DeleteLineID = 13102;

            AddToDialogue(13102);
            AddToDialogue(13103);
            AddToDialogue(13104);
            AddToDialogue(13105);
        }

        if (dialogueOptionID == 13110)
        {
            AddToDialogue(13111);
            AddToDialogue(13112);
            AddToDialogue(13113);

            ItemManager.AddItem(ItemType.ClownNose);
            ItemManager.AddItem(ItemType.PartyHat);                
            //remove money
            DialoguePlayback.EndingDialogue = true;
        }

        if (dialogueOptionID == 13120)
        {
            AddToDialogue(13121);
            AddToDialogue(13122);
        }

        if (dialogueOptionID == 13130)
        {
            AddToDialogue(13130);
            AddToDialogue(13131);
            AddToDialogue(13132);
            AddToDialogue(13133);
            AddToDialogue(13134);
        }

        if (dialogueOptionID == 13140)
        {
            AddToDialogue(13141);
            AddToDialogue(13142);
            AddToDialogue(13143);
            AddToDialogue(13144);

            ItemManager.AddItem(ItemType.ClownMask);
            //remove money
            DialoguePlayback.EndingDialogue = true;
        }

        if (dialogueOptionID == 13150)
        {
            AddToDialogue(13150);
        }

        if (dialogueOptionID == 13200)
        {
            DialoguePlayback.DeleteLineID = 13200;

            AddToDialogue(13201);
            AddToDialogue(13202);
            AddToDialogue(13203);
            AddToDialogue(13204);
            AddToDialogue(13205);
            AddToDialogue(13206);
            AddToDialogue(13207);

            DialoguePlayback.EndingDialogue = true;
        }

        if (dialogueOptionID == 13300)
        {
            AddToDialogue(13300);
            AddToDialogue(13301);

            DialoguePlayback.EndingDialogue = true;
        }
    }

    private static void AddToDialogue(int dialogueID)
    {
        Debug.Log("Adding to dialogue: " + dialogueID);
        DialoguePlayback.AddToDialogue(GameManager.CharacterDialogueLists[Character.Benny][dialogueID]);
    }

    private bool IsLastBefore(int lastLine, int dialogueOptionID)
    {
        if (PrecedingOptions[dialogueOptionID].Contains(lastLine))
            return true;

        return false;
    }
}
