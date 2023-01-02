using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    //Телепортирует объект, который коснулся владельца скрипта в месторасположение переменной target

    public Transform target;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.position = target.position;
    }
}
