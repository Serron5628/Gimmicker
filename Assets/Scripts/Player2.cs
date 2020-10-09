using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    //ハート３つ
    public int hp = 3;
    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public Material normalMat;
    public Material pinchMat;
    public Material outMat;
    public Material haveMat;
    GameObject shape;
    Animator anim;
    GameObject skinMesh;
    AMassMove scr;
    GameObject piyo;
    public GameObject gameMaster;

    private void Start()
    {
        shape = transform.Find("Shape").gameObject;
        anim = shape.gameObject.GetComponent<Animator>();
        skinMesh = shape.gameObject.transform.Find("hero").gameObject;
        scr = GetComponent<AMassMove>();
        piyo = shape.transform.Find("faintedBird").gameObject;
    }

    void FixedUpdate()
    {
        if (hp == 2) hp1.SetActive(false);
        if (hp == 1) hp2.SetActive(false);
        if (hp < 1) hp3.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Damage();
        }
    }

    void Damage()
    {
        hp--;
        if (hp == 0)
        {
            gameMaster.gameObject.SendMessage("PlayerDead");
            anim.ResetTrigger("Walk");
            anim.SetTrigger("Death");
            skinMesh.GetComponent<SkinnedMeshRenderer>().material = outMat;
            scr.canMove = false;
            piyo.SetActive(true);
            hp--;
        }
        else
        {
            scr.target = scr.beforePos;
            anim.ResetTrigger("Walk");
            anim.SetTrigger("Damage");
            skinMesh.GetComponent<SkinnedMeshRenderer>().material = pinchMat;
            Invoke("NormalMat", 0.8f);
        }
    }

    void NormalMat()
    {
        skinMesh.GetComponent<SkinnedMeshRenderer>().material = normalMat;
    }

    void HaveMat()
    {
        skinMesh.GetComponent<SkinnedMeshRenderer>().material = haveMat;
    }
}
