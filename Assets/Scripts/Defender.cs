using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    public float health;  //血量
    public int starCost;  //價格

    private void Start()
    {
        GetComponent<Health>().ObjectHealth = health;
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
