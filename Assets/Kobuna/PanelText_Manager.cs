using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelText_Manager : MonoBehaviour
{
    public Text timeText;

    public Text defeatText;

    public Text enemyText;

    public Text finishFactorText;

    public Text commentText;

    GameObject gameManager;


    void Start()
    {


        //プレイ内容を、確認するために、ゲームマネージャーを取得。
        //gameManager = TypeConvert(GameObject.Find("GameManager"));

        //プレイ記録を、評価値として使うために、定量化する。
        //GameLog_Quantification();

        //評価値を使って、プレイを格付けする。
        //Graded_PlayRank();



        //空文字で初期化
        timeText.text = "";
        defeatText.text = "";
        enemyText.text = "";
        finishFactorText.text = "";
        commentText.text = "";

        //
        //DisplayText();

    }


    void Update()
    {





    }



    // public void Graded_PlayRank(評価値)
    // {
    //     return コメント番号、決まり手、番付
    // }

    // public void GameLog_Quantification(生存時間, 倒した敵の数)
    // {
    //     pass

    //     /*
    //     if (開始すぐならうーん)
    //     else if (１０分以内なら序盤)
    //     else if (２０分以内なら中盤)
    //     else if (２７分以内なら終盤)
    //     else if (３０分未満なら惜しい！)
    //     else if (３０分を越えていたらクリア判定)
    //     else //なにかおかしい！
    //     */

    //     /*
    //     if(倒した敵の数が、１００以内なら、)
    //     */

    //     //結果としてランク評価のための数値をはじき出す。
    //     //生存時間評価 ＋ 倒した敵の数 

    //     //return 評価値

    // }


    public GameObject TypeConvert(GameObject gameManager)
    {
        //おそらくfloatで、生存時間を文字列に変換する
        //おそらくintで、倒した敵の数を文字列に変換する
        return gameManager;
    }



    //テキスト内容を変更するメソッド 
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



