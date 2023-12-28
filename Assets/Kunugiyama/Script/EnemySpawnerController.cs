using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

// 生成タイプ
public enum SpawnType
{
    Nomal,
    Group,
}
[Serializable]
public class EnemySpawnData
{
    // 説明用
    public string Title;
    // 出現時間時間
    public int ElapsedMinutes;
    public int ElapsedSeconds;
    // 出現タイプ
    public SpawnType SpawnType;
    // 生成時間
    public float SpawnDuration;
    // 生成数
    public int SpawnCountMax;
    // 生成する敵ID
    public List<int> EnemyIds;
}


// 敵生成
public class EnemySpawnerController : MonoBehaviour
{
    // 敵データ
    [SerializeField] List<EnemySpawnData> EnemySpownDatas;
    // 生成した敵
    public List<EnemyController> Enemies;

    // シーンディレクター
    GameSceneDirector sceneDirector;
    // 当たり判定のあるタイプマップ
    Tilemap tilemapCollider;
    // 現在の参照データ
    EnemySpawnData enemySpawnData;
    // 経過時間
    float oldSeconds;
    float spawnTimer;
    //現在のデータ位置
    int spawnDataIndex;
    // 敵の出現位置
    const float SpawnRadius = 13;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 敵生成データ更新
        updateEnemySpawnData();
        // 生成
        spawnEnemy();
    }
    // 初期化
    public void Init(GameSceneDirector sceneDirector, Tilemap tilemapCollider)
    {
        this.sceneDirector = sceneDirector;
        this.tilemapCollider = tilemapCollider;

        // 生成した敵を保存
        Enemies = new List<EnemyController>();
        spawnDataIndex = -1;
    }

    // 敵生成
    void spawnEnemy()
    {
        // 現在のデータ
        if (null == enemySpawnData) return;
        // タイマー消化
        spawnTimer -= Time.deltaTime;
        if (0 < spawnTimer) return;

        if (SpawnType.Group == enemySpawnData.SpawnType)
        {
            spawnGroup();
        }
        else if (SpawnType.Nomal == enemySpawnData.SpawnType)
        {
            spawnNomal();
        }

        spawnTimer = enemySpawnData.SpawnDuration;
    }

    // 通常生成
    void spawnNomal()
    {
        // プレイヤーの位置
        Vector3 center = sceneDirector.Player.transform.position;
        // 敵生成
        for (int i = 0; i < enemySpawnData.SpawnCountMax; i++)
        {
            // プレイヤーの周りから出現させる
            float angle = 360 / enemySpawnData.SpawnCountMax * i;
            // Cos関数にラジアン角を指定すると、xの座標を返してくれる、radiusをかけてワールド座標に変換する
            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * SpawnRadius;
            // Sin関数にラジアン角を指定すると、yの座標を返してくれる、radiusをかけてワールド座標に変換する
            float y = Mathf.Sin(angle * Mathf.Deg2Rad) * SpawnRadius;

            // 生成位置
            Vector2 pos = center + new Vector3(x, y, 0);

            // 当たり判定のあるタイル上なら生成しない
            if (Utils.IsCollisionTile(tilemapCollider, pos)) continue;

            // 生成
            createRandomEnemy(pos);
        }
    }

    void createRandomEnemy(Vector3 pos)
    {
        // データかららんだむなIdを取得
        int rnd = Random.Range(0, enemySpawnData.EnemyIds.Count);
        int id = enemySpawnData.EnemyIds[rnd];

        // 敵生成
        EnemyController enemy = CharacterSettings.Instance.CreateEnemy(id, sceneDirector, pos);
        Enemies.Add(enemy);
    }
