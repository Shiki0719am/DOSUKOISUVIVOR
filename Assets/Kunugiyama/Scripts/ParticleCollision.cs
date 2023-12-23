using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    /// パーティクルが他のGameObject(Collider)に当たると呼び出される
    // void OnParticleCollision(Collision other)
    // {
    //     
    // }
    private void OnParticleCollision(GameObject other)
    {
        // 当たった相手の色をランダムに変える
        Destroy(other.gameObject);
        Debug.Log("aaaayu");
    }
}
