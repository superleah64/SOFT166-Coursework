using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    private bool isFiring = false;
    private void SetFiring()
    {
        isFiring = false;
    }
    private void Fire()
    {
        isFiring = true;
        //Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        GameObject bullet = PoolManager.current.GetPooledObject("Bullet");



        if (bullet != null)
        {
            bullet.transform.position = bulletSpawn.position;
            bullet.transform.rotation = bulletSpawn.rotation;
            bullet.SetActive(true);


            if (GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().Play();
            }
            Invoke("SetFiring", fireTime);
        }
    }
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (!isFiring)
            {
                Fire();
            }
        }
    }
}

