using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTrophy : MonoBehaviour
{
    private StarDisplay starDisplay;
    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }
    private void AddStar(int amount)  //修改產生多少陽光在Animation內修改
    {
        starDisplay.AddStar(amount);
    }
}
