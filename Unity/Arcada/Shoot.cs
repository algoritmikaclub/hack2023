using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //Стрельба игрока по нажатию кнопки

    public GameObject bulletPrefab;
    public bool isReadyShoot = true;
    public float reloadTime = 1;
    
    void Update()
    {
        if ( Input.GetKey(KeyCode.Space)   && isReadyShoot == true)
        {
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.transform.position = transform.position;
            
            isReadyShoot = false;
            StartCoroutine(Reload());
        }
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        isReadyShoot = true;
    }
}
