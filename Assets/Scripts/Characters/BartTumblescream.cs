using System.Collections.Generic;
using UnityEngine;

public class BartTumblescream : MonoBehaviour
{
    public static int CharacterSituation;
    public static BartTumblescream Instance;
    public Animator Animator;

    private static List<int> LastOptionsBefore12005 = new List<int>() { 12001 };
    private static List<int> LastOptionsBefore12006 = new List<int>() { 12001 };
    private static List<int> LastOptionsBefore12007 = new List<int>() { 12001 };
    private static List<int> LastOptionsBefore12008 = new List<int>() { 12001 };
    private static List<int> LastOptionsBefore12030 = new List<int>() { 12005, 12006, 12007, 12008 };
    private static List<int> LastOptionsBefore12035 = new List<int>() { 12005, 12006, 12007, 12008 };
    private static List<int> LastOptionsBefore12040 = new List<int>() { 12005, 12006, 12007, 12008 };
    private static List<int> LastOptionsBefore12045 = new List<int>() { 12005, 12006, 12007, 12008 };
    private static List<int> LastOptionsBefore12060 = new List<int>() { 12030, 12035, 12040, 12045, 12060 };

    private static List<int> LastOptionsBefore12065 = new List<int>() { 12030, 12035, 12040, 12045, 12060, //exit option
                                                        12100, 12200, 12210, 12230, 12245, 12355, 12360, 12370, 12375, 12380, 12390, 12400, 12410};
    
    private static List<int> LastOptionsBefore12070 = new List<int>() { 12200, 12210, 12230, 12245, 12355, 12360, 12370, 12375, 12380, 12390, 12400, 12410 };
    private static List<int> LastOptionsBefore12090 = new List<int>() { 12070, 12090, 12110 };
    private static List<int> LastOptionsBefore12100 = new List<int>() { 12070, 12090, 12110 };
    private static List<int> LastOptionsBefore12110 = new List<int>() { 12100, 12200, 12210, 12230, 12245, 12355, 12360, 12370, 12375, 12380, 12390, 12400, 12410 };
    private static List<int> LastOptionsBefore12200 = new List<int>() { 12100, 12230, 12245, 12355, 12360, 12370, 12375, 12380, 12390, 12400, 12410 };
    private static List<int> LastOptionsBefore12210 = new List<int>() { 12100, 12200, 12230, 12245, 12355, 12360, 12370, 12375, 12380, 12390, 12400, 12410 };
    private static List<int> LastOptionsBefore12245 = new List<int>() { 12100, 12200, 12210, 12230, 12245, 12355, 12360, 12370, 12375, 12380, 12390, 12400, 12410 };
    private static List<int> LastOptionsBefore12300 = new List<int>() { 12100, 12200, 12210, 12230, 12245, 12380, 12390, 12400, 12410 };

    private static List<int> LastOptionsBefore12310 = new List<int>() { 12300 };    // Bard's story
    private static List<int> LastOptionsBefore12320 = new List<int>() { 12300 };
    private static List<int> LastOptionsBefore12325 = new List<int>() { 12300 };
    private static List<int> LastOptionsBefore12335 = new List<int>() { 12310, 12320, 12325 };
    private static List<int> LastOptionsBefore12340 = new List<int>() { 12310, 12320, 12325 };
    private static List<int> LastOptionsBefore12345 = new List<int>() { 12310, 12320, 12325 };
    private static List<int> LastOptionsBefore12355 = new List<int>() { 12335, 12340, 12345 };
    private static List<int> LastOptionsBefore12360 = new List<int>() { 12335, 12340, 12345 };
    private static List<int> LastOptionsBefore12370 = new List<int>() { 12300, 12310, 12320, 12325, 12335, 12340, 12345 }; // I heard enough

    private static List<int> LastOptionsBefore12375 = new List<int>() { 12355, 12360, 12370, 12375, 12380 };// I forgot the story
    private static List<int> LastOptionsBefore12380 = new List<int>() { 12100, 12200, 12210, 12230, 12245, 12355, 12360, 12370, 12375, 12390, 12400, 12410 };
    private static List<int> LastOptionsBefore12390 = new List<int>() { 12100, 12200, 12210, 12230, 12245, 12355, 12360, 12370, 12375, 12380, 12410  };
    private static List<int> LastOptionsBefore12400 = new List<int>() { 12100, 12200, 12210, 12230, 12245, 12355, 12360, 12370, 12375, 12380, 12390, 12410 };

