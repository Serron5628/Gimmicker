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

    private void Start()
    {
        shape = transform.Find("Shape").gameObject;
        anim = shape.gameObject.GetComponent<Animator>();
        skinMesh = shape.gameObject.transform.Find("hero").gameObject;
        scr = GetComponent<AMassMove>();
    }

    void FixedUpdate()
    {
        if (hp == 2) hp1.SetActive(false);
        if (hp == 1) hp2.SetActive(false);
        if (hp == 0) hp3.SetActive(false);
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
            anim.ResetTrigger("Walk");
            anim.SetTrigger("Death");
            skinMesh.GetComponent<SkinnedMeshRenderer>().material = outMat;
            scr.canMove = false;
            hp--;
            //SceneManager.LoadScene("GameOverScene");
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
