using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AyTheTearCollector : MonoBehaviour 
{
    public static int CharacterSituation;
    public static AyTheTearCollector Instance;
    public Animator Animator;

    private static List<int> LastOptionsBefore11030 = new List<int>() { 11001, 11016, 11020, 11050, 11051, 11060, 11070, 11080, 11100, 11110, 11200, 11220, 11230 };
    private static List<int> LastOptionsBefore11036 = new List<int>() { 11001, 11016, 11020, 11030, 11050, 11051, 11060, 11070, 11080, 11100, 11110, 11200, 11220, 11230 };
    private static List<int> LastOptionsBefore11040 = new List<int>() { 11001, 11016, 11020, 11036, 11050, 11051, 11060, 11070, 11080, 11100, 11110, 11200, 11220, 11230 };
    private static List<int> LastOptionsBefore11050 = new List<int>() { 11001, 11016, 11020, 11030, 11036, 11040, 11060, 11070, 11080, 11100, 11110, 11200, 11220, 11230 };
    private static List<int> LastOptionsBefore11051 = new List<int>() { 11001, 11016, 11020, 11030, 11036, 11040, 11060, 11070, 11080, 11100, 11110, 11200, 11220, 11230 };
    private static List<int> LastOptionsBefore11060 = new List<int>() { 11001, 11016, 11020, 11030, 11036, 11040, 11050, 11051, 11100, 11110, 11200, 11220, 11230 };
    private static List<int> LastOptionsBefore11070 = new List<int>() { 11001, 11016, 11020, 11030, 11036, 11040, 11050, 11051, 11060, 11100, 11110, 11200, 11220, 11230 };
    private static List<int> LastOptionsBefore11080 = new List<int>() { 11001, 11016, 11020, 11030, 11036, 11040, 11050, 11051, 11070, 11100, 11110, 11200, 11220, 11230 };
    private static List<int> LastOptionsBefore11100 = new List<int>() { 11001, 11016, 11020, 11030, 11036, 11040, 11050, 11051, 11060, 11070, 11080, 11110, 11200, 11220, 11230 };
    private static List<int> LastOptionsBefore11110 = new List<int>() { 11001, 11016, 11020, 11030, 11036, 11040, 11050, 11051, 11060, 11070, 11080, 11100, 11200, 11220, 11230 };
    private static List<int> LastOptionsBefore11120 = new List<int>() { 11001, 11016, 11020, 11030, 11036, 11040, 11050, 11051, 11060, 11070, 11080, 11100, 11110, 11200, 11220, 11230 };
    private static List<int> LastOptionsBefore11200 = new List<int>() { 11001, 11016, 11020, 11030, 11036, 11040, 11050, 11051, 11060, 11070, 11080, 11100, 11110, 11220, 11230 };
    private static List<int> LastOptionsBefore11220 = new List<int>() { 11001, 11016, 11020, 11030, 11036, 11040, 11050, 11051, 11060, 11070, 11080, 11100, 11110, 11200 };
    private static List<int> LastOptionsBefore11230 = new List<int>() { 11001, 11016, 11020, 11030, 11036, 11040, 11050, 11051, 11060, 11070, 11080, 11100, 11110, 11200, 11220 };
    

    private static Dictionary<int, List<int>> PrecedingOptions = new Dictionary<int, List<int>>()
    { 
        {11030, LastOptionsBefore11030},
        {11036, LastOptionsBefore11036},
        {11040, LastOptionsBefore11040},
        {11050, LastOptionsBefore11050},
        {11051, LastOptionsBefore11051},
        {11060, LastOptionsBefore11060},
        {11070, LastOptionsBefore11070},
        {11080, LastOptionsBefore11080},
        {11100, LastOptionsBefore11100},
        {11110, LastOptionsBefore11110},
        {11120, LastOptionsBefore11120},
        {11200, LastOptionsBefore11200},
        {11220, LastOptionsBefore11220},
        {11230, LastOptionsBefore11230},
    };

    public void Start() 
    {
        Instance = this;
        CharacterSituation = 1;
        Animator = GetComponent<Animator>();
	}

    public void StartDialogue()
    {
        DialogueManager.StartDialogueState(Character.Ay);
    }

    public void DialogueLineNumberToSituation(int optionID)   
    {
        if (IsLastBefore(optionID, 11030) && (DialogueManager.IsDialoguePassed(11015) || DialogueManager.IsDialoguePassed(11016)))
            DialogueMenu.AddToDialogueOptions(11030);
        if (IsLastBefore(optionID, 11036) && DialogueManager.IsDialoguePassed(11030))
            DialogueMenu.AddToDialogueOptions(11036);
        if (IsLastBefore(optionID, 11040) && DialogueManager.IsDialoguePassed(11036))
            DialogueMenu.AddToDialogueOptions(11040);
        if (IsLastBefore(optionID, 11050) && WorldEvents.AskedAyAboutGallery)
            DialogueMenu.AddToDialogueOptions(11050);
        if (IsLastBefore(optionID, 11051) && !WorldEvents.AskedAyAboutGallery)
            DialogueMenu.AddToDialogueOptions(11051);
        if (IsLastBefore(optionID, 11060) && (DialogueManager.IsDialoguePassed(11050) || DialogueManager.IsDialoguePassed(11051)))
            DialogueMenu.AddToDialogueOptions(11060);
        if (IsLastBefore(optionID, 11070) && DialogueManager.IsDialoguePassed(11060))
            DialogueMenu.AddToDialogueOptions(11070);
        if (IsLastBefore(optionID, 11080) && DialogueManager.IsDialoguePassed(11080))
            DialogueMenu.AddToDialogueOptions(11080);
        if (IsLastBefore(optionID, 11100) && WorldEvents.NeedsToKnowWhatSacrificeIs)
            DialogueMenu.AddToDialogueOptions(11100); 
        if (IsLastBefore(optionID, 11110))
            DialogueMenu.AddToDialogueOptions(11110);
        if (IsLastBefore(optionID, 11200))
            if(GameManager.Instance.MyInventory.LookForItem(ItemType.DynamiteShake))
                DialogueMenu.AddToDialogueOptions(11200);
        if (IsLastBefore(optionID, 11220) && WorldEvents.KnowsWhatSacrificeIs)
            DialogueMenu.AddToDialogueOptions(11220);
        if (IsLastBefore(optionID, 11230) && DialogueManager.IsDialoguePassed(11220))
            DialogueMenu.AddToDialogueOptions(11230);

        if (IsLastBefore(optionID, 11120))      //Exit Option
            DialogueMenu.AddToDialogueOptions(11120);

        switch (optionID)
        {
            //opening options
            case 1:
                FindDialogueSituation(1);
                break;
            case 2:
                FindDialogueSituation(2);
                break;
            case 3:
                FindDialogueSituation(3);
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
            case 1: //SITUATION 1   // The first time Emmon talks to AY
                if (WorldEvents.LookingForGalleryVisitors)
                {
                    AddToDialogue(11001);
                    AddToDialogue(11002);
                    AddToDialogue(11003);
                    AddToDialogue(11004);
                    AddToDialogue(11005);
                    AddToDialogue(11006);
                    AddToDialogue(11007);
                    AddToDialogue(11008);
                    AddToDialogue(11009);
                    AddToDialogue(11010);
                    AddToDialogue(11011);
                    AddToDialogue(11012);
                    DialoguePlayback.EndingDialogue = true;
                    WorldEvents.SpokeToAy = true;
                    WorldEvents.AskedAyAboutGallery = true;
                    WorldEvents.PeopleNotGoingToGallery = WorldEvents.PeopleNotGoingToGallery + 1;

                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(11001);
                }
                else
                {
                    AddToDialogue(11001);
                    AddToDialogue(11002);
                    AddToDialogue(11003);
                    AddToDialogue(11004);
                    AddToDialogue(11005);
                    AddToDialogue(11006);
                    AddToDialogue(11007);
                    AddToDialogue(11014);

                    DialoguePlayback.DeleteLineID = 11015;

                    AddToDialogue(11015);

                    WorldEvents.SpokeToAy = true;

                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(11001);
                }
                break;
            case 2: //SITUATION 2 
                if (WorldEvents.AskedAyAboutGallery && !DialogueManager.IsDialoguePassed(11016))  //we asked Ay to come to the gallery, therefor he did not yet mention his Potion Shop
                {
                    DialoguePlayback.DeleteLineID = 11016;

                    AddToDialogue(11016);
                    AddToDialogue(11017);
                    AddToDialogue(11018);
                    AddToDialogue(11019);

                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(11016);
                }
                else
                {
                    AddToDialogue(11020);
                    AddToDialogue(11021);

                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(11020);
                }
                break;
            case 3: // SITUATION 3
                AddToDialogue(11300);
                AddToDialogue(11301);
                AddToDialogue(11302);
                DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(11300);
                DialoguePlayback.EndingDialogue = true;
                break;
            default: //in all other dialogue options
                DialogueMenu.FindVisibleDialogueOptions(Character.Ay);
                break;
        }
    }

    public static void TriggerDialogue(int dialogueOptionID)
    {
        if (dialogueOptionID == 11030)
        {
            DialoguePlayback.DeleteLineID = 11030;

            AddToDialogue(11030);
            AddToDialogue(11031);
            AddToDialogue(11032);
            AddToDialogue(11033);
            AddToDialogue(11034);
            AddToDialogue(11035);
        }

        if (dialogueOptionID == 11036)
        {
            DialoguePlayback.DeleteLineID = 11036;

            AddToDialogue(11036);
            AddToDialogue(11037);
        }

        if (dialogueOptionID == 11040)
        {
            DialoguePlayback.DeleteLineID = 11040;

            AddToDialogue(11040);
            AddToDialogue(11041);
            AddToDialogue(11042);
            AddToDialogue(11043);
            AddToDialogue(11044);
            AddToDialogue(11045);
        }

        if (dialogueOptionID == 11050 || dialogueOptionID == 11051)
        {
            DialoguePlayback.DeleteLineID = 11050;

            if(dialogueOptionID == 11050)
                AddToDialogue(11050);
            else if (dialogueOptionID == 11051)
                AddToDialogue(11051);

            AddToDialogue(11052);

            DialoguePlayback.DeleteLineID = 11051;

            AddToDialogue(11053);
            AddToDialogue(11054);
            AddToDialogue(11055);
        }

        if (dialogueOptionID == 11060)
        {
            DialoguePlayback.DeleteLineID = 11060;

            AddToDialogue(11060);
            AddToDialogue(11061);
            AddToDialogue(11062);
            AddToDialogue(11063);
        }

        if (dialogueOptionID == 11070)
        {
            DialoguePlayback.DeleteLineID = 11070;

            AddToDialogue(11070);
            AddToDialogue(11071);
            AddToDialogue(11072);
            AddToDialogue(11073);
            AddToDialogue(11074);
            AddToDialogue(11075);
        }

        if (dialogueOptionID == 11080)
        {
            DialoguePlayback.DeleteLineID = 11080;

            AddToDialogue(11080);
            AddToDialogue(11081);
            AddToDialogue(11082);
            AddToDialogue(11083);
            AddToDialogue(11084);
            AddToDialogue(11085); 
            AddToDialogue(11086);
            AddToDialogue(11087);
            AddToDialogue(11088);
            AddToDialogue(11089);
            AddToDialogue(11090);
        }

        if (dialogueOptionID == 11100)
        {
            DialoguePlayback.DeleteLineID = 11100;

            AddToDialogue(11100);
            AddToDialogue(11101);
            AddToDialogue(11102);
            AddToDialogue(11103);

        }

        if (dialogueOptionID == 11110)
        {
            AddToDialogue(11110);
            AddToDialogue(11111);
            AddToDialogue(11112);
            AddToDialogue(11113);
            AddToDialogue(11114);
            AddToDialogue(11115);
        }

        if (dialogueOptionID == 11120)
        {
            AddToDialogue(11120);
            DialoguePlayback.EndingDialogue = true;
        }

        if (dialogueOptionID == 11200)
        {
            DialoguePlayback.DeleteLineID = 11200;

            AddToDialogue(11200);
            AddToDialogue(11201);
            AddToDialogue(11202);
            AddToDialogue(11203);
            AddToDialogue(11204);
            AddToDialogue(11205);
            AddToDialogue(11206);
            AddToDialogue(11207);
        }

        if (dialogueOptionID == 11220)
        {
            DialoguePlayback.DeleteLineID = 11220;

            AddToDialogue(11220);
            AddToDialogue(11221);
            AddToDialogue(11222);
            AddToDialogue(11223);
            AddToDialogue(11224);
            AddToDialogue(11225);
            AddToDialogue(11226);
            AddToDialogue(11227);
            AddToDialogue(11228);
            AddToDialogue(11229);
        }

        if (dialogueOptionID == 11230)
        {
            AddToDialogue(11231);
            AddToDialogue(11232);
        }
    }

    private static void AddToDialogue(int dialogueID)
    {
        DialoguePlayback.AddToDialogue(dialogueID);
    }

    private bool IsLastBefore(int lastChosenOptionID, int dialogueOptionID)
    {
        if (PrecedingOptions[dialogueOptionID].Contains(lastChosenOptionID))
            return true;

        return false;
    }
}
