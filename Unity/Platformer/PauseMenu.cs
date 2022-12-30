using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Открытие и закрытие меню паузы, а также кнопка перезагрузки уровня
    
    public GameObject menu;

    public void ShowMenu()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
    }
    public void HideMenu()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
