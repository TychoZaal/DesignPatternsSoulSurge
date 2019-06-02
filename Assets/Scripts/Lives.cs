using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lives : MonoBehaviour
{
	public TextMeshProUGUI text;

	private void Update()
	{
		text.text = InstanceFacade.Instance.GetLives() + " left";
	}

}
