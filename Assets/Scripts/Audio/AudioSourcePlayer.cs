using System;
using UnityEngine;

namespace Audio
{
    public class AudioSourcePlayer : MonoBehaviour
    {
        // [SerializeField] private PoolManager audioPoolManager;
        [SerializeField] ObjectPool pool;
        [SerializeField] AudioData audioData;
        [SerializeField] AudioSource audioSource;
        [SerializeField] GameObject controlledObject;
        public bool playOnStart;

        private void GetPooledAudioSource()
        {
            if (pool != null)
            {
                LoadAudioSource();
            }
        }

        private void LoadAudioSource()
        {
            controlledObject = pool.GetObject();
            audioSource = controlledObject.GetComponent<AudioSource>();
        }

        private void SetAudioSourceProperties()
        {
            if (audioSource == null)
            {
                Debug.LogError("No audiosource.", gameObject);
                return;
            }

            audioSource.clip = audioData.GetClip(controlledObject);
            audioSource.loop = audioData.IsLooping();
            audioSource.volume = audioData.GetVol();
            audioSource.pitch = audioData.GetPitch();
        }

        public void PlayAudio()
        {
            GetPooledAudioSource();
            SetAudioSourceProperties();

            if (audioSource == null)
            {
                Debug.LogError("No AudioSource", controlledObject);
                return;
            }

            audioSource.transform.position = transform.position;
            audioSource.Play();
        }
    }
}