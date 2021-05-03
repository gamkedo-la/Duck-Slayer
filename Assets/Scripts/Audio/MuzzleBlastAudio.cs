using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleBlastAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioData audioData;

    private void Awake()
    {
        InitializeAudioSource();

    }
    private void InitializeAudioSource()
    {
        audioSource.clip = audioData.GetClip(gameObject);
        audioSource.loop = audioData.IsLooping();
        audioSource.volume = audioData.GetVol();
        audioSource.pitch = audioData.GetPitch();
    }

    void Start()
    {
        audioSource.Play();
    }
}
