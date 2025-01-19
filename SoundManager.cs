using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHitSound, jumpSound, coinSound, winSound, loseSound;
    static AudioSource audioSrc;

    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("jump");
        coinSound = Resources.Load<AudioClip>("coin");
        winSound = Resources.Load<AudioClip>("win");
        loseSound = Resources.Load<AudioClip>("lose");

        audioSrc = GetComponent<AudioSource>();

    }

    public static void playSound(string clip)
    {
        switch (clip)
        {
            case "jumpSound":
                audioSrc.PlayOneShot(jumpSound);
                break;

            case "coinSound":
                audioSrc.PlayOneShot(coinSound);
                break;

            case "winSound":
                audioSrc.PlayOneShot(winSound);
                break;

            case "loseSound":
                audioSrc.PlayOneShot(loseSound);
                break;
        }
    }
}