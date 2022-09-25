using UnityEngine;
using Random = UnityEngine.Random;

namespace Model
{
	public class PlaceInstantiate : MonoBehaviour
	{
		[SerializeField] private Database database;
		[SerializeField] private Statistics statistics;

		[SerializeField] private WallMoved wallMoved;
		[SerializeField] private CubeAttack cubeAttack;
		
		[SerializeField] private Transform parent;
		[SerializeField] private Transform pointAttack;
		[SerializeField] private Transform[] pointsWall;

		[SerializeField] private float timer;
		private float delay, delayAttack, delaySecondRestart;

		private bool isAttack, isRestart;
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
			delayAttack -= Time.deltaTime;
			delaySecondRestart -= Time.deltaTime;

			if (delay <= 0)
			{
				CreateWall();
				
				delay = timer;
				wallMoved.StartMove(timer);
			}

			if (isAttack && delayAttack < 0)
			{
				isAttack = false;
				CreateAttack();
			}

			if (isRestart && delaySecondRestart < 0)
			{
				isRestart = false;
				CreateAttack();
			}
		}

		public void Restart()
		{
			delay = timer;

			ClearScene();
			CreateWall();
			wallMoved.StartMove(timer);

			delaySecondRestart = 0.5f;
			isRestart = true;
		}

		private void CreateAttack()
		{
			cubeAttack.ClearRigidbody();
			cubeAttack.SetRigidbody(GenerateCube(pointAttack, true).GetComponent<Rigidbody>());
		}

		public void CreateWall()
		{
			for (int i = 0; i < pointsWall.Length; i++)
			{
				GenerateCube(pointsWall[i], false);
			}
		}

		private Cube GenerateCube(Transform pos, bool isAttack)
		{
			Cube cube = Instantiate(database.prefab,
				pos.position, pos.rotation,
				parent).GetComponent<Cube>();
			int rnd = GetRarityCube(isAttack); 
			cube.Init(database.materials[rnd], rnd, this);
			cube.size = (int)Mathf.Pow(2, rnd + 1);

			cube.isActive = !isAttack;

			return cube;
		}

		private int GetRarityCube(bool isAttack)
		{
			if (isAttack)
				return Random.Range(0, statistics.MaxRank);

			int sum = 0;
			for (int i = 0; i < statistics.MaxRank; i++)
			{
				sum += database.chanceDrop[i];
			}

			int rnd = Random.Range(0, sum);

			sum = 0;
			for (int i = 0; i < statistics.MaxRank; i++)
			{
				sum += database.chanceDrop[i];
				if (sum > rnd)
					return i;
			}

			return 0;
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
			statistics.ScoreAdd(cube.size);
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
			
			statistics.MaxSizeAdd(cube.size);
		}

		public void RestartAttack(bool isRestart)
		{
			if (isRestart)
			{
				delayAttack = 1f;
				isAttack = true;
			}
		}
	}
}