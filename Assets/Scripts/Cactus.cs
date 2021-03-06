﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{

    public GameObject projectile, projectileParent, gun;
    
    private Animator cactusAnimator;
    private AttackerSpawner attackerSpawner;
    private void Start()
    {
        cactusAnimator = GetComponent<Animator>();

        FindItsSpawner();
        projectileParent = GameObject.Find("Projectiles");
        if (projectileParent == null)
        {
            projectileParent = new GameObject("Projectiles");
        }
    }
    private void Update()
    {
        if (hasAttackableInLane())
        {
            cactusAnimator.SetBool("isDefending", true);
        }
        else
        {
            cactusAnimator.SetBool("isDefending", false);
        }
    }
    void FindItsSpawner()
    {
        AttackerSpawner[] spawnArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnArray)
        {
            if (spawner.transform.position.y == transform.position.y)
            {
                attackerSpawner = spawner;
                return;
            }
        }
        Debug.LogError(name + " can't find its corresponding attacker spawner.");
    }
    private bool hasAttackableInLane()
    {
        if (attackerSpawner.transform.childCount <= 0)
        {
            return false;
        }

        foreach (Transform attatcker in attackerSpawner.transform)
        {
            if (attatcker.transform.position.x > transform.position.x)
            {
                return true;
            }
        }
        return false;
    }
    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, transform) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }

}
