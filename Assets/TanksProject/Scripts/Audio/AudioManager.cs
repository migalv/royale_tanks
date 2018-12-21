using System;
using _Config;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    // Lista de clips de sonido
    public Sound[] sounds;
    // El Audio Mixer del juego, contiene los grupos de Music y SFX
    public AudioMixer audioMixer;
    // Valor del volumen antes de mutearlo
    private float previousMasterVolume;
    private bool masterIsMuted;

    public static AudioManager instance;

    // Mutea el volumen del grupo especificado como parametro
    public void MuteUnMuteMasterVolume(Slider masterSlider)
    {
        if (masterIsMuted == false)
        {
            audioMixer.GetFloat(Config.Instance.masterVolume, out previousMasterVolume);
            // Se setea el valor del volumen a -80 porque es cuando el juego está muteado
            audioMixer.SetFloat(Config.Instance.masterVolume, -80f);
            // Desactivamos el slider del volumen de master
            masterIsMuted = true;
        }
        else if (masterIsMuted == true)
        {
            audioMixer.SetFloat(Config.Instance.masterVolume, previousMasterVolume);

            // Desactivamos el slider del volumen de master
            masterIsMuted = false;
        }

    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat(Config.Instance.masterVolume, volume);
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.Output;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
}