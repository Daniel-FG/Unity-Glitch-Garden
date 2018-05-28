using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPreferenceManager : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Wrong Format for Master Volume");
        }
    }
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 1 && difficulty <= 3)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Wrong Difficulty Format");
        }
    }
    public static float GetDifficulty()
    {
        if(PlayerPrefs.GetFloat(DIFFICULTY_KEY) == 0f)
        {
            SetDifficulty(1f);
        }
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if (level <= (SceneManager.sceneCount - 1))
        {
            string levelKey = LEVEL_KEY + level.ToString();
            PlayerPrefs.SetInt(levelKey, 1);  //1代表解鎖
        }
        else
        {
            Debug.LogError("Level out of Range");
        }
    }
    public static bool IsLevelUnlocked(int level)
    {
        string levelKey = LEVEL_KEY + level.ToString(); ;
        bool isLevelUnlocked = (PlayerPrefs.GetInt(levelKey) == 1);
        if(level <= (SceneManager.sceneCount - 1))
        {
            return isLevelUnlocked;
        }
        else
        {
            Debug.LogError("Level out of range");
            return false;
        }
        
    }
}
