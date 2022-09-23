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
			if (cube.IsActive)
			{
				mController.GameOver();
			}
			else
				cube.IsActive = true;
		}
	}
}
