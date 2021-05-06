using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourcePlayer : MonoBehaviour
{
    [SerializeField] AudioData audioData;
    [SerializeField] AudioSource audioSource;
    public bool playOnStart;

    void Awake()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeAudioSource();

        if (playOnStart)
            PlayAudio();
    }

    private void InitializeAudioSource()
    {
        if (audioSource == null) { Debug.LogError("No Audio Source on object: " + gameObject.name); return; }

        audioSource.clip = audioData.GetClip(gameObject);
        audioSource.loop = audioData.IsLooping();
        audioSource.volume = audioData.GetVol();
        audioSource.pitch = audioData.GetPitch();
    }

    public void PlayAudio()
    {
        audioSource.Play();
        //InitializeAudioSource(audioSource);
    }
}
