using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LevelComplete : MonoBehaviour
{

    public GameObject levelcomplete;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            levelcomplete.SetActive(true);
        }
    }
}
