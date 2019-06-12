using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    static public GameObject smallBullet;
    static public GameObject largeBullet;
    // Start is called before the first frame update
    void Awake()
    {
        smallBullet = Resources.Load<GameObject>("EnemyBullet");
        largeBullet = Resources.Load<GameObject>("EnemyBulletLarge");
    }

   static public GameObject CreateBullet(string type, EnemySimpleAI enemy)
    {
        Vector2 dir = enemy.target.position - (enemy.rb.position + enemy.attackOffset);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        GameObject go = null;

        if (type == "small")
        {
             go = Instantiate(smallBullet, enemy.rb.position + enemy.attackOffset,
                                    Quaternion.AngleAxis(angle, Vector3.forward),
                                    enemy.transform.parent) as GameObject;
            go.GetComponent<Rigidbody2D>().AddForce(dir.normalized * enemy.bulletSpeed, ForceMode2D.Impulse);
        }

        if (type == "large")
        {
            go = Instantiate(largeBullet, enemy.rb.position + enemy.attackOffset,
                       Quaternion.AngleAxis(angle, Vector3.forward),
                       enemy.transform.parent) as GameObject;
            go.GetComponent<Rigidbody2D>().AddForce(dir.normalized * enemy.bulletSpeed, ForceMode2D.Impulse);
        }

        return go;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
