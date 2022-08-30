using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 计算距离检测目标
 */
public class DetectTargetByDistance : MonoBehaviour
{
    
    /**/
    public int range = 2;

    /*检测到的对象*/
    private List<GameObject> detect ;
    
    void Update()
    {
        detect = new List<GameObject>();
        var monsterList = CreateMonster.Instance.MonsterList;
        foreach (var monster in monsterList)
        {
            if (Vector2.Distance(gameObject.transform.position,monster.transform.position)< range)
            {
                detect.Add(monster);
            }
        }
    }

    
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);

        if (detect == null)
            return;
        Gizmos.color = Color.magenta;
        foreach (var item in detect)
        {
            Gizmos.DrawSphere(item.transform.position, 0.3f);
        }
    }
}