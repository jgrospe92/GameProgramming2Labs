using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float fireRate = 2f;
    [SerializeField] private GameObject bulletPrefab;
    private float nextFireTime;
   // [SerializeField] private Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.up, Color.red);

        if (Physics.Raycast(transform.position, (transform.up), out hit))
        {

            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("shhot");
                Debug.Log(hit.transform.tag);
                if (Reload())
                {
                    FireBullet();
                }
               
            }
        }

    }

    private bool Reload()
    {
        return Time.time > nextFireTime;
    }

    void FireBullet()
    {
        // Instantiate the bullet prefab at the fire point
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.up * 50f, ForceMode.Impulse);

        nextFireTime = Time.time + 1f / fireRate;
    }
}
