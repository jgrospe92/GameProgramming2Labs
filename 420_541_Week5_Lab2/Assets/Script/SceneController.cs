using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "DeathPlane")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }

  
}
