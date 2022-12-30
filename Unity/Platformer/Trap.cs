using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    //Удаление этого объекта при касании с другим объектом
    
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(gameObject); //Уничтожаем владельца скрипта
    }

}
