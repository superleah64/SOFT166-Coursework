using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform[] bulletSpawns;
    public float fireTime = 0.2f;
    private bool isFiring = false;
    private int currentButton = 0;
    private void SetFiring()
    {
        isFiring = false;
    }
    private void Fire()
    {
        isFiring = true;
        //Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        GameObject bullet = PoolManager.current.GetPooledObject("Bullet");

        if (Input.GetMouseButton(0))
        {
            currentButton = 0;
        }

        if (Input.GetMouseButton(1))
        {
            currentButton = 1;
        }
        if (bullet != null)
        {
            bullet.transform.position = bulletSpawns[currentButton].position;
            bullet.transform.rotation = bulletSpawns[currentButton].rotation;
            bullet.SetActive(true);


            if (GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().Play();
            }
            
        }

        Invoke("SetFiring", fireTime);
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            if (!isFiring)
            {
                Fire();
            }
        }


    }
}

