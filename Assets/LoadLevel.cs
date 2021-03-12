﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public int SceneNumber;


    public void LoadScene()
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
