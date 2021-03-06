﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int health = 20;

	public GameObject bloodEffect;

    public bool needsAttackTriggered = false;

	SpriteRenderer sr;

	private void Start()
	{
		sr = GetComponentInChildren<SpriteRenderer>();
	}

    public void TakeDamage (int dmg)
	{
        if (needsAttackTriggered)
        {
            ZombieObserver.instance.NotifyAll();
        }

		health -= dmg;

		if (health <= 0)
		{
			Die();
		} else
		{
			StartCoroutine(DamageAnimation());
		}
	}

	IEnumerator DamageAnimation()
	{
		Color c = sr.color;
		c.a = .1f;
		sr.color = c;

		yield return new WaitForSeconds(.1f);

		c.a = 1f;
		sr.color = c;

		yield return new WaitForSeconds(.1f);

		c.a = .1f;
		sr.color = c;

		yield return new WaitForSeconds(.1f);

		c.a = 1f;
		sr.color = c;

		yield return new WaitForSeconds(.1f);

		c.a = .1f;
		sr.color = c;

		yield return new WaitForSeconds(.1f);

		c.a = 1f;
		sr.color = c;

	}

	void Die ()
	{
        ObjectPooler.Instance.SpawnFromPool("Blood", transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
