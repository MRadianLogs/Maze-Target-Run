using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBulletBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody bulletRigidBody = null;

    [SerializeField]
    private float bulletDamage = 10f;
    [SerializeField]
    private float bulletSpeed = 10f; //For some reason, this has to be set to 200000...
    [SerializeField]
    private float bulletLifeTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidBody.AddForce(transform.forward * bulletSpeed * Time.deltaTime);
        bulletRigidBody.velocity *= bulletSpeed;
        StartCoroutine(DecreaseLifeTime());
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hit something!");
        Destroy(gameObject);
    }

    IEnumerator DecreaseLifeTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            bulletLifeTime -= 1f;
            if(bulletLifeTime <= 0)
            {
                //gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
