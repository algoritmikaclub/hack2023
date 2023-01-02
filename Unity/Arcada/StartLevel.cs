using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    //Начало игры: фон не двигается, у нас отображается некий текст на экране. 
    //После нажатия кнопки "начать" текст пропадает и начинается движение фона

    public GameObject spawner; //Сохраните спавнер, создающий врагов
    public GameSession gs; //Сохраните фон (со скриптом GameSession)

    public GameObject text; //Сохраните текст, который должен отображаться в начале игры (включён по умолчанию)

    void Start()
    {
        spawner.SetActive(false);
        gs.isMoving = false;
    }
    public void StartGame()
    {
        spawner.SetActive(true);
        gs.isMoving = true;
        gameObject.SetActive(false);

        text.SetActive(false);
    }
}
