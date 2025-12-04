using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] int damage;
    [SerializeField][Range(0f, 1f)] float damageRate;

    private float wait = 0.1f;
    private float lastAttack = -1f;

    private Coroutine damageCoroutine;
    private PlayerMove player;

    // GAME //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    private void Awake()
    {
        player = FindAnyObjectByType<PlayerMove>();
    }

    private void FixedUpdate()
    {
        EnemyMovement();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(Time.time - lastAttack > wait)
        {
            if (other.CompareTag("Player"))
            { damageCoroutine = StartCoroutine(DoDamage(other)); }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (damageCoroutine != null)
            { StopCoroutine(damageCoroutine); }
        }

        lastAttack = Time.time;
    }

    // FUNCTIONS //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    public void EnemyMovement()
    { 
        if (player != null)
        { transform.position = Vector2.MoveTowards(transform.position, player.head.position, Random.Range(minSpeed, maxSpeed) * Time.deltaTime);  }
    }


    IEnumerator DoDamage(Collider2D other)
    {
        while (true)
        {
            Debug.Log($"{other.gameObject.name} take {damage} damages");
            Life life = other.GetComponent<Life>();
            life.TakeDamage(damage);

            yield return new WaitForSeconds(damageRate);
        }
    }
}