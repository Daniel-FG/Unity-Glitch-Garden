using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]  //[RequireComponent (typeof(需要的Component))]  
                                                                //此行確保有此Script的gameObject一定有需要的Component
                                                                //如果沒有則會自行加入該Component
public class Lizard : MonoBehaviour
{
    
    public float lizardDamage = 10f;

    private Attacker attacker;
    private Animator lizardAnimator;
    private bool isAttacking = false;
	// Use this for initialization
	void Start ()
    {
        lizardAnimator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
	}
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (!obj.GetComponent<Defender>())  //如果撞到的物件沒有Defender Component
        {
            return;  //跳出
        }
        isAttacking = true;
        lizardAnimator.SetBool("isAttacking", isAttacking);
        attacker.Attack(obj);
    }
}
