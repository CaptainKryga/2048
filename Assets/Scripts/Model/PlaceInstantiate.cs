using UnityEngine;
using Random = UnityEngine.Random;

namespace Model
{
	public class PlaceInstantiate : MonoBehaviour
	{
		[SerializeField] private Database database;
		[SerializeField] private Statistics statistics;

		[SerializeField] private WallMoved wallMoved;
		
		[SerializeField] private Transform parent;
		[SerializeField] private Transform pointAttack;
		[SerializeField] private Transform[] pointsWall;

		private Rigidbody attack;

		[SerializeField] private float timer;
		private float delay;

		public bool IsPause { get; set; }

		private void Start()
		{
			IsPause = false;
			delay = timer;
		}

		private void Update()
		{
			if (IsPause)
				return;

			delay -= Time.deltaTime;
			
			if (delay <= 0)
			{
				CreateWall();
				
				delay = timer;
				wallMoved.StartMove(timer);
			}
		}

		public void Restart()
		{
			ClearScene();
			CreateWall();
			CreateAttack();
			wallMoved.StartMove(timer);
		}

		private void CreateAttack()
		{
			attack = GenerateCube(pointAttack).GetComponent<Rigidbody>();
		}

		public void CreateWall()
		{
			for (int i = 0; i < pointsWall.Length; i++)
			{
				GenerateCube(pointsWall[i]).isActive = true;
			}
		}

		private Cube GenerateCube(Transform pos)
		{
			Cube cube = Instantiate(database.prefab, 
				pos.position, pos.rotation, 
				parent).GetComponent<Cube>();
			int rnd = Random.Range(0, statistics.MaxRank + 1);
			cube.Init(database.materials[rnd], rnd, this);
			cube.size = (int)Mathf.Pow(2, rnd + 1);

			return cube;
		}

		private void ClearScene()
		{
			for (int i = 0; i < parent.childCount; i++)
			{
				Destroy(parent.GetChild(i).gameObject);
			}
		}

		public void ReInitCube(Cube cube)
		{
			statistics.Score = cube.size;
			cube.size *= 2;

			int num = 0;
			int size = cube.size;
			while (size > 2)
			{
				size /= 2;
				num++;
			}
	
			if (num >= database.materials.Length)
				Destroy(cube.gameObject);
			else
				cube.Init(database.materials[num]);
			
			statistics.MaxSize = cube.size;
		}

		public void MoveAttack(Vector3 position)
		{
			if (!attack)
				return;
			
			float x = position.x;
			if (x < -4.5f || x > 4.5f)
				return;
			
			Vector3 pos = attack.transform.position;
			attack.transform.position = new Vector3(x, pos.y, pos.z);
		}

		public void PushAttack()
		{
			if (!attack)
				return;
			
			attack.velocity = -Vector3.forward * 30;
			attack = null;
			
			Invoke("CreateAttack", 1);
		}
	}
}