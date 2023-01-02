using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDelete : MonoBehaviour
{
    //Удаляет объект, сохранённый в переменной "ob" при касании
    public GameObject ob;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(ob);
    }
}
