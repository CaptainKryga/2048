using UnityEngine;

namespace Controller
{
	//global controller from model
	public class Game : MonoBehaviour
	{
		[SerializeField] private Model.MController mController;

		public void Restart()
		{
			mController.Restart();
		}

		public void Pause()
		{
			mController.Pause();
		}

		public void Continue()
		{
			mController.Continue();
		}

		public void Exit()
		{
			Application.Quit();
		}
	}
}