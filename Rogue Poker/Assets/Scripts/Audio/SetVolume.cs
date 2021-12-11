using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    //Audio Mixer used in this Scene
    public AudioMixer mixer;


    //Sets the Volume of everything in the game
    public void SetMasterVol(float sliderValue)
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
        Debug.Log("Master Volume Set to " + Mathf.Log10(sliderValue) * 20);
    }

    //Sets the Music Volume
    public void SetMusicVol(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }

    //Sets the Sound Effects Volume
    public void SetFXVol(float sliderValue)
    {
        mixer.SetFloat("FXVol", Mathf.Log10(sliderValue) * 20);
    }

}
