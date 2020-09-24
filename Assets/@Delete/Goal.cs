using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Goal : MonoBehaviour
{
    public GameObject player;
    public Material glad;
    GameObject shape;
    GameObject skinMesh;
    public CinemachineVirtualCamera goalCam;
    bool once = false;
    public GameObject elevator;

    private void Start()
    {
        shape = player.gameObject.transform.Find("Shape").gameObject;
        skinMesh = shape.gameObject.transform.Find("hero").gameObject;
    }

    private void Update()
    {
        if(this.gameObject.transform.position == player.transform.position && once == false)
        {
            player.gameObject.GetComponent<AMassMove>().canMove = false;
            GetComponent<Animator>().SetTrigger("Goal");
            skinMesh.GetComponent<SkinnedMeshRenderer>().material = glad;
            player.transform.rotation = Quaternion.Euler(0, 180, 0);
            player.transform.parent = elevator.transform;
            Invoke("Glad", 1.8f);
            Invoke("Up", 4.5f);
            once = true;
        }
    }

    void Glad()
    {
        shape.gameObject.GetComponent<Animator>().SetTrigger("Glad");
    }

    void Up()
    {
        GetComponent<Animator>().SetTrigger("Up");
    }

    void CameraChange()
    {
        goalCam.Priority = 100;
    }
}
