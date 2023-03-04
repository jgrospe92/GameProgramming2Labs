using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    
    public GameObject particleSystemPrefab;

    // Update is called once per frame
    void Update()   
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0.0f));
      
            GameObject bullet = Instantiate(particleSystemPrefab,transform.position,transform.rotation);
            Destroy(bullet, 2);
            if (Physics.Raycast(ray, out hit)) 
            {
              
               
                TurretComponent hitObject = hit.collider.gameObject.GetComponent<TurretComponent>();
                if (hitObject != null)
                {
                    hitObject.decreaseHp();
                }
            }
        }
    }



}
