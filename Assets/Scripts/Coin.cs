using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if ("Player".Equals(other.tag))
        {
            other.GetComponent<Player>()?.AddCoin();
            Destroy(this.gameObject);
        }
    }
}
