using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResultTextLists", menuName = "DOSUKOISUVIVOR/ResultTextLists", order = 0)]

public class ResultTextLists : ScriptableObject
{
    [TextAreaAttribute]
    public List<string> commentList;
    public List<string> enemyNameList;
    public List<string> finishFactorList;

    public List<Banzuke> banzukeList;

}

[Serializable]
public class Banzuke
{
    public string name;
    public int time;
}