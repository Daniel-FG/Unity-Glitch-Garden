using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private GameObject parent;
    private StarDisplay starDisplay;
	void Start ()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
        parent = GameObject.Find("Defenders");
        if(parent == null)
        {
            parent = new GameObject("Defenders");
        }
	}
	
    private void OnMouseDown()
    {
        GameObject def = SelectDefender.selectedDefender;
        int cost = def.GetComponent<Defender>().starCost;
        if (def)
        {
            if (starDisplay.SpendStar(cost))
            {
                Vector3 spawnPosition = SnapToGrid(MouseClickToWorldPosition());
                GameObject defender = Instantiate(def, spawnPosition, Quaternion.identity) as GameObject;
                defender.transform.parent = parent.transform;
            }
        }
    }

    Vector2 MouseClickToWorldPosition()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return position;
    }
    Vector2 SnapToGrid(Vector2 rawPosition)
    {
        float newX = Mathf.RoundToInt(rawPosition.x);
        float newY = Mathf.RoundToInt(rawPosition.y);
        return new Vector2(newX, newY);
    }
}
