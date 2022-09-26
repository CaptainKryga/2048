using UnityEngine;

namespace Model
{
	//graphic settings
	public class QSettings : MonoBehaviour
	{
		private void Awake()
		{
			QualitySettings.maxQueuedFrames = 60;
			QualitySettings.vSyncCount = 1;
		}
	}
}
