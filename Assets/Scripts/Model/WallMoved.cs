using UnityEngine;

namespace Model
{
	//wall wave animation move
	public class WallMoved : MonoBehaviour
	{
		[SerializeField] private Animation aWall;
		private Vector3 startPosition;

		private void Start()
		{
			startPosition = aWall.transform.position;
		}

		public void StartMove(float time)
		{
			aWall.transform.position = startPosition;
			aWall.Play();
		}
	}
}