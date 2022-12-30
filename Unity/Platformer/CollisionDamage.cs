using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    //Скрипт для нанесения урона при коллизии (касании)
    //Скрипт наносит урон только по объектам с определённым тегом и скриптом HP

    public int dmg;
    public string tag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            var hp = collision.gameObject.GetComponent<HP>();

            hp.Damage(dmg);
        }
    }
}
