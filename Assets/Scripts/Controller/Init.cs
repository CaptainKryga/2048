using UnityEngine;

namespace Controller
{
	public class Init : MonoBehaviour
	{
		[SerializeField] private Game game;

		private void Start()
		{
			game.RestartGame();
		}
	}
}