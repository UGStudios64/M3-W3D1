using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Enemy boss;

    public void SpawnStart()
    {
        Enemy enm = Instantiate(boss);
        enm.transform.position = transform.position;
    }
}
