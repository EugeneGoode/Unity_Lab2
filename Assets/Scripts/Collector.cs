using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Collector : MonoBehaviour
{
    int coins = 0;
    [SerializeField] TMP_Text textMsg;
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            textMsg.text = "Coins:" + coins;
        }

    }
}
