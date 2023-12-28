using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    Vector3 enemyPosition;
    public EnemyController[] enemyes;
    private int count = 0;
    // Start is called before the first frame update

    public GameObject enemyPrefab;
    public float xMin, xMax, yMin, yMax;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        count += 1;
        if (count % 10 == 0)
        {
            enemyPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(-0.1f, 1.1f), Random.Range(-0.1f, 1.1f), Camera.main.nearClipPlane));
            enemyPosition.z = 0;
            Instantiate(enemyes[Random.Range(0, enemyes.Length)], enemyPosition, Quaternion.identity);
        }
    }


}