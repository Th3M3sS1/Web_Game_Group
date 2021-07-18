using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="SceneData", menuName="Data/SceneData")]
public class SceneDataSO : ScriptableObject
{
    public string sceneToLoad;
    public Vector3 playerPos;
    public float playerHealth;

    public bool newLevel;
}
