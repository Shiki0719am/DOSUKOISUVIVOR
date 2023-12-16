using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PanelText_Manager : MonoBehaviour
{


    [Header("各種データの表示箇所")]
    public Text timeText;

    public Text defeatText;

    public Text enemyText;

    public Text finishFactorText;

    public Text commentText;


    [Header("コメントなどのプリセットデータ")]

    public ResultTextLists useDatas;


    [Header("プレイデータ")]

    GameObject gameManager;

    PlayDataClone cloneData;

    public string SmouRank;







    void Start()
    {
        PlayDataClone cloneData = new PlayDataClone();

        //プレイデータを使って表示用データへの変換を行う
        PlayDataConvert(cloneData);



        //空文字で初期化
        timeText.text = "";
        defeatText.text = "";
        enemyText.text = "";
        finishFactorText.text = "";
        commentText.text = "";






        //中身を改定する
        timeText.text = cloneData.timeData;
        defeatText.text = cloneData.killData;
        enemyText.text = cloneData.enemyType;
        finishFactorText.text = useDatas.finishFactorList[0];
        commentText.text = useDatas.commentList[0];


    }


    void Update()
    {





    }



    public void PlayRankGrade(TestManager tester)
    {


        if (tester.time > 0)
        {
            this.SmouRank = "序の口";
        }
        if (tester.time > 5)
        {
            this.SmouRank = "三段目";

            this.SmouRank = "序二段";
        }
        else if (tester.time > 10)
        {
            this.SmouRank = "前頭";
            this.SmouRank = "十両";
            this.SmouRank = "幕内";
        }
        else if (tester.time > 15)
        {
            this.SmouRank = "小結";
        }
        else if (tester.time > 20)
        {
            this.SmouRank = "関脇";
        }
        else if (tester.time > 27)
        {
            this.SmouRank = "大関";
        }
        else if (tester.time > 30)
        {
            this.SmouRank = "横綱";
        }
        else { Debug.Log("timeの値がおかしいです"); }


        if (tester.killEnemy > 0) { }
        else if (tester.killEnemy > 100) { }
        else if (tester.killEnemy > 200) { }
        else if (tester.killEnemy > 300) { }
        else if (tester.killEnemy > 500) { }
        else if (tester.killEnemy > 700) { }
        else if (tester.killEnemy > 900) { }
        else if (tester.killEnemy > 1000) { }
        else if (tester.killEnemy > 1500) { }
        else if (tester.killEnemy > 2000) { }
        else { }


        //結果としてランク評価のための数値をはじき出す。
        //生存時間評価 ＋ 倒した敵の数 

    }


    public void PlayDataConvert(PlayDataClone cloneData)
    {




        //テスト用のゲームマネージャーオブジェクトを探してくる。
        this.gameManager = GameObject.Find("TestManager");

        //その中からプレイデータが入ったスクリプトをゲットコンポーネント。
        TestManager tester = gameManager.GetComponent<TestManager>();


        //プレイデータを使って、プレイを格付けする。
        PlayRankGrade(tester);

        //プレイデータから、文字列型のデータクローンを作る。
        cloneData.timeData = tester.time.ToString();
        cloneData.killData = tester.killEnemy.ToString();
        cloneData.enemyType = tester.enemyType.ToString();




    }





    //表示部分にセットする用 
    //\nを入れることで改行が可能
    public void Set_TimeText(float setText)
    {
        timeText.text = setText.ToString();
    }

    public void Set_DefeatText(string setText)
    {
        defeatText.text = setText.ToString() + "勝ち";
    }

    public void Set_EnemyText(string setText)
    {
        enemyText.text = setText.ToString();
    }

    public void Set_FinishFactorText(string setText)
    {
        finishFactorText.text = setText.ToString();
    }


    public void Set_CommentText(string setText)
    {
        finishFactorText.text = setText.ToString();
    }
}



