using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsController : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider difficultySlider;
    public LevelManager levelManager;

    private MusicManager musicManager;
    private void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPreferenceManager.GetMasterVolume();
        difficultySlider.value = PlayerPreferenceManager.GetDifficulty();
    }
    private void Update()
    {
        musicManager.SetVolume(volumeSlider.value);
    }
    public void SaveAndExit()
    {
        PlayerPreferenceManager.SetMasterVolume(volumeSlider.value);
        PlayerPreferenceManager.SetDifficulty(difficultySlider.value);
        levelManager.LoadLevel("01a Start");
    }
    public void SetDefault()
    {
        volumeSlider.value = 0.8f;
        difficultySlider.value = 2f;
    }
}
