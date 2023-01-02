using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //Позволяет собирать ключи и монеты, а также открывать двери, тратя ключи
    //Если в переменной scoreText указано текстовое поле, то скрипт отправит туда кол-во монет
    //Переменная scoreText может быть пустой

    public int keys = 0;
    public int coins = 0;

    public Text scoreText;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coins += 1;
            Destroy(collision.gameObject);
            if (scoreText != null)
            {
                scoreText.text = coins.ToString();
            }
        }
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
    }
    
}
