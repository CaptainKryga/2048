using UnityEngine;
using View;

namespace Model
{
	//game statistics
	public class Statistics : MonoBehaviour
	{
		[SerializeField] private VController vController;

		private int score;
		private int maxSize;
		private int maxRank;
		
		public int Score { get; private set; }
		//max cube size
		public int MaxSize { get; private set; }
		//max rank from materials on database
		public int MaxRank { get; private set; }

		public void ScoreAdd(int score)
		{
			Score += score;
			vController.UpdateScore(Score);
		}

		public void MaxSizeAdd(int size)
		{
			if (MaxSize < size)
			{
				MaxSize = size;
				MaxRank++;
			}
		}
		
		public void Restart()
		{
			Score = 0;
			MaxSize = 0;
			MaxRank = 2;
		}
	}
}