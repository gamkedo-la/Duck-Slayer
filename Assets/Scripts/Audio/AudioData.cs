using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "DuckSlayer/AudioData", fileName = "New AudioData.asset")]
public class AudioData : ScriptableObject
{
    [SerializeField] List<AudioClip> Sounds = new List<AudioClip>();

    [SerializeField] AudioMixer mixer;

    [SerializeField] bool Loop = false;

    [Range(-80, 0.0001f)]
    [SerializeField] float Volume;

    [Range(-24, 24)]
    [SerializeField] float Pitch = 0f;

    // [Range(0f, 1f)]
    // [SerializeField] float SpatialBlend = 1f; // variable not used. I commented it out to clear the warning.

    [Range(0, 5)]
    [SerializeField] float RandomVolume = 0f;
    [SerializeField] bool RandomizeVolume = false;

    [Range(0, 12)]
    [SerializeField] float RandomPitch = 0f;
    [SerializeField] bool RandomizePitch = false;

    #region AudioSource Parameters
    public float GetVol()
    {
        if (RandomizeVolume == true)
        {
            return AudioFunctions.DbToLinear(Volume + GetRandomValueOffset(RandomVolume));
        }
        else
        {
            return AudioFunctions.DbToLinear(Volume);
        }
    }

    private float GetRandomValueOffset(float value)
    {
        return Random.Range(-value, value);
    }

    public float GetPitch()
    {
        if (RandomizePitch == true)
        {
            return AudioFunctions.St2pitch(Pitch + GetRandomValueOffset(RandomPitch));
        }
        else
        {
            return AudioFunctions.St2pitch(Pitch);
        }
    }

    public bool IsLooping() { return Loop; }

    #endregion

    #region AudioClip Logic

    public AudioClip GetClip(GameObject calledBy)
    {
        var numberOfClips = Sounds.Count;

        if (numberOfClips == 0)
        {
            Debug.LogError("AudioData called by: " + calledBy.name + " does not contain any AudioClips.");
            return null;
        }

        if (numberOfClips > 1)
        {
            return Sounds[Random.Range(0, numberOfClips)];
        }
        else
        {
            return Sounds[0];
        }
    }

    #endregion
}
