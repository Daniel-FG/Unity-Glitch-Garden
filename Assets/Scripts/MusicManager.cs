using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] levelMusics;

    private AudioSource audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnLevelWasLoaded(int level)
    {
        AudioClip currentMusic = levelMusics[level];
        if (currentMusic)
        {
            audioSource.clip = currentMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            Debug.Log(SceneManager.GetActiveScene().name + " doesn't contain music.");
        }
    }

    public void SetVolume(float volume)
    {
        if (volume >= 0 && volume <= 1)
        {
            audioSource.volume = volume;
        }
        else
        {
            Debug.LogError("Volume set out of range");
        }
    }
}
