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
        InitializeAudioSource(audioSource);

        if (playOnStart)
            PlayAudio();
    }

    private void InitializeAudioSource(AudioSource source)
    {
        if (source == null) { Debug.LogError("No Audio Source on object: " + gameObject.name); return; }

        source.clip = audioData.GetClip(gameObject);
        source.loop = audioData.IsLooping();
        source.volume = audioData.GetVol();
        source.pitch = audioData.GetPitch();
    }

    public void PlayAudio()
    {
        audioSource.Play();
        InitializeAudioSource(audioSource);
    }
}
