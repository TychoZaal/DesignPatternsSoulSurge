using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TricksterAbility : MonoBehaviour
{
    public GameObject player;

    // private PlayerMovement originator = new PlayerMovement();
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(mementoIndex == 1)
            {
                return;
            }
            PlayerMemento LastSavedMemento = careTaker.GetMemento(mementoIndex);
            Vector2 LastSavedPosition = LastSavedMemento.GetSavedPlayerPosition();
            originator.SetPosition(LastSavedPosition);

            StartCoroutine(SetCanTeleport());
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
