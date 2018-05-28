using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Attacker))]
public class Fox : MonoBehaviour
{
    public float foxDamage = 20f;

    private Attacker attacker;
    private Animator foxAnimator;
    private bool isAttacking = false;
    
	void Start ()
    {
        foxAnimator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
	}
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if(!obj.GetComponent<Defender>())  //如果撞到的物件沒有Defender Component
        {
            return;  //跳出
        }

        if(collision.gameObject.GetComponent<GraveStone>())
        {
            foxAnimator.SetTrigger("jump trigger");
        }
        else
        {
            isAttacking = true;
            foxAnimator.SetBool("isAttacking", isAttacking);
            attacker.Attack(obj);
        }
    }
    
}
