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
    bool isDead = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) LoadTitleScene();
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) && isDead) button.Select();
    }

    public void PlayerDead()
    {
        button = GameObject.Find("GameMaster/Canvas/Button (1)").GetComponent<Button>();
        button1.SetActive(true);
        button2.SetActive(true);
        button.Select();
        isDead = true;
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
