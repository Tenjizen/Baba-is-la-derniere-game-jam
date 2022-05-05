using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] MainGame _mainGame;
    
    public GameObject accueilPause;
    public GameObject parameter;
    public GameObject controls;
    public GameObject credits;

    //public bool pause = false;
    void Awake()
    {
        accueilPause.SetActive(false);
        parameter.SetActive(false);
        controls.SetActive(false);
        credits.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (parameter.activeInHierarchy == false &&
                controls.activeInHierarchy == false &&
                credits.activeInHierarchy == false)
            {
                accueilPause.SetActive(!accueilPause.activeSelf);
                _mainGame.pause = accueilPause.activeSelf;
            }
        }
        //if (pause)
        //{
        //    Time.timeScale = 0;
        //}
        //else if (!pause)
        //{
        //    Time.timeScale = 1;
        //}
    }
    public void OnClickResume()
    {
        accueilPause.SetActive(false);
        _mainGame.pause = false;
    }
    public void OnClickParameter()
    {
        accueilPause.SetActive(false);
        parameter.SetActive(true);
    }
    public void OnClickCredits()
    {
        accueilPause.SetActive(false);
        credits.SetActive(true);
    }
    public void OnClickControls()
    {
        controls.SetActive(true);
        parameter.SetActive(false);
    }
    public void OnClickReturn()
    {
        if (controls.activeInHierarchy == true)
        {
            controls.SetActive(!controls);
            parameter.SetActive(true);
        }
        else
        {
            accueilPause.SetActive(true);
            credits.SetActive(false);
            parameter.SetActive(false);
        }
    }
    public void OnClickLeave()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
