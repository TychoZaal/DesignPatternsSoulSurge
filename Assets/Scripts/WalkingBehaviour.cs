using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingBehaviour : MonoBehaviour
{
    public Rigidbody2D target;
    public float moveSpeed = 4f;
    public float turnSpeed = .1f;

    public float chaseRange = 999f;

    public float attackRange = .2f;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;

    public Vector2 attackOffset;

    public Sprite spriteRight;
    public Sprite spriteLeft;
    public Sprite spriteUp;
    public Sprite spriteDown;

    public SpriteRenderer spriteRenderer;

    Rigidbody2D rb;

    float rotAngle = 0f;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        Walk();
    }

    public virtual void Walk()
    {
        if (target == null)
            return;

        float dist = Vector2.Distance(target.position, rb.position);

        if (dist > chaseRange)
        {
            return;
        }

        if (dist <= attackRange)
        {
            if (Time.time >= nextAttackTime)
            {
                if (nextAttackTime == 0f)
                {
                    nextAttackTime = Time.time + .3f;
                    return;
                }

                GetComponent<AttackBehaviour>().Attack();

                nextAttackTime = Time.time + 1f / attackRate;
            }
            return;
        }

        Vector2 dir = (target.position - (rb.position + attackOffset)).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        rotAngle = Mathf.LerpAngle(rotAngle, angle, turnSpeed);

        Vector2 newDir = Quaternion.AngleAxis(rotAngle + 90, Vector3.forward) * Vector3.right;

        Vector2 force = newDir * Time.fixedDeltaTime * moveSpeed;

        rb.AddForce(force);

        float absX = Mathf.Abs(rb.velocity.x);
        float absY = Mathf.Abs(rb.velocity.y);

        if (absX > absY)
        {
            if (rb.velocity.x > .01f)
            {
                spriteRenderer.sprite = spriteRight;
            }
            if (rb.velocity.x < -0.01f)
            {
                spriteRenderer.sprite = spriteLeft;
            }
        }
        else if (absX < absY)
        {
            if (rb.velocity.y > .01f)
            {
                spriteRenderer.sprite = spriteUp;
            }
            if (rb.velocity.y < -0.01f)
            {
                spriteRenderer.sprite = spriteDown;
            }
        }

        spriteRenderer.transform.rotation = Quaternion.identity;
    }

    public void CollisionHandler(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<Player>().TakeDamage(1);
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}

