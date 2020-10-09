using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    Button button;
    GameObject stageButton1;
    GameObject stageButton2;
    GameObject stageButton3;
    GameObject stageButton4;

    void Start()
    {
        stageButton1 = GameObject.Find("Master/Canvas/StageButton").gameObject;
        stageButton2 = GameObject.Find("Master/Canvas/StageButton (1)").gameObject;
        stageButton3 = GameObject.Find("Master/Canvas/StageButton (2)").gameObject;
        stageButton4 = GameObject.Find("Master/Canvas/StageButton (3)").gameObject;
        button = GameObject.Find("Master/Canvas/Button (2)").GetComponent<Button>();
        //ボタンが選択された状態になる
        button.Select();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) GameEnd();
    }

    public void FromTheBegining(string stage)
    {
        SceneManager.LoadScene(stage);
    }

    public void Continue()
    {
        stageButton1.SetActive(true);
        stageButton2.SetActive(true);
        stageButton3.SetActive(true);
        stageButton4.SetActive(true);
    }

    public void GameEnd()
    {
        //後で消す。
        UnityEditor.EditorApplication.isPlaying = false;
        UnityEngine.Application.Quit();
    }
}
