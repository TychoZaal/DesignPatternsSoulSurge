using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMemento
{
    private Vector2 playerPos;

    public PlayerMemento(Vector2 playerPos)
    {
        this.playerPos = playerPos;
    }

    public Vector2 GetSavedPlayerPosition()
    {
        return this.playerPos;
    }
}


