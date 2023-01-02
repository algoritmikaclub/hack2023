using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
     //Башня
     
    public GameObject bulletPrefab; //Сохраняем префаб пули
    public float reloadTime = 1; //Время перезарядки
    public bool isReadyShoot = true; //Готовы ли стрелять (перезарядилось ли орудие)
    public TriggerZone zone; //Получаем доступ к скрипту TriggerZone (нужно перетащить в юнити)
    void Update()
    {
        if (isReadyShoot && zone.isPlayerNear) //Проверяем, готово ли орудие стрелять и рядом ли игрок
        {
            StartCoroutine(Shoot()); //Запускаем корутину
        }
    }
    IEnumerator Shoot()
    {
        isReadyShoot = false; //Орудие не готово стрелять (перезаряжается)
        GameObject newBullet = Instantiate(bulletPrefab); //Создаём пулю
        newBullet.transform.position = transform.position; //Перемещаем к владельцу скрипта (турели)
        yield return new WaitForSeconds(reloadTime); //Ждём
        isReadyShoot = true; //Орудие перезарядилось
    }
}
