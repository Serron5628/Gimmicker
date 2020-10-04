using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWall : MonoBehaviour
{
    HaveRockAndPutOn scr;

    private void Start()
    {
        scr = transform.parent.gameObject.GetComponent<HaveRockAndPutOn>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Switch") || other.gameObject.CompareTag("Paint"))
        {
            scr.forwardWall = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Switch") || other.gameObject.CompareTag("Paint"))
        {
            scr.forwardWall = false;
        }
    }
}
