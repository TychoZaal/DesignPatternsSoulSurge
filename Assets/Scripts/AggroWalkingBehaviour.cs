using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroWalkingBehaviour : WalkingBehaviour, IObservable
{
    bool canChase = false;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        ZombieObserver.instance.AddNewObservable(gameObject);
    }

    // Update is called once per frame
    public override void FixedUpdate()
    {
        if (canChase)
        {
            base.Walk();
        }
    }

    public void Notify()
    {
        canChase = true;
        Debug.Log("notified");
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (canChase)
        {
            base.CollisionHandler(collision);
        }
    }
}
