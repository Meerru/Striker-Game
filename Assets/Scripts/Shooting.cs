using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public AudioSource shootingSound;

    private void Start()
    {
        shootingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shootingSound.Play();
            Shoot();
        }

    }

    // Method to fire a bullet
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D playerRb = bullet.GetComponent<Rigidbody2D>();
        playerRb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
