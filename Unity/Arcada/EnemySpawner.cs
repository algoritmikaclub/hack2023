using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Скрипт для спавна врагов

    public GameObject enemyPrefab; //Сохраняем префаб врага

    public float reloadTime = 1; //Здесь храним время между появлениями врагов

    public float spawnDistance = 9;
    void Start()
    {
        StartCoroutine(Spawn()); //Запускаем корутину в первый раз
    }

    IEnumerator Spawn()
    {
        GameObject newEnemy = Instantiate(enemyPrefab); //Создаём нового врага
        newEnemy.transform.position = new Vector3(
            Random.Range(transform.position.x - spawnDistance, transform.position.x + spawnDistance), //коорд Х
            transform.position.y, // коорд Y
            0 //коорд Z
            );  //конец команды
        yield return new WaitForSeconds(reloadTime); //Ждём
        StartCoroutine(Spawn()); //Заного запускаем корутину
    }
}
