using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutlineExample : MonoBehaviour
{
    public Text text;

    void Start()
    {
        // シャドウの設定
        Outline outline = text.gameObject.AddComponent<Outline>();
        outline.effectColor = Color.black; // 縁取りの色
        outline.effectDistance = new Vector2(10f, 10f); // 縁取りの距離
    }
}

