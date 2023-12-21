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
    public Text skill;
    public Text comment;
    public Text rank;


    public Text enemy;
    public Text finishFactor;


    [Header("コメントなどのプリセットデータ")]

    public ResultTextLists useDatas;


    [Header("プレイデータ")]

    GameObject gameManager;

    StrPlayData viewData;

    public string playerRank;
    public string commentRank;



    //文字データの表示アニメは、このメソッドが受け持つが、
    //巻物を開くアニメは、リザルトビュー内のスクリプトで実行しているので、
    //リザルトビューを参照し、巻物アニメの再生が終わったかどうかの情報をとる。
    public ResultViewAnimation viewanim;

    //アニメーションコルーチンが実行されるときに格納される。
    //アニメーションが実行されたら、ここに中身が入るので、nullな場合のみアニメ実行で、アニメ再生を１回だけ再生する。
    Coroutine coroutine;

    // アニメ再生のディレイ時間
    public float delayTime = 0.5f;


    void Start()
    {
        //あとで文字を入れたい、テキストオブジェクトに空文字を入れておく。
        time.text = "";
        defeat.text = "";
        enemy.text = "";
        finishFactor.text = "";
        comment.text = "";


        //String型のモデル
        viewData = new StrPlayData();

        //モデルに格納する文字列データを作る
        CreateViewText(viewData);


    }

    void Update()
    {


        if (coroutine == null && !viewanim.IsAnimating)
        {
            //UpdateViewText();
            coroutine = StartCoroutine(UpdateViewText());
        }

    }


    private IEnumerator UpdateViewText()
    {

        // コルーチンで時間を待ってから、各種テキストを表示する。
        // フォーマット済の文字列データを、空文字のテキストオブジェクトに、代入することで、表示している。

        yield return StartCoroutine(Wait());
        time.text = viewData.timeCount;//生存時間

        yield return StartCoroutine(Wait());
        defeat.text = viewData.killCount;//倒した数

        yield return StartCoroutine(Wait());
        skill.text = "◆◆　◆◆　◆◆　◆◆　◆◆ \n◆◆　◆◆　◆◆　◆◆　◆◆";//取得スキルを後で表示する

        yield return StartCoroutine(Wait());
        comment.text = useDatas.commentList[0];//ひとことを反映

        yield return StartCoroutine(Wait());
        rank.text = playerRank;//番付ランクの反映



    }

    private IEnumerator Wait()
    {
        // 任意の時間を待つ
        // yield return new WaitForSeconds(delayTime);

        float elapsedTime = 0f;

        while (elapsedTime < delayTime)
        {
            if (Input.GetMouseButtonDown(0)) // クリックを検出
            {
                break; // クリックが検出されたらループを終了
            }

            elapsedTime += Time.deltaTime;
            yield return null; // 次のフレームまで待機



        }
    }





    public void CreateViewText(StrPlayData viewData)
    {
        //プレイデータを探してくる。
        this.gameManager = GameObject.Find("TestManager");

        //スクリプトからフィールドを取得。
        TestManager tester = gameManager.GetComponent<TestManager>();

        //データを使って、プレイを格付けする。
        PlayRankGrade(tester);

        //データを文字列化し、かつ、漢数字にフォーマットしたものを、
        viewData.timeCount = $"{ToKanjiNumber(tester.time)} ふん" + "\n" + $"{ToKanjiNumber(tester.time)} びょう";
        viewData.killCount = $"{ToKanjiNumber(tester.killEnemy)} 勝ち";
        viewData.enemyType = tester.enemyType.ToString();
    }





    public void PlayRankGrade(TestManager tester)
    {

        //各番付クラスが、基準となるタイムの値を持っているので、それを満たすかをチェック。
        //番付リストは条件が低い順に入っているので、条件が満たされなかったらbreak。
        foreach (Banzuke banzuke in useDatas.banzukeList)
        {
            if (tester.time < banzuke.time)
            {
                playerRank = banzuke.name;
                break;
            }
        }

        //倒したエネミーの数をチェックする（評価ロジック未実装）
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

        //このあと、ランク評価をもう少し数値で行う？
        //生存時間評価 ＋ 倒した敵の数 

    }



    //数字を与えられたときに、漢数字の文字列に変換して返す。
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



