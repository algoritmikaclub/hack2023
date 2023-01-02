using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrap : MonoBehaviour
{
    //Скрипт ловушки, который передаётся игроку
    //Игрок начнёт уничтожать все объекты с тегом "Trap" при касании

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Destroy(collision.gameObject);
        }
    }
}
