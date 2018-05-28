using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StarDisplay : MonoBehaviour
{
    public Text starText;

    public int starTotal;

    private void Start()
    {
        starText = GetComponent<Text>();
        starTotal = 10;
        UpdateText();
    }
    public void AddStar(int amount)
    {
        starTotal = starTotal + amount;
        UpdateText();
    }
    public bool SpendStar(int amount)
    {
        if (starTotal >= amount)
        {
            starTotal = starTotal - amount;
            UpdateText();
            return true;
        }
        else
        {
            Debug.Log("insufficient stars!");
            return false;
        }
        
    }
    private void UpdateText()
    {
        starText.text = starTotal.ToString();
    }
}
