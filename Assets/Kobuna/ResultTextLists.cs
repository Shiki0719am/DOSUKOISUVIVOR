using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResultTextLists", menuName = "DOSUKOISUVIVOR/ResultTextLists", order = 0)]

public class ResultTextLists : ScriptableObject
{
    public List<string> commentList;
    public List<string> enemyNameList;
    public List<string> finishFactorList;






    //public DataType commentType;
    //他の型を作りたい場合。
}

// public enum DataType
// {
//     General,
//     Important,
//     Hint,
//     // 他のコメントの種類
// }