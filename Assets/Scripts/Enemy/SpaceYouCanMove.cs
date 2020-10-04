using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceYouCanMove : MonoBehaviour
{
    public GameObject player;
    public GameObject enemys;

    void Update()
    {
        if (player.gameObject.transform.position == this.gameObject.transform.position)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                for (int i = 0; i < enemys.transform.childCount; i++)
                {
                    enemys.transform.GetChild(i).gameObject.GetComponent<EnemyMove>().needMove = true;
                }
                Destroy(this.gameObject);
            }
        }
    }
}
