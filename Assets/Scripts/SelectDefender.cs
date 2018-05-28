using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDefender : MonoBehaviour
{
    public GameObject defenderPrefab;
    public static GameObject selectedDefender;

    private SelectDefender[] buttonArray;
    
    private void Start()
    {
        buttonArray = FindObjectsOfType<SelectDefender>();
    }
    
    private void OnMouseDown()
    {
        foreach(SelectDefender defenderButton in buttonArray)
        {
            defenderButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
        print(selectedDefender);
    }
}
