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
		}

		public void Pause()
		{
			vController.Pause();
		}

		public void Continue()
		{
			vController.Continue();
		}

		public void GameOver()
		{
			vController.GameOver();
		}
	}
}