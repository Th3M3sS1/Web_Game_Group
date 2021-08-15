using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public GameObject questPanel;

    public Quests[] quests;

    public Text[] questNameText;
    public Text[] questDetailsText;

    public void Start()
    {
        for(int i = 0; i < questNameText.Length; i++)
        {
            questNameText[i].text = quests[i].nameOfQuest;
            questDetailsText[i].text = quests[i].detailsOfQuest;
        }

        questPanel.SetActive(false);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            ToggleQuestPanel();
        }
    }

    public void ToggleQuestPanel()
    {
        questPanel.SetActive(!questPanel.activeInHierarchy);
    }
}
