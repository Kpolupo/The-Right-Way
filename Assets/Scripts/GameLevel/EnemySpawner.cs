using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    private GameObject newEnemy;
    private SpriteRenderer rend;
    private int randomSpawnZone;
    private float randomXposition, randomYposition;
    private Vector3 spawnPosition;


    void Start()
    {
        InvokeRepeating("SpawnNewEnemy", 0f, 1f);
    }

    private void SpawnNewEnemy()
    {
        randomSpawnZone = Random.Range(0, 4); //genero un numero al azar para seleccionar una de 4 zonas donde spawnear el enemigo
        Character.characterInstance.addScore = 15;

        switch (randomSpawnZone)
        {
            case 0:
                randomXposition = Random.Range(-9.8f, -8.8f);
                randomYposition = Random.Range(5.2f, 4.2f);
                break;
            case 1:
                randomXposition = Random.Range(-9.8f, -8.8f);
                randomYposition = Random.Range(-5f, -4.2f);
                break;
            case 2:
                randomXposition = Random.Range(9.8f, 8.8f);
                randomYposition = Random.Range(5.2f, 4.2f);
                break;
            case 3:
                randomXposition = Random.Range(9.8f, 8.8f);
                randomYposition = Random.Range(-5.2f, -4.2f);
                break;
        }

        spawnPosition = new Vector3(randomXposition, randomYposition, 0f);
        newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        rend = newEnemy.GetComponent<SpriteRenderer>();
    }
}
