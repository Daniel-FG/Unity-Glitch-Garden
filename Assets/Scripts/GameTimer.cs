using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float levelDuration = 30;
    public LevelManager levelManager;

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    private void Update()
    {
        float rate = Time.deltaTime / levelDuration;
        slider.value = Mathf.MoveTowards(slider.value, slider.maxValue, rate);

        if(slider.value == slider.maxValue)
        {
            levelManager.LoadNextLevel();
        }
    }
}
