using UnityEngine;

namespace Model
{
	public class Statistics : MonoBehaviour
	{
		private int score;
		public int Score
		{
			get => score;
			set => score += value;
		}

		private int maxSize;
		public int MaxSize
		{
			get => maxSize;
			set => maxSize = value;
		}
	}
}