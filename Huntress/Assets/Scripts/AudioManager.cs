using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {


    public Sound[] sounds;

    public static AudioManager instance;


    public bool isPlaying;

	// Use this for initialization
	void Awake () {

        if (instance == null)
            instance = this;

        else if(instance != this)  
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            
        }
	}
    void Start()
    {
        
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
        isPlaying = true;
    }

    public void Stop(string name)
    {
        if(isPlaying == true)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }
            s.source.Stop();
            isPlaying = false;
        }
    }
}

