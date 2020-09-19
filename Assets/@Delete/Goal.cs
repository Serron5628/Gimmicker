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

    private void Start()
    {
        shape = player.gameObject.transform.Find("Shape").gameObject;
        skinMesh = shape.gameObject.transform.Find("hero").gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            skinMesh.GetComponent<SkinnedMeshRenderer>().material = glad;
            GetComponent<Animator>().SetTrigger("Goal");
            shape.gameObject.GetComponent<Animator>().SetTrigger("Glad");
        }
    }

    void CameraChange()
    {
        goalCam.Priority = 100;
    }
}
