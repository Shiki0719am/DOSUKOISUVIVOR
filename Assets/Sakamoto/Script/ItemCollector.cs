using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            Debug.Log(other.gameObject.name);
    }
}
