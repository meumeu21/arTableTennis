using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysicsBehaviour : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ptable"))
        {
            _audioSource.Play();
        }
    }
}
