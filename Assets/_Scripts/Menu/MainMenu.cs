using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{

    public Image imageFade;
    public GameObject accueil;
    public GameObject parameter;
    public GameObject controls;
    public GameObject credits;

    //public List<Interface> buttons;

    private void Awake()
    {
        accueil.SetActive(true);
        parameter.SetActive(false);
        controls.SetActive(false);
        credits.SetActive(false);
    }

    public void OnClickPlay()
    {

        //imageFade.DOFade(1, 0.8f).OnComplete(FadePlayComplete);
        //for (int i = 1; i < buttons.Count; i++)
        //{
        //    buttons[i].Hide(0.1f);
        //}//Polish pas la
        FadePlayComplete();//a taj si tu remet au dessus
        AudioManager.Instance.audioSourceMusic.Stop();
        
    }

    void FadePlayComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnClickParameter()
    {   
        accueil.SetActive(false);
        parameter.SetActive(true);
    }
    public void OnClickCredits()
    {
        accueil.SetActive(false);
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
            accueil.SetActive(true);
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
