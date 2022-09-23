using UnityEngine;

namespace View
{
	public class VController : MonoBehaviour
	{
		[SerializeField] private Controller.Game cGame;
		
		[SerializeField] private GameObject panelGame;
		[SerializeField] private GameObject panelPause;
		[SerializeField] private GameObject panelRestart;

		public void Restart()
		{
			panelGame.SetActive(true);
			panelPause.SetActive(false);
			panelRestart.SetActive(false);
		}

		public void Pause()
		{
			panelGame.SetActive(false);
			panelPause.SetActive(true);
			panelRestart.SetActive(false);
		}
		
		public void Continue()
		{
			panelGame.SetActive(true);
			panelPause.SetActive(false);
			panelRestart.SetActive(false);
		}

		public void GameOver()
		{
			panelGame.SetActive(false);
			panelPause.SetActive(false);
			panelRestart.SetActive(true);
		}
		
		public void OnClick_Restart()
		{
			cGame.Restart();
		}
		
		public void OnClick_Pause()
		{
			cGame.Pause();
		}
		
		public void OnClick_Continue()
		{
			cGame.Continue();
		}

		public void OnClick_Exit()
		{
			cGame.Exit();
		}
	}
}