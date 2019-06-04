using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceMediator : MonoBehaviour
{
    private static InstanceMediator _instance;

    public static InstanceMediator Instance
    {
        get
        {
            if (_instance == null)
            {
                //_instance = new InstanceMediator();
            }
            return _instance;
        }
    }

    public void Revive()
    {
        LifeManager.instance.Revive();
    }

    public void GainLife()
    {
        LifeManager.instance.GainLife();
    }

    public void LooseLife()
    {
        LifeManager.instance.LooseLife();
    }

    public void ResetAllRooms(string roomName)
    {
        GameManager.instance.ResetAllRooms(roomName);
    }

    public void LoadNewRoom(GameObject room, DoorDirection direction)
    {
        GameManager.instance.LoadNewRoom(room, direction);
    }

    public GameObject GetCurrentRoom()
    {
        return GameManager.instance.GetCurrentRoom();
    }

    public int GetLives()
    {
        return LifeManager.instance.GetLives();
    }
}
