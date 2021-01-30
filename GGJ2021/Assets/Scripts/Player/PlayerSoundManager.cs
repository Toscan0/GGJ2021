using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    private AudioSource audioSorce;

    private void Start()
    {
        audioSorce = GetComponent<AudioSource>();
    }

    internal void PlaySound(AudioClip audioClip)
    {
        audioSorce.clip = audioClip;
        audioSorce.Play();
    }
}
