using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    //public ParticleSystem particle;
    public GameObject player;

    private void Update()
    {
        if (this.gameObject.transform.position == player.transform.position)
        {
            //particle.transform.position = player.gameObject.transform.position;
            //particle.Play();
            player.gameObject.SetActive(false);
        }
    }
}
