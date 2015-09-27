using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueColour : MonoBehaviour
{
    public static void SetTextColour(int id, SpokenLine spokenLine)
    {
        Text lineText = GameManager.Instance.UICanvas.DialogueLineImage.GetComponentInChildren<Text>();

        switch (spokenLine.Speaker)
        {
            case Character.Ay:
                lineText.color = new Color(1f, .75f, .62f);
                break;
            case Character.Bart:
                lineText.color = new Color(.99f, .9f, .39f);
                break;
            case Character.Benny:
                lineText.color = new Color(.24f, .64f, .60f);
                break;
            case Character.Eremma:
                //       lineText.color = new Color(.68f, .95f, .55f);
                lineText.color = new Color(.55f, .95f, .95f);
                break;
            case Character.Leon:
                //         lineText.color = new Color(.55f, .95f, .95f);   //light greenish
                lineText.color = new Color(1f, .62f, .22f);
                break;
            case Character.MrB:
                lineText.color = new Color(.96f, .35f, .35f);
                break;
            case Character.Obstructor:
                lineText.color = new Color(.67f, .829f, .96f);
                break;
            case Character.Opposita:
                lineText.color = new Color(.96f, .63f, .87f);
                break;
            case Character.Sentinel:
                lineText.color = new Color(1f, .98f, .44f);
                break;
            default:
                lineText.color = new Color(.95f, .95f, .95f);
                break;
        }

    }
}
