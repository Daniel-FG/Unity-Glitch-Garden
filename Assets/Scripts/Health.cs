using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float objectHealth;
    public float ObjectHealth
    {
        get
        {
            return objectHealth;
        }
        set
        {
            objectHealth = value;
            if(objectHealth <= 0)
            {
                SendMessage("Die");
            }
        }
    }
}
