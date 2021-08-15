using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHurtSound, FireSound, enemyDeathSound, CollectSound;
    static AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        playerHurtSound = Resources.Load<AudioClip>("hurt");
        FireSound = Resources.Load<AudioClip>("firing");
        enemyDeathSound = Resources.Load<AudioClip>("explosion");
        CollectSound = Resources.Load<AudioClip>("collect");

        audioSrc = GetComponent<AudioSource>();

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "fire":
                audioSrc.PlayOneShot(FireSound);
                break;

            case "hurt":
                audioSrc.PlayOneShot(playerHurtSound);
                break;

            case "enemyDeath":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;

            case "collect":
                audioSrc.PlayOneShot(CollectSound);
                break;
        }
    }
}
