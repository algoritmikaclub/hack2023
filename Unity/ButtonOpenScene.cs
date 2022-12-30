using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOpenScene : MonoBehaviour
{
    //Скрипт для открытия новой сцены по нажатию кнопки

    public int sceneId;

    public void OpenScene()
    {
        SceneManager.LoadScene(sceneId);
    }
 
}
