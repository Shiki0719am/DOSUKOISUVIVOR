using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ResultData_Manager : MonoBehaviour
{


    [Header("各種テキストの表示箇所")]
    public Text time;

    public Text defeat;

    public Text enemy;
    public Text skill;

    public Text finishFactor;

    public Text comment;
    public Text rank;


    [Header("コメントなどのプリセットデータ")]

    public ResultTextLists useDatas;


    [Header("プレイデータ")]

    GameObject gameManager;

    StrPlayData viewData;

    public string playerRank;
    public string commentRank;


    // 任意の時間差
    public float delayBetweenLines = 0.3f;


    void Start()
    {
        //シーン内テキストオブジェクトを初期化
        time.text = "";
        defeat.text = "";
        enemy.text = "";
        finishFactor.text = "";
        comment.text = "";


        //Stringモデルクラス
        viewData = new StrPlayData();

        //モデルに格納する文字列データを作る
        CreateViewText(viewData);

        //
        //UpdateViewText();
        StartCoroutine(UpdateViewText());



    }

    // public void UpdateViewText()
    // {
    //     //フォーマット済データを反映
    //     time.text = viewData.timeCount;
    //     defeat.text = viewData.killCount;
    //     enemy.text = viewData.enemyType;
    //     rank.text = playerRank;
    //     //ランク評価後、反映
    //     finishFactor.text = useDatas.finishFactorList[0];
    //     comment.text = useDatas.commentList[0];
    // }




    private IEnumerator UpdateViewText()
    {
        // フォーマット済データを反映
        time.text = viewData.timeCount;
        yield return StartCoroutine(Wait());

        defeat.text = viewData.killCount;
        yield return StartCoroutine(Wait());

        skill.text = "◆◆　◆◆　◆◆　◆◆　◆◆ \n ◆◆　◆◆　◆◆　◆◆　◆◆";
        yield return StartCoroutine(Wait());


        // 最終的なコメントの反映
        comment.text = useDatas.commentList[0];
        yield return StartCoroutine(Wait());


        // 3つ目の処理完了後、特定の時間を待ってから次の処理
        rank.text = playerRank;
    }

    private IEnumerator Wait()
    {
        // 任意の時間を待つ
        yield return new WaitForSeconds(delayBetweenLines);
    }





    public void CreateViewText(StrPlayData viewData)
    {
        //プレイデータを探してくる。
        this.gameManager = GameObject.Find("TestManager");

        //スクリプトからフィールドを取得。
        TestManager tester = gameManager.GetComponent<TestManager>();


        //データを使って、プレイを格付けする。
        PlayRankGrade(tester);

        //選択する
        //viewData.choicedFinishFactor = useDatas.finishFactorList[0];
        //viewData.choicedComment = useDatas.commentList[0];
        // viewData.currentRank = playerRank;


        //データを文字列化し、かつ、漢数字にフォーマットしたものを、
        viewData.timeCount = $" {ToKanjiNumber(tester.time)} ふん" + "\n" + $" {ToKanjiNumber(tester.time)} びょう";
        viewData.killCount = $" {ToKanjiNumber(tester.killEnemy)} 勝ち";
        viewData.enemyType = tester.enemyType.ToString();
    }





    public void PlayRankGrade(TestManager tester)
    {

        //番付リストから対応する格付けを探してくる
        foreach (Banzuke banzuke in useDatas.banzukeList)
        {
            if (tester.time < banzuke.time)
            {
                playerRank = banzuke.name;
                break;
            }
        }

        //useDatas.banzukeList[0];

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





    static string ToKanjiNumber(int number)
    {
        string[] kanjiDigits = { "〇", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
        string[] kanjiUnits = { "", "十", "百\n", "千\n" };

        StringBuilder result = new StringBuilder();
        char[] digits = number.ToString().ToCharArray();

        for (int i = 0; i < digits.Length; i++)
        {
            int digit = int.Parse(digits[i].ToString());
            if (digit != 0)
            {
                result.Append(kanjiDigits[digit]);
                result.Append(kanjiUnits[digits.Length - i - 1]);
            }
            else
            {
                // 連続する0を無視
                if (i == digits.Length - 1 || digits[i + 1] != '0')
                    result.Append(kanjiDigits[digit]);
            }
        }

        return result.ToString();
    }

    static string ToKanjiNumber(float number)
    {
        // 小数点以下の桁数を指定
        int decimalPlaces = 2;

        int intValue = (int)number;
        float decimalValue = number - intValue;

        string integerPart = ToKanjiNumber(intValue);

        StringBuilder result = new StringBuilder(integerPart);

        if (decimalValue > 0)
        {
            result.Append("点");

            string decimalPart = decimalValue.ToString("F" + decimalPlaces).Substring(2);
            foreach (char digit in decimalPart)
            {
                result.Append(ToKanjiNumber(int.Parse(digit.ToString())));
            }
        }

        return result.ToString();
    }


}



