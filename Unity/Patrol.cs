using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    //Скрипт для патрулирования

    public float speed = 3;

    public bool goLeft = true;

    //Обязательно укажите в юнити 2 точки (2 объекта) между которыми должен патрулировать объект
    public Transform left;
    public Transform right;

    
    void Update()
    {
        if (goLeft == true)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        if (goLeft == false)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        if (transform.position.x < left.position.x)
        {
            goLeft = false;
        }
        if (transform.position.x > right.position.x)
        {
            goLeft = true;
        }
    }
}
