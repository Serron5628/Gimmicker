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
    Animator anim;
    AMassMove scr;

    private void Start()
    {
        anim = transform.Find("Shape").gameObject.GetComponent<Animator>();
        scr = GetComponent<AMassMove>();
    }

    void FixedUpdate()
    {
        //HPが〇以下になったときハートが消える
        if (hp < 3) hp1.SetActive(false);
        if (hp < 2) hp2.SetActive(false);
        if (hp < 1) hp3.SetActive(false);
    }

    void Damage()
    {
        hp -= 1;
        if (hp < 1)
        {
            anim.SetTrigger("Death");
            scr.canMove = false;
            //SceneManager.LoadScene("GameOverScene");
        }
        else
        {
            scr.target = scr.beforePos;
            anim.SetTrigger("Damage");
        }
    }
}
