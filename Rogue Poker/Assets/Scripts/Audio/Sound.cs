using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sound 
{
    public string name;

    public AudioClip clip;

    public AudioMixerGroup mix;

    [Range (0f, 1f)]
    public float volume;

    [Range(0f, 3f)]
    public float pitch;

    [Range (-1f, 1f)]
    public float pan;

    public bool onAwake;
    public bool loop;
    public bool mute;    

    [HideInInspector]
    public AudioSource source;



    public void setPan(float newPan)
    {
        pan = newPan;
    }

    public void setPitch(float newPitch)
    {
        pitch = newPitch;
    }

    public void setVolume(float newVolume)
    {
        volume = newVolume;
    }
}
