using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    public GameObject[] attackerPrefabArray;

    private void Update()
    {
        foreach (GameObject thisAttatcker in attackerPrefabArray)
        {
            if(isTimeToSpawn(thisAttatcker))
            {
                Spawn(thisAttatcker);
            }
        }
    }
    private void Spawn(GameObject attacker)
    {
        GameObject myAttacker = Instantiate(attacker, transform.position, Quaternion.identity) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
        Debug.Log("Spawn " + myAttacker);
    }
    private bool isTimeToSpawn(GameObject attacker)
    {
        float meanSpawnDelay = attacker.GetComponent<Attacker>().seenPerSecond;  //如果一秒最多可以看到5隻敵人
        float spawnsPerSecond = 1.0f / meanSpawnDelay;  //代表每過1/5秒就可能產生一隻敵人
        if (Time.deltaTime > spawnsPerSecond)  //如果一禎的時間大於1/5秒
                                                                           //假設一禎需要2秒   2秒照理說要產生10隻  
                                                                           //但是產生的方法寫在Update()裡面  每一禎只能產生一隻
                                                                           //禎數太少不能夠產生足夠的敵人
        {
            Debug.LogWarning("Spawn rate capped by frame rate");  //產生率被禎數給限制住了
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5;  //該禎所經過的秒數
        if(Random.value < threshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
