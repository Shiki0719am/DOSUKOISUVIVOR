using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultViewAnimation : MonoBehaviour
{
    public RectTransform resultViewRectTransform; // Inspectorで設定するための変数
    public float animationDuration = 1.0f; // アニメーションの時間（秒）
    public float targetLeftValue = -971.0f; // アニメーションの終了位置のoffsetMin.x値

    private float startLeftValue; // アニメーション開始時のoffsetMin.x値
    private float timer = 0.0f; // アニメーションの経過時間
    private bool isAnimating = true; // アニメーション中かどうかを示すフラグ
    public bool IsAnimating { get => isAnimating; }

    void Start()
    {
        startLeftValue = resultViewRectTransform.offsetMin.x;
    }

    void Update()
    {
        if (isAnimating)
        {
            AnimateResultView();
        }

        // クリックを検知
        if (Input.GetMouseButtonDown(0)) // 0は左クリックを示す
        {
            // クリックが検知されたら、アニメーションを即時に終了し、targetLeftValueに設定
            resultViewRectTransform.offsetMin = new Vector2(targetLeftValue, resultViewRectTransform.offsetMin.y);
            isAnimating = false;
        }
    }

    public void AnimateResultView()
    {
        if (timer < animationDuration)
        {
            float newLeftValue = Mathf.Lerp(startLeftValue, targetLeftValue, timer / animationDuration);
            resultViewRectTransform.offsetMin = new Vector2(newLeftValue, resultViewRectTransform.offsetMin.y);

            timer += Time.deltaTime;
        }
        else
        {
            isAnimating = false;
        }
    }
}