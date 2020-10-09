using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToTitle : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    Button button;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) LoadTitleScene();
    }

    public void PlayerDead()
    {
        button1.SetActive(true);
        button2.SetActive(true);
        button = GameObject.Find("GameMaster/Canvas/Button (1)").GetComponent<Button>();
        button.Select();
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
