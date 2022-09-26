using UnityEngine;

namespace Controller
{
	//init game
	public class Init : MonoBehaviour
	{
		[SerializeField] private Game game;

		private void Start()
		{
			game.Restart();
		}
	}
}