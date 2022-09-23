using UnityEngine;
using View;

namespace Model
{
	public class Statistics : MonoBehaviour
	{
		[SerializeField] private VController vController;

		private int score;
		private int maxSize;
		private int maxRank;
		
		public int Score
		{
			get => score;
			set
			{
				score += value;
				vController.UpdateScore(score);
			}
		}

		public int MaxSize
		{
			get => maxSize;
			set
			{
				if (maxSize < value)
				{
					maxSize = value;
					maxRank++;
				}
			}
		}

		public int MaxRank
		{
			get => maxRank;
			private set => maxRank = value;
		}
	}
}