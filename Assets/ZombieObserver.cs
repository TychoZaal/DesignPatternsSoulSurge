﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieObserver : MonoBehaviour, IObserver
{
    public static ZombieObserver instance;

    private void Awake()
    {
        instance = this;
    }


    public List<GameObject> objectsToWatch;

    public void AddNewObservable(GameObject newGameObject)
    {
        objectsToWatch.Add(newGameObject);
    }

    public void NotifyAll()
    {
        for (int i = 0; i < objectsToWatch.Count; i++)
        {
            objectsToWatch[i].GetComponent<IObservable>().Notify();
        }
    }
}
