using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance => _instance;

    [SerializeField] private AudioClipData audioClipData;
    private AudioSource _audioSource;


    private void Awake()
    {
        _instance = this;
        _audioSource = GetComponent<AudioSource>();

    }
    private void Start()
    {
        /*if (SaveController.Instance.SoundEnable)
            AudioListener.volume = 0;
        else
            AudioListener.volume = 1;*/
    }

    public AudioClip GetAudio(int id)
    {
        return audioClipData.audios[id];
    }
    public void Play(int id)
    {
        if (_audioSource.isPlaying) return;

        _audioSource.clip = audioClipData.audios[id];
        _audioSource.Play();
    }
}