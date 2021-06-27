using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedData
{
    public float[] playerPos = new float[3];

    public int enemyCount = 0;

    public string levelToLoad;

    public class EnemyPos
    {
        public float[] enemyPos = new float[3];
    }

    public SavedData(PlayerController pc, int count)
    {
        playerPos[0] = pc.transform.position.x;
        playerPos[1] = pc.transform.position.y;
        playerPos[2] = pc.transform.position.z;

        //later change below code when enemies health and take damage implemented
        enemyCount = count;

        EnemyPos[] enemies = new EnemyPos[enemyCount];
    }
}
