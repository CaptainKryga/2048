using UnityEngine;

namespace Controller
{
	public class Game : MonoBehaviour
	{
		[SerializeField] private Model.MController mController;

		public void RestartGame()
		{
			mController.RestartGame();
		}
	}
}