using UnityEngine.Audio;

using System;
using UnityEngine;



public class AudioManager : MonoBehaviour
{

    //DECLARATIONS\\
    public Sound[] sounds;
    private bool isPlaying;

    //Commented out since I'm using multiple different AudioManagers
    //public static AudioManager instance;



    private void Awake()
    {
        
        //Commented out since I'm using multiple different AudioManagers
            //Check if Audio Manager exists and either carries to next scene or destroys itself
            /*if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }*/

        //Links all the pre-set values to the generated Audio Source
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            //Output
            s.source.outputAudioMixerGroup = s.mix;

            //Floats
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.panStereo = s.pan;

            //Bools
            //PlayOnAwake doesn't work as intended because of Unity pipeline hierarchy
            s.source.playOnAwake = s.onAwake;
            s.source.loop = s.loop;
            s.source.mute = s.mute;


        }
    }

    //Start method to get around PlayOnAwake issue
    public void Start()
    {
        foreach (Sound s in sounds)
        {
            if (s.onAwake)
            {
                Play(s.name);
            }
        }
    } 

    //METHODS\\
    #region 

    public void Play(string aName)
    {
        //Finds the sound in the array via the name
        Sound s = Array.Find(sounds, sound => sound.name == aName);
        
        //Checks name you entered exists
        if (s == null)
        {
            Debug.LogWarning("Sound: " + aName + " does not exist!");
            return;
        }

        //Plays the sound
        if (s.source.isPlaying != true)
        {
            s.source.Play();
        }        

        //Output to help with debug
        //Debug.Log("Playing " + aName + "..." );
    }

    public void Stop(string aName)
    {
        //Finds the sound in the array via the name
        Sound s = Array.Find(sounds, sound => sound.name == aName);

        //Checks name you entered exists
        if (s == null)
        {
            Debug.LogWarning("Sound: " + aName + "does not exist!");
            return;
        }

        //Stops playing the sound
        s.source.Stop();

        //Output to help with debug
        //Debug.Log("Stopping " + aName + "...");
    }

    public bool CheckIfPlaying(string aName)
    {
       
        //Finds the sound in the array via the name
        Sound s = Array.Find(sounds, sound => sound.name == aName);

        //
        if (s == null)
        {
            Debug.LogWarning("Sound: " + aName + "does not exist!");
            return false;
        }


        //Checks if the sound is currently playing and creates message to help with debug
        if (s.source.isPlaying == true)
        {
            //Debug.Log(aName + " is playing.");
            return true;
        }
        else
        {
            //Debug.Log(aName + " is not playing");
            return false;
        }

        
    }

    //public void playRotateUp(int position)
    //{
    //    if (position == 1 || position == -1)
    //    {            
    //        Play("tilt up 1");
    //    }
    //    else if (position == 2 || position == -2)
    //    {
    //        Play("tilt up 2");
    //    }
    //    else if (position == 3 || position == -3)
    //    {
    //        Play("tilt up 3");
    //    }
    //}

    //public void playRotateDown(int position)
    //{
    //    if (position == 0)
    //    {
    //        Play("tilt down 1");
    //    }
    //    else if (position == 1 || position == -1)
    //    {
    //        Play("tilt down 2");
    //    }
    //    else if (position == 2 || position == -2)
    //    {
    //        Play("tilt down 3");
    //    }
    //}

    //Speed sound code that's not finished yet
    /*public void playSpeed(float speed)
    {        
        if (speed > 0 && speed < 4 && speed !< 0 && speed != 0)
        {
            isPlaying = CheckIfPlaying("speed 1");

            if (isPlaying == false)
            {
                Play("speed 1");
            }            
        }
        else if (speed > 4 && speed < 8 && speed !<= 0)
        {
            isPlaying = CheckIfPlaying("speed 2");

            if (isPlaying == false)
            {
                Play("speed 2");
            }
        }
    }*/

    #endregion
}

