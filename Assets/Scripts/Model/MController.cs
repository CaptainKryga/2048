using UnityEngine;

namespace Model
{
	public class MController : MonoBehaviour
	{
		[SerializeField] private PlaceInstantiate mPlaceInstantiate;
		[SerializeField] private CubeAttack mCubeAttack;
		[SerializeField] private Statistics mStatistics;

		[SerializeField] private View.VController vController;
		
		public void Restart()
		{
			mStatistics.Restart();
			vController.Restart();
			mPlaceInstantiate.Restart();
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

		public void MoveAttack(Vector3 position)
		{
			mCubeAttack.MoveAttack(position);
		}

		public void PushAttack()
		{
			mPlaceInstantiate.RestartAttack(mCubeAttack.PushAttack());
		}
	}
}