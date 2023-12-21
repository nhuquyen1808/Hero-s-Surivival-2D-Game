using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemies : MonoBehaviour
{
    public int hp;
     

    [SerializeField] Vector2 _leftDes, _rightDes;
    // Start is called before the first frame update
    void Start()
    {
        _leftDes =  (Vector2)transform.position + new Vector2(-2, 0);
        _rightDes =  (Vector2)transform.position + new Vector2(2, 0);

      //  EnemyMovement();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void EnemyMovement()
    {
        transform.DOMove(_leftDes, 3).OnComplete(() =>
        {
            Vector2 localScale = transform.localScale;
            localScale.x  *= -1;
            transform.localScale = localScale;
            transform.DOMove(_rightDes, 3).OnComplete(() =>
            {
                localScale.x *= 1;
                transform.localScale = localScale;
                EnemyMovement();
            });
        });
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BrickProjectile"))
        {

            Debug.Log("get damage");
        }
    }
}
