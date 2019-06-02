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
        InstanceFacade.Instance.Revive();

        playerMovement.speed += 1f;
	}

	public void OnDamage()
	{
        InstanceFacade.Instance.Revive();
        playerSword.damage += 5;
	}

	public void OnHealth()
	{
        InstanceFacade.Instance.Revive();
        player.maxHealth += 1;
	}

}
