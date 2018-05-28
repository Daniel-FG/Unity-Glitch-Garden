using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour
{
    private MusicManager musicManager;
    private void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
        musicManager.SetVolume(PlayerPreferenceManager.GetMasterVolume());
    }
}
