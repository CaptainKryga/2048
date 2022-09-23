using UnityEngine;

namespace Model
{
	public class Cube : MonoBehaviour
	{
		[SerializeField] private MeshRenderer meshRenderer;
		private PlaceInstantiate placeInstantiate;

		public int size;
		public bool isActive;
		public bool isDestroy;
		
		public void Init(Material material, int size, PlaceInstantiate pi)
		{
			meshRenderer.material = material;
			this.size = size;
			placeInstantiate = pi;
		}

		public void Init(Material material)
		{
			meshRenderer.material = material;
		}

		public void ReInit()
		{
			placeInstantiate.ReInitCube(this);
		}

		private void OnCollisionEnter(Collision other)
		{
			Cube cube = other.gameObject.GetComponent<Cube>();
			if (cube && cube.size == size)
			{
				if (!isDestroy && !cube.isDestroy)
				{
					cube.ReInit();
					cube.GetComponent<Rigidbody>().velocity +=
						Vector3.up * 6 +
						Vector3.right * (Random.Range(0, 6) - 3) +
						Vector3.forward * (Random.Range(0, 6) - 3);
					isDestroy = true;
					Destroy(gameObject);
				}
			}
		}
	}
}