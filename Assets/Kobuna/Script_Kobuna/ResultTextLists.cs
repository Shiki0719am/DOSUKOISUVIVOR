using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResultTextLists", menuName = "DOSUKOISUVIVOR/ResultTextLists", order = 0)]

public class ResultTextLists : ScriptableObject
{
    public List<string> commentList;
    public List<string> enemyNameList;
    public List<string> finishFactorList;

    public List<string> banzukeList;
    public List<SumouData> sumouList;


    [Serializable]
    public class SumouData
    {
        public string name;
        public int time;
    }
}