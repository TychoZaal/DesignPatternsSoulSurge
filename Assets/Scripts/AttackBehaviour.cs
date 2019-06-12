using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour
{
    public Rigidbody2D target;
    public Rigidbody2D rb;

    public Vector2 attackOffset;

    protected virtual void FixedUpdate()
    {
        target = GetComponent<WalkingBehaviour>().target;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Attack()
    {       
        target.GetComponent<Player>().TakeDamage(1);
    }
}
