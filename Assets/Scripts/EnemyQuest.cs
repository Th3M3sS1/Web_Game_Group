using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyQuest : Quests
{
    public int numberOfZombies = 0;
    public int totalZombie;

    public Text zombieNoText;
    public Image countBar;
    public override void CompleteQuest()
    {
        base.CompleteQuest();
    }

    public void KillZombie()
    {
        numberOfZombies++;
        zombieNoText.text = numberOfZombies.ToString() + "/" + totalZombie.ToString();
        countBar.fillAmount = numberOfZombies / (float)totalZombie;

        if(numberOfZombies == totalZombie)
        {
            CompleteQuest();
        }
    }
}
