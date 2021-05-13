using System;
using UnityEngine;

namespace Audio
{
    public class AudioSourcePlayer : MonoBehaviour
    {
        [SerializeField] private PoolManager audioPoolManager;
        internal ObjectPool pool;
        [SerializeField] AudioData audioData;
        [SerializeField] AudioSource audioSource;
        public bool playOnStart;
        [SerializeField] bool useLocalAudioSource = true;

        void Awake()
        {
            InitPool();
        }

        private void InitPool()
        {
            if (pool != null)
                return;
            
            if (audioPoolManager == null)
                audioPoolManager = PoolManager.instance;

            pool = audioPoolManager.GetPool();
        }

        private void OnEnable()
        {
            InitPool();
            InitializeAudioSource();
        }

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
                    Debug.LogError("No Audio Source on object: " + gameObject.name);
                    return;
                }

                SetAudioSourceProperties();
                return;
            }

            if (pool == null)
                Debug.LogWarning("No pool!", gameObject);

            audioSource = pool.GetObject().GetComponent<AudioSource>();
            SetAudioSourceProperties();
        }

        private void SetAudioSourceProperties()
        {
            audioSource.clip = audioData.GetClip(gameObject);
            audioSource.loop = audioData.IsLooping();
            audioSource.volume = audioData.GetVol();
            audioSource.pitch = audioData.GetPitch();
        }

        public void PlayAudio()
        {
            audioSource.transform.position = transform.position;
            audioSource.Play();
        }
    }
}