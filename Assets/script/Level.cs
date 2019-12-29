﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; // for debugging purposes

    //cached
    sceneLoader sceneloader;

    public void Start()
    {
       sceneloader = FindObjectOfType<sceneLoader>();
    }
    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if ( breakableBlocks <= 0)
        {
            sceneloader.LoadNextScene();
        }
    }
}
