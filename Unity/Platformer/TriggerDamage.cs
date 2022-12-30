using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    //Нанесение урона при касании (у нашего объекта должен быть триггер)
    //У противника обязательно должен быть скрипт "HP"
    
    public int dmg;
    public string tag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            var hp = collision.gameObject.GetComponent<HP>();

            hp.Damage(dmg);
        }
    }
}
