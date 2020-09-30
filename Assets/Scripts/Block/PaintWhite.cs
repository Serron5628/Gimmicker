using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintWhite : MonoBehaviour
{
    public GameObject block;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Paint"))
        {
            block.SetActive(true);
            other.gameObject.SendMessage("HavingToFalse");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
