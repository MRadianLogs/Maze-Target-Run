using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunMechanics : MonoBehaviour
{
    [SerializeField]
    private Transform playerCamera = null;

    [SerializeField]
    private GameObject bulletPrefab = null;
    [SerializeField]
    private Transform bulletSpawnPoint = null;

    [SerializeField] private AudioSource fireSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootGun();
    }

    private void ShootGun()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Quaternion fireDirection = Quaternion.LookRotation(playerCamera.forward + bulletSpawnPoint.forward);
            Instantiate(bulletPrefab, bulletSpawnPoint.position, fireDirection);
            fireSound.Play();
        }
    }
}
