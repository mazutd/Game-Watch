﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playMenuOption : MonoBehaviour
{
    // Start is called before the first frame update
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        
    }
        public void RestartGameGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        
    }

}
