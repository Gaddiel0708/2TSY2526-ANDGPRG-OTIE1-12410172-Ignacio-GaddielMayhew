using UnityEngine;
using UnityEngine.Audio; // Required for AudioMixer
using UnityEngine.UI;    // Required for Sliders

public class AudioSettings : MonoBehaviour
{
    public AudioMixer masterMixer;

    public void SetMusicVolume(float volume)
    {
        masterMixer.SetFloat("MusicVol", volume);
    }

    public void SetSFXVolume(float volume)
    {
        masterMixer.SetFloat("SFXVol", volume);
    }
}