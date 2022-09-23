using UnityEngine;

namespace Model
{
	public class MController : MonoBehaviour
	{
		[SerializeField] private PlaceInstantiate mPlaceInstantiate;
		[SerializeField] private WallMoved mWallMoved;
		[SerializeField] private Statistics mStatistics;

		[SerializeField] private View.VController vController;
		
		public void RestartGame()
		{
			mPlaceInstantiate.RestartGame();
		}
	}
}