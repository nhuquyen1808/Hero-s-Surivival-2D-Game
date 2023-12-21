using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using DG.Tweening;


public class Projectile : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    { 
            //transform.DOMove(Player.instance.enemyPos, 0.7f);
            transform.position = Vector2.MoveTowards(transform.position, Player.instance.enemyPos, 5 * Time.deltaTime);
            Destroy(gameObject,1.5f);
    }
}
 