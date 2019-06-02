using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void NotifyAll();
    void AddNewObservable(GameObject newGameObject);
}

public interface IObservable
{
    void Notify();
}
