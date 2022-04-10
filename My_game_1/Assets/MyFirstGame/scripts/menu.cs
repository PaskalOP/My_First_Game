using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    [SerializeField] private Button _start;
    [SerializeField] private Button _exit;

    private void Awake()
    {
        _exit.onClick.AddListener(() => { Application.Quit(); });
        _start.onClick.AddListener(StartGame);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
