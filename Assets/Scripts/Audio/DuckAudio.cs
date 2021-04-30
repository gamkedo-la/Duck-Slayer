using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckAudio : MonoBehaviour
{
    [SerializeField] AudioSource[] audioSources;
    private int currentSourceIndex = 0;
    //private int nextSourceIndex;
    [SerializeField] AudioData audioData;
    public float minDelayBetweenQuacks;
    public float maxDelayBetweenQuacks;
    public bool loopQuacks;
    private float timeToNextQuack;

    void Awake()
    {

        InitializeAudioSource(audioSources[currentSourceIndex]);
    }

    private void Start()
    {
        PlayAudio();
        SetTimer();
    }

    private void Update()
    {
        if (loopQuacks)
        {
            timeToNextQuack -= Time.deltaTime;

            if (timeToNextQuack <= 0)
            {
                PlayAudio();
                SetTimer();
            }
        }


    }

    private void SetTimer()
    {
        timeToNextQuack = UnityEngine.Random.Range(minDelayBetweenQuacks, maxDelayBetweenQuacks);
    }

    private void InitializeAudioSource(AudioSource source)
    {
        source.clip = audioData.GetClip(gameObject);
        source.loop = audioData.IsLooping();
        source.volume = audioData.GetVol();
        source.pitch = audioData.GetPitch();

        IncrementIndex();
    }

    private void IncrementIndex()
    {
        currentSourceIndex = (currentSourceIndex++) % (audioSources.Length);
    }

    public void PlayAudio()
    {
        audioSources[currentSourceIndex].Play();
        IncrementIndex();
        InitializeAudioSource(audioSources[currentSourceIndex]);
    }


}
