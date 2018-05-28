using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float fadeInTime;

    private Image fadePanel;
    private Color currentColor;
    private void Start()
    {
        fadePanel = GetComponent<Image>();
        currentColor = fadePanel.color;
    }
    private void Update()
    {
        if(Time.timeSinceLevelLoad < fadeInTime)
        {
            float alphaChange = Time.deltaTime / fadeInTime;
            currentColor.a = currentColor.a - alphaChange;
            fadePanel.color = currentColor;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
