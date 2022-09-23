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
			int maxRnd = statistics.MaxSize;
			Cube cube = Instantiate(database.prefab, 
				pointAttack.position, pointAttack.rotation, 
				parent).GetComponent<Cube>();
			int rnd = Random.Range(0, maxRnd);
			cube.Init(database.materials[rnd], rnd);

			attack = cube.GetComponent<Rigidbody>();
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
				cube.IsActive = true;
			}
		}

		private void ClearScene()
		{
			for (int i = 0; i < parent.childCount; i++)
			{
				Destroy(parent.GetChild(i).gameObject);
			}
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
			
			attack.velocity = -Vector3.forward * 50;
			attack = null;
			
			Invoke("CreateAttack", 1);
		}
	}
}