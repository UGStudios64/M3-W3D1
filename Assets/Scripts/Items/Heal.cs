using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] int heal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            Life life = other.GetComponent<Life>();
            life.TakeHeal(heal);
            Debug.Log($"you got {heal}");

            Destroy(gameObject);
        }   
    }
}
