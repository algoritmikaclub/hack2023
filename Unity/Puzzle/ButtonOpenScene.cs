using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonOpenScene : MonoBehaviour
{
    //Номер сцены узнаётся в File -> Build Settings -> Scenes in build
    
    //Скрипт передаётся кнопке

    public int sceneId;

    public void OpenScene()
    {
        SceneManager.LoadScene(sceneId);
    }
}
