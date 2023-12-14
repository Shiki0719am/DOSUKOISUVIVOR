using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Comment", menuName = "DOSUKOISUVIVOR/Comment", order = 0)]

public class CommentData : ScriptableObject
{
    public string CommentText;
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