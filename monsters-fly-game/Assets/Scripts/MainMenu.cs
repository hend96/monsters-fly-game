using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public AudioSource source;
    public AudioSource gameOver;


    public void Awake(){

        if (win.value == 0)
        {
            this.gameOver.Play();
            win.value = 2;
        }
    }

	 public void PlayGame()
    {
        Application.LoadLevel("lightSecnse");
    }

    public void QuitGame()
    {
        this.source.Play();
        Application.Quit();
    }
	
}
