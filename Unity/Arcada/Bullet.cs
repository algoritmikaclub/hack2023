using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Скрипт для пуль

    public string tag; //Здесь будем сохранять тег того, кого должна уничтожать пуля

    public float speed = 3; //Здесь сохраняем скорость пули (чтобы скорость полёта пули у разных врагов могла быть разная)

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime); //Постоянно перемещаем пулю вверх
    }

    private void OnTriggerEnter2D(Collider2D collision) //При касании триггера
    {
        if (collision.gameObject.CompareTag(tag)) //Если тот, кто конснулся пули имеет нужный нам тег
        {
            Destroy(collision.gameObject); //Уничтожаем того, кого коснулись
            Destroy(gameObject); //Уничтожаем пулю (чтобы не летела дальше)
        }
    }
}
