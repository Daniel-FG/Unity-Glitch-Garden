using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Tooltip ("")]  //加入此行即可在Inspector中顯示說明
    public float seenPerSecond;
    public float damage;
    public float health; 

    private Animator animator;
    private float currentSpeed;
    private GameObject currentTarget;

    private void Start()
    {
        animator = GetComponent<Animator>();
        GetComponent<Health>().ObjectHealth = health;
    }
    private void Update()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if(!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
    }
    
    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }
    public void Attack(GameObject target)
    {
        currentTarget = target;
    }
    public void StrikeCurrentTarget(float damage)
    {
        Health health = currentTarget.GetComponent<Health>();
        if(!health)
        {
            return;
        }

        if(health)
        {
            health.ObjectHealth = health.ObjectHealth - damage;
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
