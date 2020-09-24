using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cube2 : MonoBehaviour
{
    public string NextStage;

    private void OnTriggerEnter(Collider Collision)
    {
        if (Collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("当たった");
            SceneManager.LoadScene(NextStage);
        }
    }
}
