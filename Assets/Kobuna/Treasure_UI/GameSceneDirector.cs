using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameSceneDirector : MonoBehaviour
{
    // タイルマップ
    [SerializeField] GameObject grid;
    [SerializeField] Tilemap tilemapCollider;
    // マップ全体座標
    public Vector2 TileMapStart;
    public Vector2 TileMapEnd;
    public Vector2 WorldStart;
    public Vector2 WorldEnd;

    [SerializeField] Transform parentTextDamage;
    [SerializeField] GameObject prefabTextDamage;

    // タイマー
    [SerializeField] Text textTimer;
    public float GameTimer;
    public float OldSeconds;

    // プレイヤー生成
    [SerializeField] Slider sliderXP;
    [SerializeField] Slider sliderHP;
    [SerializeField] Text textLv;

    // 経験値
    [SerializeField] List<GameObject> prefabXP;

    // 宝箱関連
    [SerializeField] PanelTreasureChestController panelTreasureChest;
    [SerializeField] GameObject prefabTreasureChest;
    [SerializeField] List<int> treasureChestItemIds;
    [SerializeField] float treasureChestTimerMin;
    [SerializeField] float treasureChestTimerMax;
    float treasureChestTimer;

    // Start is called before the first frame update
    void Start()
    {

        panelTreasureChest.Init(this);

        DispPanelTreasureChest();
    }
    void Update()
    {
    }


    // 宝箱パネルを表示
    public void DispPanelTreasureChest()
    {
        // ランダムアイテム
        ItemData item = getRandomItemData();
        // データ無し
        if (null == item) return;

        // パネル表示
        panelTreasureChest.DispPanel(item);

    }



    // アイテムをランダムで返す
    ItemData getRandomItemData()
    {
        if (1 > treasureChestItemIds.Count) return null;

        // 抽選
        int rnd = Random.Range(0, treasureChestItemIds.Count);
        return ItemSettings.Instance.Get(treasureChestItemIds[rnd]);
    }
}
