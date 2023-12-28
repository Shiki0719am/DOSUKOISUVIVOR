using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercotollor : MonoBehaviour
{
    public float moveSpeed = 8.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 移動方向を示すベクトル
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        // ベクトルを正規化
        moveDirection.Normalize();

        // 正規化されたベクトルを使用して移動する
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TestEnemy")
        {
            // collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 100), ForceMode2D.Impulse);
        }
    }
}
