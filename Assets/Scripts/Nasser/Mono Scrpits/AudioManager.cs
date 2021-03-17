using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.AudioSource = gameObject.AddComponent<AudioSource>();
            sound.AudioSource.clip = sound.clip;
            sound.AudioSource.volume = sound.volume;
            sound.AudioSource.loop = sound.loop;
        }
        FindObjectOfType<AudioManager>().playAudio("Theme");
    }

    public void playAudio(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Audio sourec {name} not found");
            return;
        }
        s.AudioSource.Play();

        //how to play audio
        //FindObjectOfType<AudioManager>().playAudio("");


        // play click
        //FindObjectOfType<AudioManager>().playAudio("Click");

        // play lose
        //FindObjectOfType<AudioManager>().playAudio("Lose");

        // play victory
        //FindObjectOfType<AudioManager>().playAudio("Win");

        // play theme
        //FindObjectOfType<AudioManager>().playAudio("Theme");
    }
}
