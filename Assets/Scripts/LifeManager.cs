using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
	public static LifeManager instance;

	private void Awake()
	{
		instance = this;
	}

	private int lives = 3;

	public GameObject shop;
	public GameObject gameOver;
	public Player player;

	public void LooseLife()
	{
		lives--;

		if (lives <= 0)
		{
			GameOver();
		} else
		{
			//Debug.Log("Thank you for your sacrifice. What power would you like in return?");
			shop.SetActive(true);
		}
	}
    
    public int GetLives()
    {
        return lives;
    }

	public void Revive()
	{
		// Return to last spawnpoint
		InstanceMediator.Instance.ResetAllRooms(Pentagram.ActiveRoomName);
		player.transform.position = Pentagram.ActivePosition;
		player.Revive();
	}

	public void GainLife()
	{
		lives++;
		Debug.Log("Congratulations! You recovered a soul fragment!");
	}

	void GameOver()
	{
		gameOver.SetActive(true);
	}

}
