using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ResultData_Manager : MonoBehaviour
{


    [Header("各種テキストの表示箇所")]
    public Text time;

    public Text defeat;

    public Text enemy;

    public Text finishFactor;

    public Text comment;


    [Header("コメントなどのプリセットデータ")]

    public ResultTextLists useDatas;


    [Header("プレイデータ")]

    GameObject gameManager;

    StrPlayData viewData;

    public string SmouRank;
    public string commentRank;






    void Start()
    {

        //Stringモデルクラス
        viewData = new StrPlayData();

        //モデルに格納する文字列データを作る
        CreateViewText(viewData);

        //
        //UpdateViewText();


    }

    public void UpdateViewText()
    {
        //シーン内テキストオブジェクトを初期化
        time.text = "";
        defeat.text = "";
        enemy.text = "";
        finishFactor.text = "";
        comment.text = "";


        //フォーマット済データを反映
        time.text = viewData.timeCount;
        defeat.text = viewData.killCount;
        enemy.text = viewData.enemyType;
        //ランク評価後、反映
        finishFactor.text = useDatas.finishFactorList[0];
        comment.text = useDatas.commentList[0];
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
        viewData.choicedFinishFactor = useDatas.finishFactorList[0];
        viewData.choicedComment = useDatas.commentList[0];
        viewData.choicedSumouRank = useDatas.banzukeList[0];


        //データを文字列化し、かつ、漢数字にフォーマットしたものを、
        viewData.timeCount = $" {ToKanjiNumber(tester.time)}ふん";
        viewData.killCount = $" {ToKanjiNumber(tester.killEnemy)}勝ち";
        viewData.enemyType = tester.enemyType.ToString();




    }




    public void PlayRankGrade(TestManager tester)
    {

        //生存時間が伸びることによって、番付のランクが変わる？

        //倒した敵の数によって、コメントが変化する？

        // public string SmouRank;
        // public string commentRank;










        //プラン１ ifのネストで内容を書き換える

        //問題点 他のデータはスクリプタブルオブジェクトでまとめているので、データはそちらでまとめたい。
        if (tester.time > 0)
        {
            this.SmouRank = useDatas.banzukeList[0];

        }
        if (tester.time > 5)
        {
            this.SmouRank = useDatas.banzukeList[1];

            this.SmouRank = useDatas.banzukeList[2];
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


        //プラン２ スイッチ文の中のIF文で分岐
        //問題点、リストと離れてしまう

        // int suviveTime = 0;

        //   switch (suviveTime)
        // {
        //     case int s when s >= 90:
        //         this.SmouRank = useDatas.banzukeList[0];

        //     case int s when s >= 80:
        //     case int s when s >= 70:
        //     case int s when s >= 60:


        //     default:
        //         return "ビギナー";
        // }

        //プラン3





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
        string[] kanjiUnits = { "", "十", "百", "千" };

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



