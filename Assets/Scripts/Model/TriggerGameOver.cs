using Model;
using UnityEngine;

public class TriggerGameOver : MonoBehaviour
{
	[SerializeField] private MController mController;	
	private void OnTriggerEnter(Collider other)
	{
		Cube cube = other.GetComponent<Cube>();
		if (cube)
		{
			if (cube.isActive)
			{
				mController.GameOver();
			}
			else
				cube.isActive = true;
		}
	}
}
