using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    public bool isLoseCollider;
    public LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if(isLoseCollider)
        {
            levelManager.LoadLevel("03b Lose");
        }
    }
}
