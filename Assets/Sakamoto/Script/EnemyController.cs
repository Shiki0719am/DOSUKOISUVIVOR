using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform playerTr;


    public float m_gemSpeedMin;
    public float m_gemSpeedMax;


    [SerializeField] float MoveSpeed = 2;
    private Rigidbody2D rb;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;



    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();


    }

    void EnemyMove()
    {
        //プレイヤーとの距離が0.1f未満になったらそれ以上実行しない
        if (Vector2.Distance(transform.position, playerTr.position) < 0.1f)
            return;
        //プレイヤーとの距離が10f離れたら加速してくる
        if (Vector2.Distance(transform.position, playerTr.position) > 10f)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(playerTr.position.x, playerTr.position.y),
                MoveSpeed * 10 * Time.deltaTime);

        }


        //プレイヤーに向けて進む
        else
        {

            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(playerTr.position.x, playerTr.position.y),
                MoveSpeed * Time.deltaTime);

        }




    }
}
