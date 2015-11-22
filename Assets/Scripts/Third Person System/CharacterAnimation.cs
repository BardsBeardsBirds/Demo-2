using System;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public void DetermineWhatIdleState()
    {
        int idleSelector = UnityEngine.Random.Range(1, 9);

        //Debug.Log("random no: " + idleSelector);

        CharacterControllerLogic.Instance.ChooseIdleState(idleSelector);
    }
}