    private static Dictionary<int, List<int>> PrecedingOptions = new Dictionary<int, List<int>>()
    { 
        {12005, LastOptionsBefore12005},
        {12006, LastOptionsBefore12006},
        {12007, LastOptionsBefore12007},
        {12008, LastOptionsBefore12008},
        {12030, LastOptionsBefore12030},
        {12035, LastOptionsBefore12035},
        {12040, LastOptionsBefore12040},
        {12045, LastOptionsBefore12045},
        {12060, LastOptionsBefore12060},
        {12065, LastOptionsBefore12065},

        {12070, LastOptionsBefore12070},
        {12090, LastOptionsBefore12090},
        {12100, LastOptionsBefore12100},
        {12110, LastOptionsBefore12110},
        {12200, LastOptionsBefore12200},
        {12210, LastOptionsBefore12210},
        {12245, LastOptionsBefore12245},
        {12300, LastOptionsBefore12300},
        {12310, LastOptionsBefore12310},
        {12320, LastOptionsBefore12320},
        {12325, LastOptionsBefore12325},
        {12335, LastOptionsBefore12335},
        {12340, LastOptionsBefore12340},
        {12345, LastOptionsBefore12345},
        {12355, LastOptionsBefore12355},
        {12360, LastOptionsBefore12360},
        {12370, LastOptionsBefore12370},
        {12375, LastOptionsBefore12375},
        {12380, LastOptionsBefore12380},
        {12390, LastOptionsBefore12390},
        {12400, LastOptionsBefore12400},
    };

    public void Start()
    {
        Instance = this;

        Animator = GetComponentInChildren<Animator>();
    }

    public void StartDialogue()
    {
        DialogueManager.StartDialogueState(Character.Bart, 0);
    }

