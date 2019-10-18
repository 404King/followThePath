﻿using UnityEngine.Audio;
using System;
using UnityEngine;

/// <summary>
/// AudioManager is responsible for all related to audio
/// </summary>
public class AudioManager : MonoBehaviour
{
    // TODO change to private, since this object is responsible for audio other objects shouldn't know of the gameMixer.
    [Tooltip("Manages sound/volume")]
    public AudioMixer gameMixer;

    // TODO change to private, unless other objects are supposed to change this array.
    public Sound[] sounds;

    // TODO change instance to a public property with private set.
    public static AudioManager instance;

    private float MusicVolume;

    // Start is called before the first frame update
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.group;
        }

        // TODO read music volume from player prefs
    }

    void Start()
    {
        PlaySound("MainTheme_01");
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Play();
    }

    /// <summary>
    /// Returns the current music volume.
    /// </summary>
    /// <returns></returns>
    public float GetMusicVolume ()
    {
        return MusicVolume;
    }

    /// <summary>
    /// Sets the current music volume.
    /// </summary>
    /// <param name="volume">The volume music should have, from 0.0 to 1.0</param>
    public void SetMusicVolume (float volume)
    {

        MusicVolume = volume;
        gameMixer.SetFloat("musicVolume", Mathf.Log10(volume) * 20);
        // TODO add saving to player prefs
        //PlayerPrefs.SetFloat("musicVol", sliderValue);
        //Debug.Log(volume);
        //Debug.Log("Music volume: " + volume);
 
    }
}