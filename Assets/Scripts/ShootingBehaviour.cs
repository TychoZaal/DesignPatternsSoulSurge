using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehaviour : AttackBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Attack()
    {
        Vector2 dir = base.target.position - (rb.position + attackOffset);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        Factory.CreateBullet("large", this); //Lets the factory handle the bullet instantiation. Uses a string to define the type of bullet
    }
}
