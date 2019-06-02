using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
	public Player player;
	public PlayerMovement playerMovement;
	public PlayerSword playerSword;

	public void OnSpeed()
	{
        InstanceMediator.Instance.Revive();

        playerMovement.speed += 1f;
	}

	public void OnDamage()
	{
        InstanceMediator.Instance.Revive();
        playerSword.damage += 5;
	}

	public void OnHealth()
	{
        InstanceMediator.Instance.Revive();
        player.maxHealth += 1;
	}

}
