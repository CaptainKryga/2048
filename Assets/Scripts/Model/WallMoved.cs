using System.Collections;
using UnityEngine;

namespace Model
{
	public class WallMoved : MonoBehaviour
	{
		[SerializeField] private Transform wall;
		[SerializeField] private Transform pointStart;
		[SerializeField] private Transform pointEnd;

		public void StartMove(float time)
		{
			StartCoroutine(Move(time));
		}

		IEnumerator Move(float time)
		{
			float tempTime = time;
			while (time > 0)
			{
				time -= Time.deltaTime;
				Vector3.MoveTowards(wall.position, pointEnd.position, tempTime);
				yield return new WaitForEndOfFrame();
			}
			yield break;
		}
	}
}