using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCaretaker
{
    List<PlayerMemento> savedPositions = new List<PlayerMemento>();


    public void AddMemento(PlayerMemento m) { this.savedPositions.Insert(0, m); }

    public PlayerMemento GetMemento(int index) { return this.savedPositions[index]; }
}