    public void DialogueLineNumberToSituation(int optionID)   //the last line of dialogue determines which situation will follow
    {        

        if (IsLastBefore(optionID, 12005))
            DialogueMenu.AddToDialogueOptions(12005);
        if (IsLastBefore(optionID, 12006))
            DialogueMenu.AddToDialogueOptions(12006); 
        if (IsLastBefore(optionID, 12007))
            DialogueMenu.AddToDialogueOptions(12007);
        if (IsLastBefore(optionID, 12008))
            DialogueMenu.AddToDialogueOptions(12008);
        if (IsLastBefore(optionID, 12030))
            DialogueMenu.AddToDialogueOptions(12030);
        if (IsLastBefore(optionID, 12035))
            DialogueMenu.AddToDialogueOptions(12035);
        if (IsLastBefore(optionID, 12040))
            DialogueMenu.AddToDialogueOptions(12040);
        if (IsLastBefore(optionID, 12045))
            DialogueMenu.AddToDialogueOptions(12045);
        if (IsLastBefore(optionID, 12060))
            DialogueMenu.AddToDialogueOptions(12060);
        if (IsLastBefore(optionID, 12070))
            DialogueMenu.AddToDialogueOptions(12070);
        if (IsLastBefore(optionID, 12090))
            DialogueMenu.AddToDialogueOptions(12090);
        if (IsLastBefore(optionID, 12100))
            DialogueMenu.AddToDialogueOptions(12100);
        if (IsLastBefore(optionID, 12110) && DialogueManager.IsDialoguePassed(12070))
            DialogueMenu.AddToDialogueOptions(12110);
        if (IsLastBefore(optionID, 12200) && WorldEvents.ReceivedBookOfMusicalWildlife)
            DialogueMenu.AddToDialogueOptions(12200);
        if (IsLastBefore(optionID, 12210) && DialogueManager.IsDialoguePassed(12200))
            DialogueMenu.AddToDialogueOptions(12210);
        if (IsLastBefore(optionID, 12245))
            DialogueMenu.AddToDialogueOptions(12245);
        if (IsLastBefore(optionID, 12300) && WorldEvents.NeedsToKnowWhatSacrificeIs)
            DialogueMenu.AddToDialogueOptions(12300);
        if (IsLastBefore(optionID, 12310))
            DialogueMenu.AddToDialogueOptions(12310);
        if (IsLastBefore(optionID, 12320))
            DialogueMenu.AddToDialogueOptions(12320);
        if (IsLastBefore(optionID, 12325))
            DialogueMenu.AddToDialogueOptions(12325);
        if (IsLastBefore(optionID, 12335))
            DialogueMenu.AddToDialogueOptions(12335);
        if (IsLastBefore(optionID, 12340))
            DialogueMenu.AddToDialogueOptions(12340);
        if (IsLastBefore(optionID, 12345))
            DialogueMenu.AddToDialogueOptions(12345);
        if (IsLastBefore(optionID, 12355))
            DialogueMenu.AddToDialogueOptions(12355);
        if (IsLastBefore(optionID, 12360))
            DialogueMenu.AddToDialogueOptions(12360);
        if (IsLastBefore(optionID, 12370) && DialogueManager.IsDialoguePassed(12300) && WorldEvents.KnowsWhatSacrificeIs)
            DialogueMenu.AddToDialogueOptions(12370);
        if (IsLastBefore(optionID, 12375) && DialogueManager.IsDialoguePassed(12300) && WorldEvents.KnowsWhatSacrificeIs)
            DialogueMenu.AddToDialogueOptions(12375);
        if (IsLastBefore(optionID, 12380))
            DialogueMenu.AddToDialogueOptions(12380);
        if (IsLastBefore(optionID, 12390))
            DialogueMenu.AddToDialogueOptions(12390);
        if (IsLastBefore(optionID, 12400) && DialogueManager.IsDialoguePassed(12390))
            DialogueMenu.AddToDialogueOptions(12400);
        if (IsLastBefore(optionID, 12065))  // exit option
            DialogueMenu.AddToDialogueOptions(12065);
       

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
                if (!WorldEvents.PassedIntroduction)
                {
                    AddToDialogue(12001);
                    AddToDialogue(12002);
                    AddToDialogue(12003);
                    AddToDialogue(12004);

                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(12001);
                }
                else
                {
                    DialogueMenu.AddToDialogueOptions(12060);
                    DialogueMenu.AddToDialogueOptions(12065);

                    DialogueMenu.FindVisibleDialogueOptions(Character.Bart);
                }
                break;
            case 2: //SITUATION 2
                if (WorldEvents.PeopleNotGoingToGallery >= 2 && !WorldEvents.IsAfterGoldenScreech && WorldEvents.LookingForGalleryVisitors)
                {   //people find it dull. Bart: you should get the screech.
                    DialoguePlayback.DeleteLineID = 16040;  //we now cannot get the same info from mister B.

                    AddToDialogue(12230);

                    DialoguePlayback.DeleteLineID = 16055;

                    AddToDialogue(12231);

                    DialoguePlayback.DeleteLineID = 12230;

                    AddToDialogue(12232);
                    AddToDialogue(12233);
                    AddToDialogue(12234);
                    AddToDialogue(12235);
                    AddToDialogue(12236);
                    AddToDialogue(12237);
                    AddToDialogue(12238);
                    AddToDialogue(12239);
                    AddToDialogue(12240);
                    AddToDialogue(12241);


                    Debug.Log("It should delete line 16040 now! ");
                    WorldEvents.IsAfterGoldenScreech = true;
                    WorldEvents.LookingForGalleryVisitors = false;

                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(12230);
                }
                else if(WorldEvents.SpokeToMrB && !WorldEvents.IsAfterGoldenScreech && !WorldEvents.LookingForGalleryVisitors)
                {   //I saw Mister B. He says the galler is unpopular. Bart: go find people!
                    AddToDialogue(12220);
                    AddToDialogue(12221);
                    AddToDialogue(12222);
                    AddToDialogue(12223);

                    DialoguePlayback.EndingDialogue = true;

                    WorldEvents.LookingForGalleryVisitors = true;

                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(12220);

                }
                else 
                {   //Emmon is after the screech
                    AddToDialogue(12410);   // hi dad

                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(12410);
                }
                    break;
            default: //in all other dialogue options
                DialogueMenu.FindVisibleDialogueOptions(Character.Bart);
                break;
        }
    }

    public static void TriggerDialogue(int dialogueOptionID)
    {
        if (dialogueOptionID == 12005)
        {
            AddToDialogue(12005);
            AddToDialogue(12010);
            AddToDialogue(12011);
            AddToDialogue(12012);
            AddToDialogue(12013);
            AddToDialogue(12014);
            AddToDialogue(12015);
            AddToDialogue(12016);
            AddToDialogue(12017);
            AddToDialogue(12018);
            AddToDialogue(12019);
        }

        if (dialogueOptionID == 12006)
        {
            AddToDialogue(12006);
            AddToDialogue(12010);
            AddToDialogue(12011);
            AddToDialogue(12012);
            AddToDialogue(12013);
            AddToDialogue(12014);
            AddToDialogue(12015);
            AddToDialogue(12016);
            AddToDialogue(12017);
            AddToDialogue(12018);
            AddToDialogue(12019);
        }

        if (dialogueOptionID == 12007)
        {
            AddToDialogue(12007);
            AddToDialogue(12010);
            AddToDialogue(12011);
            AddToDialogue(12012);
            AddToDialogue(12013);
            AddToDialogue(12014);
            AddToDialogue(12015);
            AddToDialogue(12016);
            AddToDialogue(12017);
            AddToDialogue(12018);
            AddToDialogue(12019);
        }

        if (dialogueOptionID == 12008)
        {
            AddToDialogue(12008);
            AddToDialogue(12010);
            AddToDialogue(12011);
            AddToDialogue(12012);
            AddToDialogue(12013);
            AddToDialogue(12014);
            AddToDialogue(12015);
            AddToDialogue(12016);
            AddToDialogue(12017);
            AddToDialogue(12018);
            AddToDialogue(12019);
        }

        if (dialogueOptionID == 12030)
        {
            AddToDialogue(12030);
            AddToDialogue(12031);
            AddToDialogue(12032);
            AddToDialogue(12033);
            AddToDialogue(12034);
            AddToDialogue(12050);
            AddToDialogue(12051);
            AddToDialogue(12052);
            AddToDialogue(12053);
            AddToDialogue(12054);
            AddToDialogue(12055);

            WorldEvents.PassedIntroduction = true;
        }

        if (dialogueOptionID == 12035)
        {
            AddToDialogue(12035);
            AddToDialogue(12036);
            AddToDialogue(12050);
            AddToDialogue(12051);
            AddToDialogue(12052);
            AddToDialogue(12053);
            AddToDialogue(12054);
            AddToDialogue(12055);

            WorldEvents.PassedIntroduction = true;
        }

        if (dialogueOptionID == 12040)
        {
            AddToDialogue(12040);
            AddToDialogue(12041);
            AddToDialogue(12042);
            AddToDialogue(12050);
            AddToDialogue(12051);
            AddToDialogue(12052);
            AddToDialogue(12053);
            AddToDialogue(12054);
            AddToDialogue(12055);

            WorldEvents.PassedIntroduction = true;
        }

        if (dialogueOptionID == 12045)
        {
            AddToDialogue(12045);
            AddToDialogue(12046);
            AddToDialogue(12050);
            AddToDialogue(12051);
            AddToDialogue(12052);
            AddToDialogue(12053);
            AddToDialogue(12054);
            AddToDialogue(12055);

            WorldEvents.PassedIntroduction = true;
        }

        if (dialogueOptionID == 12060)
        {
            AddToDialogue(12060);
            AddToDialogue(12061);
        }

        if (dialogueOptionID == 12070)
        {
            DialoguePlayback.DeleteLineID = 12070;

            AddToDialogue(12070);
            AddToDialogue(12071);
            AddToDialogue(12072);
            AddToDialogue(12073);
            AddToDialogue(12074);
            AddToDialogue(12075);
            AddToDialogue(12076);
            AddToDialogue(12077);
            AddToDialogue(12078);
            AddToDialogue(12079);
            AddToDialogue(12080);
            AddToDialogue(12081);
            AddToDialogue(12082);
            AddToDialogue(12083);
            AddToDialogue(12084);
            AddToDialogue(12085);
            AddToDialogue(12086);
            AddToDialogue(12087);

            ItemManager.AddItem(ItemType.BookOfMusicalWildlife);
            WorldEvents.ReceivedBookOfMusicalWildlife = true;
        }

        if (dialogueOptionID == 12090)
        {
            AddToDialogue(12090);
            AddToDialogue(12091);
            AddToDialogue(12092);
        }

        if (dialogueOptionID == 12100)
        {
            AddToDialogue(12100);
            AddToDialogue(12101);
        }

        if (dialogueOptionID == 12110)
        {
            AddToDialogue(12110);
            AddToDialogue(12111);
        }

        if (dialogueOptionID == 12200)
        {
            DialoguePlayback.DeleteLineID = 12200;

            AddToDialogue(12200);
            AddToDialogue(12201);
            AddToDialogue(12202);
            AddToDialogue(12203);
            AddToDialogue(12204);
            AddToDialogue(12205);
            AddToDialogue(12206);
        }

        if (dialogueOptionID == 12210)
        {
            DialoguePlayback.DeleteLineID = 12210;

            AddToDialogue(12210);
            AddToDialogue(12211);
            AddToDialogue(12212);
            AddToDialogue(12213);
        }

        if (dialogueOptionID == 12245)
        {
            AddToDialogue(12245);
            AddToDialogue(12246);
            AddToDialogue(12247);
        }

        if (dialogueOptionID == 12300)
        {
            DialoguePlayback.DeleteLineID = 12300;

            AddToDialogue(12300);
            AddToDialogue(12301);
            AddToDialogue(12302);
            AddToDialogue(12303);
            AddToDialogue(12204);
            AddToDialogue(12205);
        }

        if (dialogueOptionID == 12310)
        {
            AddToDialogue(12310);
            AddToDialogue(12311);
            AddToDialogue(12312);
            AddToDialogue(12313);
            AddToDialogue(12326);
            AddToDialogue(12327);
            AddToDialogue(12328);
            AddToDialogue(12329);
            AddToDialogue(12330);
            AddToDialogue(12331);
            AddToDialogue(12332);
        }

        if (dialogueOptionID == 12320)
        {
            AddToDialogue(12320);
            AddToDialogue(12321);
            AddToDialogue(12322);
            AddToDialogue(12326);
            AddToDialogue(12327);
            AddToDialogue(12328);
            AddToDialogue(12329);
            AddToDialogue(12330);
            AddToDialogue(12331);
            AddToDialogue(12332);
        }

        if (dialogueOptionID == 12325)
        {
            AddToDialogue(12325);
            AddToDialogue(12326);
            AddToDialogue(12327);
            AddToDialogue(12328);
            AddToDialogue(12329);
            AddToDialogue(12330);
            AddToDialogue(12331);
            AddToDialogue(12332);
        }

        if (dialogueOptionID == 12335)
        {
            AddToDialogue(12336);
            AddToDialogue(12337);
            AddToDialogue(12350);
            AddToDialogue(12351);
        }

        if (dialogueOptionID == 12340)
        {
            AddToDialogue(12340);
            AddToDialogue(12341);
            AddToDialogue(12350);
            AddToDialogue(12351);
        }

        if (dialogueOptionID == 12345)
        {
            AddToDialogue(12346);
            AddToDialogue(12347);
            AddToDialogue(12350);
            AddToDialogue(12351);
        }

        if (dialogueOptionID == 12355)
        {
            AddToDialogue(12355);
            AddToDialogue(12356);
            AddToDialogue(12360);
            AddToDialogue(12361);
            AddToDialogue(12362);
            AddToDialogue(12363);
            AddToDialogue(12364);
            AddToDialogue(12365);
            AddToDialogue(12366);
            AddToDialogue(12367);
            AddToDialogue(12368);

            WorldEvents.KnowsWhatSacrificeIs = true;
            WorldEvents.NeedsToKnowWhatSacrificeIs = false;
        }

        if (dialogueOptionID == 12360)
        {
            AddToDialogue(12360);
            AddToDialogue(12361);
            AddToDialogue(12362);
            AddToDialogue(12363);
            AddToDialogue(12364);
            AddToDialogue(12365);
            AddToDialogue(12366);
            AddToDialogue(12367);
            AddToDialogue(12368);

            WorldEvents.KnowsWhatSacrificeIs = true;
            WorldEvents.NeedsToKnowWhatSacrificeIs = false;
        }

        if (dialogueOptionID == 12370)
        {
            AddToDialogue(12370);
        }

        if (dialogueOptionID == 12375)
        {
            AddToDialogue(12375);
            AddToDialogue(12376);
            AddToDialogue(12377);
            AddToDialogue(12378);
        }

        if (dialogueOptionID == 12380)
        {
            DialoguePlayback.DeleteLineID = 12380;

            AddToDialogue(12380);
            AddToDialogue(12381);
            AddToDialogue(12382);
            AddToDialogue(12383);
        }

        if (dialogueOptionID == 12390)
        {
            DialoguePlayback.DeleteLineID = 12390;

            AddToDialogue(12390);
            AddToDialogue(12391);
            AddToDialogue(12392);
            AddToDialogue(12393);
        }

        if (dialogueOptionID == 12400)
        {
            DialoguePlayback.DeleteLineID = 12400;

            AddToDialogue(12400);
            AddToDialogue(12401);
            AddToDialogue(12402);
            AddToDialogue(12403);
        }

        if (dialogueOptionID == 12065)
        {
            int rand = Random.Range(12065, 12067);
            Debug.Log("random was: " + rand);
            AddToDialogue(rand);

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
