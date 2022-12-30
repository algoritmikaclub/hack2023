using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Скрипт для подбора монет, ключей и открытия дверей ключами
    //Обязательно добавьте теги Key, Door, Coin в ваш проект

    public int keys = 0;
    public int coins = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            keys += 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Door"))
        {
            if (keys > 0)
            {
                keys -= 1;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            coins += 1;
            Destroy(collision.gameObject);
        }
    }
}
