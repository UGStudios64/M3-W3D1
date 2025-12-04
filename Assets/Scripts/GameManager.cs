using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int enemiesKilled = 0;
    public int killTarget = 5;
    private Spawn spawn;
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        spawn = FindObjectOfType<Spawn>();
    }

    public void EnemyKilled()
    {
        enemiesKilled++;

        Debug.Log("Nemici sconfitti: " + enemiesKilled);

        if (enemiesKilled == killTarget) spawn.SpawnStart();
    }
}
