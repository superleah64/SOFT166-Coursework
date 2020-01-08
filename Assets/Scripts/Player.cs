using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;

    private Animator gunAnim;

    private void Start()
    {
        gunAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            gunAnim.SetBool("isFiring", true);
        }
        else
        {
            gunAnim.SetBool("isFiring", false);
        }

    }

    public void SendHealthData(int health)
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
        if (health <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

}
