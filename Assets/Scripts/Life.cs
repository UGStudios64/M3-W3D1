using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] int maxhp;
    [SerializeField] private int hp;

    AudioSource source;
    [SerializeField] private AudioClip hurt;
    [SerializeField] private AudioClip dead;

    private GameManager game;

    // GAME //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    private void Awake()
    {
        hp = maxhp;
        source = GetComponent<AudioSource>();
        if (source == null)
        {
            source = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Start()
    {
        game = GameManager.Instance;
    }

    // FUNCTIONS //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    public void TakeDamage(int damage)
    {
        hp -= damage;
        source.PlayOneShot(hurt);

        if (hp <= 0)
        {
            Debug.Log($"{gameObject.name} is dead");
            if (gameObject.CompareTag("Enemy")) game.EnemyKilled();

            Destroy(gameObject);
        }
        else { Debug.Log($"{gameObject.name} has {hp}/{maxhp}"); }
    }


    public void TakeHeal(int amout)
    {
        hp += amout;

        if (hp > maxhp) { hp = maxhp; }
        Debug.Log($"{gameObject.name} ha {hp}/{maxhp}");
    }
}
