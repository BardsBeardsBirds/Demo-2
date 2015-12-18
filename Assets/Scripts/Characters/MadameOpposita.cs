using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MadameOpposita : MonoBehaviour
{
    public static int CharacterSituation;
    public static MadameOpposita Instance;
    public Animator Animator;
    

    private static List<int> LastOptionsBefore15025 = new List<int>() { 15010, 15030, 15040, 15050 };
    private static List<int> LastOptionsBefore15030 = new List<int>() { 15010, 15025, 15040, 15050 };
    private static List<int> LastOptionsBefore15040 = new List<int>() { 15010, 15025, 15030, 15050 };
    private static List<int> LastOptionsBefore15050 = new List<int>() { 15010, 15025, 15030, 15040 };
    private static List<int> LastOptionsBefore15070 = new List<int>() { 15025, 15030, 15040, 15050 };  
    private static List<int> LastOptionsBefore15095 = new List<int>() { 15050, 15080, 15090, 15410, 15379, 15393, 15405, 15425 };
    private static List<int> LastOptionsBefore15100 = new List<int>() { 15050, 15080, 15090, 15100, 15410, 15379, 15393, 15405, 15425 };
    private static List<int> LastOptionsBefore15200 = new List<int>() { 15050, 15080, 15090, 15100, 15410, 15425 };
    private static List<int> LastOptionsBefore15210 = new List<int>() { 15200  };
    private static List<int> LastOptionsBefore15220 = new List<int>() { 15200  };
    private static List<int> LastOptionsBefore15230 = new List<int>() { 15200  };
    private static List<int> LastOptionsBefore15240 = new List<int>() { 15200  };
    private static List<int> LastOptionsBefore15260 = new List<int>() { 15210, 15220, 15230, 15240 };
    private static List<int> LastOptionsBefore15265 = new List<int>() { 15210, 15220, 15230, 15240 };
    private static List<int> LastOptionsBefore15270 = new List<int>() { 15210, 15220, 15230, 15240 };
    private static List<int> LastOptionsBefore15290 = new List<int>() { 15260, 15265, 15270 };
    private static List<int> LastOptionsBefore15300 = new List<int>() { 15260, 15265, 15270 };
    private static List<int> LastOptionsBefore15305 = new List<int>() { 15260, 15265, 15270 };
    private static List<int> LastOptionsBefore15308 = new List<int>() { 15260, 15265, 15270 };
    private static List<int> LastOptionsBefore15320 = new List<int>() { 15290, 15300, 15305, 15308 };
    private static List<int> LastOptionsBefore15330 = new List<int>() { 15290, 15300, 15305, 15308 };
    private static List<int> LastOptionsBefore15340 = new List<int>() { 15290, 15300, 15305, 15308 };
    private static List<int> LastOptionsBefore15350 = new List<int>() { 15290, 15300, 15305, 15308 };
    private static List<int> LastOptionsBefore15370 = new List<int>() { 15320, 15330, 15340, 15350, 15390 };
    private static List<int> LastOptionsBefore15379 = new List<int>() { 15320, 15330, 15340, 15350, 15370, 15390 };
    private static List<int> LastOptionsBefore15390 = new List<int>() { 15320, 15330, 15340, 15350, 15370 };
    private static List<int> LastOptionsBefore15393 = new List<int>() { 15320, 15330, 15340, 15350, 15370, 15390 };
    private static List<int> LastOptionsBefore15405 = new List<int>() { 15100, 15379, 15393, 15405, 15410 };
    private static List<int> LastOptionsBefore15410 = new List<int>() { 15050, 15080, 15090, 15100, 15379, 15393, 15405, 15410, 15425 };
    private static List<int> LastOptionsBefore15420 = new List<int>() { 15050, 15080, 15090, 15410, 15425 };
    private static List<int> LastOptionsBefore15500 = new List<int>() { 15050, 15080, 15090, 15100, 15379, 15393, 15405, 15410, 15425 };
    private static List<int> LastOptionsBefore15502 = new List<int>() { 15050, 15080, 15090, 15100, 15379, 15393, 15405, 15410, 15425 };

    private static List<int> LastOptionsBefore15810 = new List<int>() { 15800, 15810, 15813, 15820, 15830 };
    private static List<int> LastOptionsBefore15813 = new List<int>() { 15800, 15810, 15813, 15820, 15830 };
    private static List<int> LastOptionsBefore15820 = new List<int>() { 15800, 15810, 15813, 15820, 15830 };
    private static List<int> LastOptionsBefore15830 = new List<int>() { 15800, 15810, 15813, 15820, 15830 };


    private static Dictionary<int, List<int>> PrecedingOptions = new Dictionary<int, List<int>>()
    { 
        {15025, LastOptionsBefore15025},
        {15030, LastOptionsBefore15030},
        {15040, LastOptionsBefore15040},
        {15050, LastOptionsBefore15050},
        {15070, LastOptionsBefore15070},
        {15095, LastOptionsBefore15095},
        {15100, LastOptionsBefore15100},
        {15200, LastOptionsBefore15200},
        {15210, LastOptionsBefore15210},
        {15220, LastOptionsBefore15220},
        {15230, LastOptionsBefore15230},
        {15240, LastOptionsBefore15240},
        {15260, LastOptionsBefore15260},
        {15265, LastOptionsBefore15265},
        {15270, LastOptionsBefore15270},
        {15290, LastOptionsBefore15290},
        {15300, LastOptionsBefore15300},
        {15305, LastOptionsBefore15305},
        {15308, LastOptionsBefore15308},
        {15320, LastOptionsBefore15320},
        {15330, LastOptionsBefore15330},
        {15340, LastOptionsBefore15340},
        {15350, LastOptionsBefore15350},
        {15370, LastOptionsBefore15370},
        {15379, LastOptionsBefore15379},
        {15390, LastOptionsBefore15390},
        {15393, LastOptionsBefore15393},
        {15405, LastOptionsBefore15405},
        {15410, LastOptionsBefore15410},
        {15420, LastOptionsBefore15420},
        {15500, LastOptionsBefore15500},
        {15502, LastOptionsBefore15502},
   //     {15503, LastOptionsBefore15503},
      //  {15510, LastOptionsBefore15510},
        {15810, LastOptionsBefore15810},
        {15813, LastOptionsBefore15813},
        {15820, LastOptionsBefore15820},
        {15830, LastOptionsBefore15830},

    };

    public void Start()
    {
        Instance = this;
        CharacterSituation = 1;
        Animator = GetComponent<Animator>();
    }

    public void StartDialogue()
    {
        DialogueManager.StartDialogueState(Character.Opposita, 0);
    }

    public void StartDialogue(int forcedDialogue)
    {
        DialogueManager.StartDialogueState(Character.Opposita, forcedDialogue);
    }

    public void DialogueLineNumberToSituation(int optionID)
    {
        Debug.Log("look for situations of " + optionID);
        if (IsLastBefore(optionID, 15025))
            DialogueMenu.AddToDialogueOptions(15025);

        if (IsLastBefore(optionID, 15030))
            DialogueMenu.AddToDialogueOptions(15030);

        if (IsLastBefore(optionID, 15040))
            DialogueMenu.AddToDialogueOptions(15040);
      
        if (IsLastBefore(optionID, 15050))
            DialogueMenu.AddToDialogueOptions(15050);

        if (IsLastBefore(optionID, 15070) && WorldEvents.OppositaRevealedScissors)
            DialogueMenu.AddToDialogueOptions(15070);

        if (IsLastBefore(optionID, 15100) && WorldEvents.OppositaRevealedScissors)
            DialogueMenu.AddToDialogueOptions(15100);
      
        if (IsLastBefore(optionID, 15200)  && WorldEvents.NeedsToKnowWhatSacrificeIs)
            DialogueMenu.AddToDialogueOptions(15200);
      
        if (IsLastBefore(optionID, 15210))
            DialogueMenu.AddToDialogueOptions(15210);
            
        if (IsLastBefore(optionID, 15220))
            DialogueMenu.AddToDialogueOptions(15220);
            
        if (IsLastBefore(optionID, 15230))
            DialogueMenu.AddToDialogueOptions(15230);
            
        if (IsLastBefore(optionID, 15240))
            DialogueMenu.AddToDialogueOptions(15240);
            
        if (IsLastBefore(optionID, 15260))
            DialogueMenu.AddToDialogueOptions(15260);
            
        if (IsLastBefore(optionID, 15265))
            DialogueMenu.AddToDialogueOptions(15265);
      
        if (IsLastBefore(optionID, 15270))
            DialogueMenu.AddToDialogueOptions(15270);
      
        if (IsLastBefore(optionID, 15290))
            DialogueMenu.AddToDialogueOptions(15290);
      
        if (IsLastBefore(optionID, 15300))
            DialogueMenu.AddToDialogueOptions(15300);

        if (IsLastBefore(optionID, 15305))
            DialogueMenu.AddToDialogueOptions(15305);

        if (IsLastBefore(optionID, 15308))
            DialogueMenu.AddToDialogueOptions(15308);
      
        if (IsLastBefore(optionID, 15320))
            DialogueMenu.AddToDialogueOptions(15320);
            
        if (IsLastBefore(optionID, 15330))
            DialogueMenu.AddToDialogueOptions(15330);
            
        if (IsLastBefore(optionID, 15340))
            DialogueMenu.AddToDialogueOptions(15340);
            
        if (IsLastBefore(optionID, 15350))
            DialogueMenu.AddToDialogueOptions(15350);
            
        if (IsLastBefore(optionID, 15370))
            DialogueMenu.AddToDialogueOptions(15370);
            
        if (IsLastBefore(optionID, 15379))
            DialogueMenu.AddToDialogueOptions(15379);
            
        if (IsLastBefore(optionID, 15390))
            DialogueMenu.AddToDialogueOptions(15390);
                  
        if (IsLastBefore(optionID, 15393))
            DialogueMenu.AddToDialogueOptions(15393);

        if (IsLastBefore(optionID, 15405) && DialogueManager.IsDialoguePassed(15200))   //what was the sacrifice again? 
            DialogueMenu.AddToDialogueOptions(15405);
                  
        if (IsLastBefore(optionID, 15410))
            DialogueMenu.AddToDialogueOptions(15410);

        if (IsLastBefore(optionID, 15420) && WorldEvents.OppositaRevealedScissors)  // I brought some tea leaves
            if (GameManager.Instance.MyInventory.LookForItem(ItemType.TeaLeaves))
            {
                DialogueMenu.AddToDialogueOptions(15420);
                if (DialogueMenu.AllDialogueOptionsID.Contains(15100))
                    DialogueMenu.AllDialogueOptionsID.Remove(15100);
            }

        if (IsLastBefore(optionID, 15500))
            DialogueMenu.AddToDialogueOptions(15500);

        if (IsLastBefore(optionID, 15502) && DialogueManager.IsDialoguePassed(15500))
            DialogueMenu.AddToDialogueOptions(15502);
                  
        //if (IsLastBefore(optionID, 15503))
        //    DialogueMenu.AddToDialogueOptions(15503);
                  
        //if (IsLastBefore(optionID, 15510))
        //    DialogueMenu.AddToDialogueOptions(15510);

        if (IsLastBefore(optionID, 15095))                  //exit
            DialogueMenu.AddToDialogueOptions(15095);
                  
        if (IsLastBefore(optionID, 15810))
            DialogueMenu.AddToDialogueOptions(15810);
                  
        if (IsLastBefore(optionID, 15813))
            DialogueMenu.AddToDialogueOptions(15813);
                  
        if (IsLastBefore(optionID, 15820))
            DialogueMenu.AddToDialogueOptions(15820);
                  
        if (IsLastBefore(optionID, 15830))
            DialogueMenu.AddToDialogueOptions(15830);

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
            case 4:
                FindDialogueSituation(4);
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
                AddToDialogue(15001);
                AddToDialogue(15002);
                AddToDialogue(15003);

                DialoguePlayback.EndingDialogue = true;

                DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(15001);

                break;
            case 2: //SITUATION 2   
                if (!WorldEvents.SpokeToOpposita && WorldEvents.LookingForGalleryVisitors)
                {
                    AddToDialogue(15010);
                    AddToDialogue(15011);
                    AddToDialogue(15012);
                    AddToDialogue(15013);
                    AddToDialogue(15020);
                    AddToDialogue(15021);
                    AddToDialogue(15022);

                    WorldEvents.SpokeToOpposita = true;
                    WorldEvents.PeopleNotGoingToGallery = WorldEvents.PeopleNotGoingToGallery + 1;

                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(15010);
                }
                else
                {
                    AddToDialogue(15003);

                    DialoguePlayback.EndingDialogue = true;
                    
                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(15001);

                }
                break;
            case 3: // SITUATION 3
                if (!WorldEvents.SpokeToOpposita)
                {
                    AddToDialogue(15080);
                    AddToDialogue(15081);
                    AddToDialogue(15020);
                    AddToDialogue(15021);
                    AddToDialogue(15022);
                    AddToDialogue(15020);
                    AddToDialogue(15021);
                    AddToDialogue(15022);

                    WorldEvents.SpokeToOpposita = true;
                    
                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(15080);
                }
                else if(WorldEvents.OppositaIsCrying)
                {
                    AddToDialogue(15425);
                    AddToDialogue(15426);
                    AddToDialogue(15427);

                    WorldEvents.OppositaIsCrying = false;

                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(15425);
                }
                else
                {
                    AddToDialogue(15090);
                    AddToDialogue(15091);
                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(15090);
                }
                break;

            case 4: // SITUATION 4
                AddToDialogue(15800);

                DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(15800);
                break;
            default: //in all other dialogue options
                DialogueMenu.FindVisibleDialogueOptions(Character.Opposita);
                break;
        }
    }

    public static void TriggerDialogue(int dialogueOptionID)
    {
        if (dialogueOptionID == 15025)
        {
            DialoguePlayback.DeleteLineID = 15025;

            AddToDialogue(15025);
            AddToDialogue(15026);
        }

        if (dialogueOptionID == 15030)
        {
            DialoguePlayback.DeleteLineID = 15030;

            AddToDialogue(15030);
            AddToDialogue(15031);
        }

        if (dialogueOptionID == 15040)
        {
            DialoguePlayback.DeleteLineID = 15040;

            AddToDialogue(15040);
            AddToDialogue(15041);
            AddToDialogue(15042);
        }

        if (dialogueOptionID == 15050)
        {
            DialoguePlayback.DeleteLineID = 15050;

            AddToDialogue(15050);
            AddToDialogue(15051);
            AddToDialogue(15052);
            AddToDialogue(15053);
            AddToDialogue(15054);
            AddToDialogue(15055);
            AddToDialogue(15056);
            AddToDialogue(15057);
            AddToDialogue(15058);
            AddToDialogue(15059);
            AddToDialogue(15060);
            AddToDialogue(15061);
            AddToDialogue(15062);
            AddToDialogue(15063);
            AddToDialogue(15064);

            WorldEvents.OppositaRevealedScissors = true;
            InGameObjectManager.Instance.ItemEnablerGO.EnableItem(ItemType.Scissors);

        }

        if (dialogueOptionID == 15100)//obsoletes only when Emmon has tea leaves
        {
            AddToDialogue(15100);
            AddToDialogue(15101);
            AddToDialogue(15102);
            AddToDialogue(15103);
        }

        if (dialogueOptionID == 15200)
        {
            AddToDialogue(15200);
            AddToDialogue(15201);
            AddToDialogue(15202);
            AddToDialogue(15203);
            AddToDialogue(15204);
            AddToDialogue(15205);
            AddToDialogue(15206);
        }

        if (dialogueOptionID == 15210)
        {
            AddToDialogue(15210);
            AddToDialogue(15211);
            AddToDialogue(15250);
            AddToDialogue(15251);
            AddToDialogue(15252);
        }

        if (dialogueOptionID == 15220)
        {
            AddToDialogue(15220);
            AddToDialogue(15221);
            AddToDialogue(15222);
            AddToDialogue(15250);
            AddToDialogue(15251);
            AddToDialogue(15252);
        }

        if (dialogueOptionID == 15230)
        {
            AddToDialogue(15230);
            AddToDialogue(15231);
            AddToDialogue(15232);
            AddToDialogue(15233);
            AddToDialogue(15250);
            AddToDialogue(15251);
            AddToDialogue(15252);
        }

        if (dialogueOptionID == 15240)
        {
            AddToDialogue(15240);
            AddToDialogue(15241);
            AddToDialogue(15242);
            AddToDialogue(15250);
            AddToDialogue(15251);
            AddToDialogue(15252);
        }

        if (dialogueOptionID == 15260)
        {
            AddToDialogue(15260);
            AddToDialogue(15261);
            AddToDialogue(15262);
            AddToDialogue(15271);
            AddToDialogue(15272);
            AddToDialogue(15273);
            AddToDialogue(15274);
            AddToDialogue(15275);
            AddToDialogue(15276);
            AddToDialogue(15277);
            AddToDialogue(15278);
            AddToDialogue(15279);
            AddToDialogue(15280);
        }

        if (dialogueOptionID == 15265)
        {
            AddToDialogue(15265);
            AddToDialogue(15271);
            AddToDialogue(15272);
            AddToDialogue(15273);
            AddToDialogue(15274);
            AddToDialogue(15275);
            AddToDialogue(15276);
            AddToDialogue(15277);
            AddToDialogue(15278);
            AddToDialogue(15279);
            AddToDialogue(15280);
        }

        if (dialogueOptionID == 15270)
        {
            AddToDialogue(15270);
            AddToDialogue(15271);
            AddToDialogue(15272);
            AddToDialogue(15273);
            AddToDialogue(15274);
            AddToDialogue(15275);
            AddToDialogue(15276);
            AddToDialogue(15277);
            AddToDialogue(15278);
            AddToDialogue(15279);
            AddToDialogue(15280);
        }

        if (dialogueOptionID == 15290)
        {
            AddToDialogue(15290);
            AddToDialogue(15291);
            AddToDialogue(15311);
            AddToDialogue(15312);
            AddToDialogue(15313);
            AddToDialogue(15314);
            AddToDialogue(15315);
            AddToDialogue(15316);
        }

        if (dialogueOptionID == 15300)
        {
            AddToDialogue(15300);
            AddToDialogue(15301);
            AddToDialogue(15302);
            AddToDialogue(15303);
            AddToDialogue(15304);
            AddToDialogue(15310);
            AddToDialogue(15311);
            AddToDialogue(15312);
            AddToDialogue(15313);
            AddToDialogue(15314);
            AddToDialogue(15315);
            AddToDialogue(15316);
        }

        if (dialogueOptionID == 15305)
        {
            AddToDialogue(15305);
            AddToDialogue(15306);
            AddToDialogue(15307);
            AddToDialogue(15308);
            AddToDialogue(15309);
            AddToDialogue(15310);
            AddToDialogue(15311);
            AddToDialogue(15312);
            AddToDialogue(15313);
            AddToDialogue(15314);
            AddToDialogue(15315);
            AddToDialogue(15316);
        }

        if (dialogueOptionID == 15308)
        {
            AddToDialogue(15308);
            AddToDialogue(15309);
            AddToDialogue(15310);
            AddToDialogue(15311);
            AddToDialogue(15312);
            AddToDialogue(15313);
            AddToDialogue(15314);
            AddToDialogue(15315);
            AddToDialogue(15316);
        }

        if (dialogueOptionID == 15320)
        {
            AddToDialogue(15321);
            AddToDialogue(15322);
            AddToDialogue(15360);
            AddToDialogue(15361);
            AddToDialogue(15362);
            AddToDialogue(15363);
            AddToDialogue(15364);
            AddToDialogue(15365);
            AddToDialogue(15366);
        }

        if (dialogueOptionID == 15330)
        {
            AddToDialogue(15331);
            AddToDialogue(15332);
            AddToDialogue(15342);
            AddToDialogue(15360);
            AddToDialogue(15361);
            AddToDialogue(15362);
            AddToDialogue(15363);
            AddToDialogue(15364);
            AddToDialogue(15365);
            AddToDialogue(15366);
        }

        if (dialogueOptionID == 15340)
        {
            AddToDialogue(15340);
            AddToDialogue(15341);
            AddToDialogue(15342);
            AddToDialogue(15360);
            AddToDialogue(15361);
            AddToDialogue(15362);
            AddToDialogue(15363);
            AddToDialogue(15364);
            AddToDialogue(15365);
            AddToDialogue(15366);
        }

        if (dialogueOptionID == 15350)
        {
            AddToDialogue(15350);
            AddToDialogue(15351);
            AddToDialogue(15360);
            AddToDialogue(15361);
            AddToDialogue(15362);
            AddToDialogue(15363);
            AddToDialogue(15364);
            AddToDialogue(15365);
            AddToDialogue(15366);
        }

        if (dialogueOptionID == 15370)
        {
            DialoguePlayback.DeleteLineID = 15200;

            AddToDialogue(15371);
            AddToDialogue(15372);
        }

        if (dialogueOptionID == 15379)
        {
            DialoguePlayback.DeleteLineID = 15200;

            AddToDialogue(15380);
            AddToDialogue(15381);
            AddToDialogue(15382);
            AddToDialogue(15396);
            AddToDialogue(15397);
            AddToDialogue(15398);
            AddToDialogue(15399);

            WorldEvents.KnowsWhatSacrificeIs = true; 
            WorldEvents.NeedsToKnowWhatSacrificeIs = false;
        }

        if (dialogueOptionID == 15390)
        {
            DialoguePlayback.DeleteLineID = 15200;

            AddToDialogue(15390);
            AddToDialogue(15391);
            AddToDialogue(15392);
        }

        if (dialogueOptionID == 15393)
        {
            DialoguePlayback.DeleteLineID = 15200;

            AddToDialogue(15393);
            AddToDialogue(15394);
            AddToDialogue(15395);
            AddToDialogue(15396);
            AddToDialogue(15397);
            AddToDialogue(15398);
            AddToDialogue(15399);

            WorldEvents.KnowsWhatSacrificeIs = true;
            WorldEvents.NeedsToKnowWhatSacrificeIs = false;
        }

        if (dialogueOptionID == 15400)
        {
            AddToDialogue(15400);
        }

        if (dialogueOptionID == 15405)
        {
            AddToDialogue(15406);
            AddToDialogue(15407);
        }

        if (dialogueOptionID == 15410)
        {
            DialoguePlayback.DeleteLineID = 15410;

            AddToDialogue(15410);
            AddToDialogue(15411);
            AddToDialogue(15412);
        }

        if (dialogueOptionID == 15420)
        {
            DialoguePlayback.DeleteLineID = 15420;

            AddToDialogue(15420);
            DialoguePlayback.DeleteLineID = 15100;
            AddToDialogue(15421);
            AddToDialogue(15422);
            AddToDialogue(15423);
            AddToDialogue(15424);

            WorldEvents.OppositaIsCrying = true;
            GameManager.Instance.MyInventory.RemoveItem(ItemType.TeaLeaves);

            DialoguePlayback.EndingDialogue = true;
        }

        if (dialogueOptionID == 15500) // ask help
        {
            DialoguePlayback.DeleteLineID = 15500;

            AddToDialogue(15500);
            AddToDialogue(15501);


            if (true)   //That entrepreneur, Mr. B….

            {
                AddToDialogue(15503);
                AddToDialogue(15504);
                AddToDialogue(15505);
                AddToDialogue(15506);
                AddToDialogue(15507);
                AddToDialogue(15508);
            }
            else if (true)      //That trumpet sound will lure Leon away, so you can put your potion in the teapot!
            {
                AddToDialogue(15510);
                AddToDialogue(15511);
                AddToDialogue(15512);
                AddToDialogue(15513);
                AddToDialogue(15514);
                AddToDialogue(15515);
            }
        }

        if (dialogueOptionID == 15502)  // ask help
        {
            AddToDialogue(15502);

            if(true)
            {
                AddToDialogue(15503);
                AddToDialogue(15504);
                AddToDialogue(15505);
                AddToDialogue(15506);
                AddToDialogue(15507);
                AddToDialogue(15508);
            }
            else if(true)
            {
                AddToDialogue(15510);
                AddToDialogue(15511);
                AddToDialogue(15512);
                AddToDialogue(15513);
                AddToDialogue(15514);
                AddToDialogue(15515);
            }
        }



        if (dialogueOptionID == 15810)
        {
            DialoguePlayback.DeleteLineID = 15810;

            AddToDialogue(15810);
            AddToDialogue(15811);
            AddToDialogue(15812);
        }

        if (dialogueOptionID == 15813)
        {
            DialoguePlayback.DeleteLineID = 15813;

            AddToDialogue(15813);
            AddToDialogue(15814);
            AddToDialogue(15815);
        }

        if (dialogueOptionID == 15820)
        {
            DialoguePlayback.DeleteLineID = 15820;

            AddToDialogue(15820);
            AddToDialogue(15821);
            AddToDialogue(15822);
            AddToDialogue(15823);
            AddToDialogue(15824);
            AddToDialogue(15825);
        }

        if (dialogueOptionID == 15070)
        {
            AddToDialogue(15070);

            DialoguePlayback.EndingDialogue = true;
        }

        if (dialogueOptionID == 15095)
        {
            AddToDialogue(15095);

            DialoguePlayback.EndingDialogue = true;
        }

        if (dialogueOptionID == 15830)
        {
            AddToDialogue(15831);

            DialoguePlayback.EndingDialogue = true;
        }
    }

    private static void AddToDialogue(int dialogueID)
    {
        DialoguePlayback.AddToDialogue(GameManager.CharacterDialogueLists[Character.Opposita][dialogueID]);
    }

    private bool IsLastBefore(int lastChosenOptionID, int dialogueOptionID)
    {
        if (PrecedingOptions[dialogueOptionID].Contains(lastChosenOptionID))
            return true;

        return false;
    }
}
