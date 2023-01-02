using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    //Скрипт, отвечающий за работу всей игры
    //Передается фону
    //На фоне создаётся триггер и двигается в самый конец игрового уровня
    //Как только игрок коснётся этого триггера, фон остановится и должен появится босс

    public bool isMoving = true;

    public float speed = 1;

    public GameObject bossObject;

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isMoving = false;
            bossObject.SetActive(true);
        }
    }
}
