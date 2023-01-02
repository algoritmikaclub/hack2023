using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class  TextAnimation: MonoBehaviour
{
    //Сложный скрипт передаётся текстовому полю, чтобы тот был анимирован

    Text textField; //Переменная для текстового поля
    string finalText; //Переменная для сохранения всего текста
    string currentText; //Переменная, хранящая текст, который будет появляться постепенно
    int currentSymbol = 0; //Номер символа, который мы будем добавлять из allText в currentText
    void Start()
    {
        textField = gameObject.GetComponent<Text>(); //Альтернативный способ дать значение переменной - взять компонент из этого gameObject- а
        finalText = textField.text; //Сохраняем весь изначально написанный текст
        textField.text = ""; //Стираем текст с экрана
        StartCoroutine(AddSymbol()); //Запускаем корутину (таймер)
    }
    IEnumerator AddSymbol()
    {
        yield return new WaitForSeconds(0.05f);
        if (finalText != currentText) //Если итоговый текст не совпадает с текущим текстом на экране
        {
            currentText += finalText[currentSymbol]; //Добавляем один символ из финального текста в текущий
            currentSymbol += 1; //Переходим к следующему номеру символа
            textField.text = currentText; //Устанавливаем на текстовое поле текущий текст
            StartCoroutine(AddSymbol()); //Вновь запускаем корутину
        }
    }
}
