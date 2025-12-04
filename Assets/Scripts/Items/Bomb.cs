using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] int damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{gameObject.name} take {damage} damages");
        Life life = other.GetComponent<Life>();
        life.TakeDamage(damage);

        Destroy(gameObject);
    }
}
