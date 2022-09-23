using UnityEngine;

namespace Model
{
	public class MController : MonoBehaviour
	{
		[SerializeField] private PlaceInstantiate mPlaceInstantiate;
		[SerializeField] private WallMoved mWallMoved;
		[SerializeField] private Statistics mStatistics;

		[SerializeField] private View.VController vController;
		
		public void Restart()
		{
			mPlaceInstantiate.Restart();
			vController.Restart();
			Time.timeScale = 1;
		}

		public void Pause()
		{
			vController.Pause();
			Time.timeScale = 0;
		}

		public void Continue()
		{
			vController.Continue();
			Time.timeScale = 1;
		}

		public void GameOver()
		{
			vController.GameOver();
			Time.timeScale = 0;
		}
	}
}