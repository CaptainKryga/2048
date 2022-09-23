using UnityEngine;

namespace Controller
{
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
	}
}