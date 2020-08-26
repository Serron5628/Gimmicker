using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouCanMove : MonoBehaviour
{
    public GameObject[] enemys;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            for(int i = 0; i < enemys.Length; i++)
            {
                //enemys[i].gameObject.GetComponent<>
            }
        }
    }
}
