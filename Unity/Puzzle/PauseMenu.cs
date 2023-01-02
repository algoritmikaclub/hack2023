using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    //Работа меню паузы. Включает в себя отображение меню, скрытие, а также работу для кнопки рестарт. 
    //Переход в главное меню через скрипт ButtonOpenScene

    public GameObject menu;

    public void HideMenu()
    {
        menu.SetActive(false);
    }
    public void ShowMenu()
    {
        menu.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
