using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    //Открывает сцену, указанную в id при касании (скрипт передаётся порталу на след. уровень)

    public int id;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(id);
    }

}
