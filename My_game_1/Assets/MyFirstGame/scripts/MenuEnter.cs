using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuEnter : MonoBehaviour
{

    [SerializeField] private Button _pause;
    [SerializeField] private Button _exit;
     
    [SerializeField] private GameObject _enterenseMenu;

    private void Awake()
    {
        
        _exit.onClick.AddListener(Exit);
        _pause.onClick.AddListener(Resume);
    }
    void Update()
    {
     if (Input.GetButtonDown("Menu inside"))
        {
            
            _enterenseMenu.SetActive(true);
            Time.timeScale = 0f;
            
        }
           
    }
    void Resume()
    {
        _enterenseMenu.SetActive(false);
        Time.timeScale = 1f;
        
    }
    void Exit()
    {
        SceneManager.LoadScene(0);
    } 
    
}


