using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Component
{
    public abstract float GetSize();
    public abstract float GetSpeed();
}

public class ConcreteComponent : Component
{
    public float size = 1.0f;
    public float speed = 1.0f;
    public override float GetSize()
    {
        return size;
    }

    public float SetSize
    {
        set { size = value; }
    }
    public override float GetSpeed()
    {
        return speed;
    }
}

public abstract class Decorator : ConcreteComponent
{
    protected ConcreteComponent concreteComponent;

    public Decorator(ConcreteComponent concreteComponent)
    {
        this.concreteComponent = concreteComponent;
    }

    public override float GetSize()
    {
        return size;
    }
    public override float GetSpeed()
    {
        return speed;
    }
}

public class ConcreteDecoratorA : Decorator
{
    public ConcreteDecoratorA(ConcreteComponent component) : base(component)
    {
        this.concreteComponent = component;
        size = concreteComponent.size;
    }
    public override float GetSize()
    {
        size *= 1.1f;
        return size;
    }
}

public class ConcreteDecoratorB : Decorator
{
    public ConcreteDecoratorB(ConcreteComponent component) : base(component)
    {
        this.concreteComponent = component;
    }
    public override float GetSpeed()
    {
        speed *= 1.1f;
        return speed;
    }
}

public class PlayerSword : MonoBehaviour
{
    ConcreteComponent weapon = new ConcreteComponent();
    private float speed = 1.0f;
    private float size = 1.0f;
    private float animationSpeed;
    private Vector3 swordSize;

    public Transform sword;
    public int damage = 10;
    public float pushBackForce = 1f;

    public Transform swordPoint;
    public float swordRadius;

    public Animator animator;

    public LayerMask swordMask;

    int test = 0;
    bool jaar1bool;
    bool dubbelBool;

    // Update is called once per frame

    private void Awake()
    {
        weapon = new ConcreteComponent();
        swordSize = sword.transform.localScale;
        animationSpeed = animator.speed;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            AddSize();
            SetStats(weapon);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(swordPoint.position, size, swordMask); //size was swordRadius
            foreach (Collider2D collider in colliders)
            {
                collider.GetComponent<Enemy>().TakeDamage(damage);
                Vector2 dir = (collider.transform.position - transform.position).normalized;
                collider.GetComponent<Rigidbody2D>().AddForce(dir * pushBackForce, ForceMode2D.Impulse);
            }
            animator.SetTrigger("Attack");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(swordPoint.position, swordRadius);
    }

    void SetStats(ConcreteComponent dasWeapon)
    {
        this.speed = dasWeapon.GetSpeed();
        this.size = dasWeapon.GetSize();
        sword.transform.localScale = dasWeapon.GetSize() * swordSize;
        animator.speed = animationSpeed * speed;
    }

    void AddSize()
    {
        weapon = new ConcreteDecoratorA(weapon);
    }

    void AddSpeed()
    {
        weapon = new ConcreteDecoratorB(weapon);
    }
}
