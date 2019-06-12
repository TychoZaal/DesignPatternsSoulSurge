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
        GameObject go = Instantiate(bulletPrefab, rb.position + attackOffset,
                                    Quaternion.AngleAxis(angle, Vector3.forward),
                                    transform.parent) as GameObject;
        go.GetComponent<Rigidbody2D>().AddForce(dir.normalized * bulletSpeed, ForceMode2D.Impulse);
    }
}
