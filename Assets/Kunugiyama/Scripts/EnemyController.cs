using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform playerTr; // プレイヤーのTransform


    [SerializeField] float speed = 10; // 敵の動くスピード
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーとの距離が0.1f未満になったらそれ以上実行しない
        if (Vector2.Distance(transform.position, playerTr.position) < 0.1f)
            return;

        // プレイヤーに向けて進む
        transform.position = Vector2.MoveTowards(
            transform.position,
            new Vector2(playerTr.position.x, playerTr.position.y),
            speed * Time.deltaTime);

        Vector3 scale = transform.localScale;

        if (playerTr.transform.position.x > this.transform.position.x)
        {
            scale.x = -0.1f;
        }
        else
        {
            scale.x = 0.1f;
        }
        transform.localScale = scale;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Destroy(gameObject);
        }
    }

}
