using UnityEngine;

namespace Model
{
	public class PlaceInstantiate : MonoBehaviour
	{
		[SerializeField] private Database database;
		[SerializeField] private Statistics statistics;
		
		[SerializeField] private Transform parent;
		[SerializeField] private Transform pointAttack;
		[SerializeField] private Transform[] pointsWall;
		
		public void Restart()
		{
			ClearScene();
			CreateWall();
			CreateAttack();
		}

		private void CreateAttack()
		{
			int maxRnd = statistics.MaxSize;
			Cube cube = Instantiate(database.prefab, 
				pointAttack.position, pointAttack.rotation, 
				parent).GetComponent<Cube>();
			int rnd = Random.Range(0, maxRnd);
			cube.Init(database.materials[rnd], rnd);
		}

		public void CreateWall()
		{
			int maxRnd = statistics.MaxSize;
			for (int i = 0; i < pointsWall.Length; i++)
			{
				Cube cube = Instantiate(database.prefab, 
					pointsWall[i].position, pointsWall[i].rotation, 
					parent).GetComponent<Cube>();
				int rnd = Random.Range(0, maxRnd);
				cube.Init(database.materials[rnd], rnd);
			}
		}

		private void ClearScene()
		{
			for (int i = 0; i < parent.childCount; i++)
			{
				Destroy(parent.GetChild(i).gameObject);
			}
		}
	}
}