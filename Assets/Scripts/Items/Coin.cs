using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int value;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"+{value}");
            CoinsHandler coinsHandler = other.GetComponent<CoinsHandler>();
            coinsHandler.AddCoins(value);

            Destroy(gameObject);
        }
    }
}
