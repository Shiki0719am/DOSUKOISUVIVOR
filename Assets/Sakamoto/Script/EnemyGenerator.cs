
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawns : MonoBehaviour
{
    // public Transform Player;

    // public GameObject enemy01;


    [Header("EnemyInfo")]

    [SerializeField] GameObject[] enemys;////出現させる敵をいれておく
    [SerializeField] float MinPositionX;//カメラからXのポジションに敵をランダム数の最小配置
    [SerializeField] float MaxPositionX;//カメラからXのポジションに敵を配置ランダム数の最小配置
    [SerializeField] float MinPositionY;//カメラからYのポジションに敵をランダム数の最小配置
    [SerializeField] float MaxPositionY;//カメラからYのポジションに敵を配置ランダム数の最小配置


    [SerializeField] float appearNextTime; //次の敵が出現するまでの時間

    [SerializeField] int maxNumOfEnemys;//この場所から出現する敵の数

    private int numberOfEnemys;//今何人敵を出現させたか（総数）

    private float elapsedTime;//待ち時間計測フィールド












    void Start()
    {





        numberOfEnemys = 0;
        elapsedTime = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        appearEnemy();






    }



    public void appearEnemy()
    {
        if (numberOfEnemys >= maxNumOfEnemys)
        {
            return;
        }
        elapsedTime += Time.deltaTime;


        if (elapsedTime > appearNextTime)
        {
            elapsedTime = 0f;
            getRandomPosition();
        }



        void getRandomPosition()
        {

            int randomValue = Random.Range(0, enemys.Length);//エネミーの種類をランダムで出現させる乱数
            float randomPositionX = Random.Range(MinPositionX, MaxPositionX);
            float randomPositionY = Random.Range(MinPositionY, MaxPositionY);


            Vector3 enemyPosition = Camera.main.ViewportToWorldPoint(new Vector3(randomPositionX, randomPositionY, Camera.main.nearClipPlane));
            enemyPosition.z = 0;
            Instantiate(enemys[randomValue], enemyPosition, Quaternion.identity);

            numberOfEnemys++;
            elapsedTime = 0f;
        }
    }





}
