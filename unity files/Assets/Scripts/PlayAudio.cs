using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    private AudioSource audioData;
    private void Awake()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play();
    }
}
