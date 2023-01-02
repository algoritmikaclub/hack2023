using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    //Скрипт для пуль игрока
    //Они будут наносить урон по боссу, если у босса будет тег "Boss" и скрипт "HP"
    //Также скрипт мгновенно уничтожает врагов с тегом "Enemy"
    public float speed = 3; //Здесь сохраняем скорость пули (чтобы скорость полёта пули у разных врагов могла быть разная)

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime); //Постоянно перемещаем пулю вверх
    }
    private void OnTriggerEnter2D(Collider2D collision) //При касании триггера
    {
        if (collision.gameObject.CompareTag("Enemy")) //Если тот, кто конснулся пули имеет нужный нам тег
        {
            Destroy(collision.gameObject); //Уничтожаем того, кого коснулись
            Destroy(gameObject); //Уничтожаем пулю (чтобы не летела дальше)
        }
        if (collision.gameObject.CompareTag("Boss")) //Если тот, кто конснулся пули имеет нужный нам тег
        {
            HP bossHP = collision.gameObject.GetComponent<HP>();
            bossHP.Damage(1);
            Destroy(gameObject); //Уничтожаем пулю (чтобы не летела дальше)
        }
    }
}
