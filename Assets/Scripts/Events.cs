using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Events : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "CharacterForm")
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene(0);
            }
            else {
                SceneManager.LoadScene(1);
            }
            
        }
    }

}
