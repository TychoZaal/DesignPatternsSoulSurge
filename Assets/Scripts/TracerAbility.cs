using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracerAbility : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    //originator of the memento data
    private PlayerMovement originator;

    private PlayerCaretaker careTaker = new PlayerCaretaker();
    private int mementoIndex = 0;
    private bool canTeleport = false;

    private void Start()
    {
        originator = player.GetComponent<PlayerMovement>();
        StartCoroutine(PeriodicalPlayerStateSafe());
    }

    IEnumerator PeriodicalPlayerStateSafe()
    {
        yield return new WaitForSeconds(2);

        careTaker.AddMemento(originator.StoreInMemento());
        StartCoroutine(PeriodicalPlayerStateSafe());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(mementoIndex > 2)
            {
                Reset();
                return;
            }
            PlayerMemento LastSavedMemento = careTaker.GetMemento(mementoIndex);
            Vector2 LastSavedPosition = LastSavedMemento.GetSavedPlayerPosition();
            originator.SetPosition(LastSavedPosition);
            mementoIndex++;
        }
    }

    IEnumerator SetCanTeleport()
    {
        this.mementoIndex++;
        yield return new WaitForSeconds(3);
        Reset();
    }

    private void Reset()
    {
        this.mementoIndex = 0;
    }
}
