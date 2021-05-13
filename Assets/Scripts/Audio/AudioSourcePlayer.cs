using System;
using UnityEngine;

namespace Audio
{
    public class AudioSourcePlayer : MonoBehaviour
    {
        [SerializeField] private PoolManager audioPoolManager;
        [SerializeField] AudioData audioData;
        [SerializeField] AudioSource audioSource;
        public bool playOnStart;
        [SerializeField] bool useLocalAudioSource = true;

        void Awake()
        {
             if (audioSource == null)
             {
                 audioSource = GetComponent<AudioSource>();
             }
        
            audioPoolManager = PoolManager.instance;
        }

        private void OnEnable()
        {
            audioPoolManager = PoolManager.instance;
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
                if (audioSource == null) { Debug.LogError("No Audio Source on object: " + gameObject.name); return; }

                audioSource.clip = audioData.GetClip(gameObject);
                audioSource.loop = audioData.IsLooping();
                audioSource.volume = audioData.GetVol();
                audioSource.pitch = audioData.GetPitch();
                return;
            }

            
            var pool = audioPoolManager.GetPool();
            
            if(pool == null)
                Debug.LogWarning("No pool!", gameObject);

            audioSource = pool.GetObject().GetComponent<AudioSource>();
           // audioSource.transform.position = transform.position;
            audioSource.clip = audioData.GetClip(gameObject);
            audioSource.loop = audioData.IsLooping();
            audioSource.volume = audioData.GetVol();
            audioSource.pitch = audioData.GetPitch();
        }

        public void PlayAudio()
        {
            audioSource.transform.position = transform.position;
            audioSource.Play();
            //InitializeAudioSource(audioSource);
        }
    }
}
