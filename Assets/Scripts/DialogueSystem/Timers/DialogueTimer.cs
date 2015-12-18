using UnityEngine;

public class DialogueTimer
{
    public static DialogueTimer Instance;
    public static float AudioClipLength = 0f;
    public static int ChosenOptionID;

    public static bool IsTyping;
    public static bool AudioFinished = false;

    private float _timer = 0;
    
    public void Start()
    {
        AudioClipLength = 0f;
    }

    public void Awake()
    {
        Instance = this;
    }

    public void SetDialogueTimerLength(float timerLength)
    {
   //     timerLength = timerLength / 1.5f;   ///TO make every thing go faster 
        AudioClipLength = timerLength;
    //    _timer = 1f;
        _timer = timerLength;
    }

    public void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
          //  Debug.Log("Timer " + _timer);

            if (_timer <= 0)
            {
                if (CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.TalkingLastLine)
                {
                    Debug.Log("exit the dialogue");

                    TimeManager.Instance.DialogueIsPlaying = false;
                    DialogueManager.EndDialogueState(DialogueManager.CurrentDialogueNPC);
                }
                else
                {
                    if (DialoguePlayback.LastLineOfTheBlock)
                    {
                        Debug.Log("ChosenOptionID " + ChosenOptionID);
                        DialoguePlayback.DialogueNumberToSituation(ChosenOptionID);

                        TimeManager.Instance.DialogueIsPlaying = false;
                        DialoguePlayback.Instance.HideDialogueLines();
                        DialogueManager.NPCToListeningState(DialogueManager.CurrentDialogueNPC);
                        DialogueMenu.ShowDialogueOptions();
                    }
                }
         //       Debug.Log("Do we do something at the end?" + DialoguePlayback.CurrentLineID);
                CameraAngles.StopMovingCamera();

                DoSomethingAtEnd(DialoguePlayback.CurrentSpokenLine);
            }
        }       
    }

    private static void DoSomethingAtEnd(SpokenLine spokenLine)
    {
        //if (id == 3025) //drink the roughneck shot after this one
        //{
        //    for (int i = 0; i < GameManager.Instance.MyInventory.Items.Count; i++)
        //    {
        //        Debug.Log(GameManager.Instance.MyInventory.Items[i].IType);
        //        if (GameManager.Instance.MyInventory.Items[i].IType == ItemType.RoughneckShot)
        //        {
        //            GameManager.Instance.MyInventory.MakeSlotEmpty(i);
        //            break;
        //        }
        //    }
        //}
    }
}