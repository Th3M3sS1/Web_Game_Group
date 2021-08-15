using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quests : MonoBehaviour
{
    public enum State
    {
        Idel,
        Complete
    };
    public State currentState = State.Idel;

    public string nameOfQuest;

    public string detailsOfQuest;

    public Text completeText;
    
    public virtual void CompleteQuest()
    {
        currentState = State.Complete;

        completeText.gameObject.SetActive(true);
    }
}
