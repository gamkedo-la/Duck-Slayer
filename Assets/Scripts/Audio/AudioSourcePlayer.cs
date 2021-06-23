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
        [SerializeField] bool useLocalAudioSource = true;

        private void OnEnable() => InitializeAudioSource();
        //private void Awake() => InitializeAudioSource();

        void Start()
        {
            InitializeAudioSource();
            if (playOnStart)
                PlayAudio();
        }

        private void InitializeAudioSource()
        {
            if (useLocalAudioSource)
            {
                if (audioSource == null)
                {
                    Debug.LogError("No Audio Source on object: " + controlledObject.name);
                    return;
                }

                SetAudioSourceProperties();
                return;
            }

            if (pool == null)
            {
                Debug.LogWarning("No pool!", controlledObject);
                return;
            }

            GetPooledAudioSource();

            SetAudioSourceProperties();
        }

        private void GetPooledAudioSource()
        {
            if(pool != null)
            {
              Debug.Log(pool.GetObject());
              controlledObject = pool.GetObject();
              audioSource = controlledObject.GetComponent<AudioSource>();
            }

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