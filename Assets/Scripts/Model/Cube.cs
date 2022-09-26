using UnityEngine;

namespace Model
{
	//cube control
	public class Cube : MonoBehaviour
	{
		[SerializeField] private MeshRenderer meshRenderer;

		private PlaceInstantiate placeInstantiate;

		[SerializeField] private ParticleSystemRenderer particleSystemRender;
		
		private GameObject prefabParticle;

		public int size;
		public bool isActive;
		public bool isDestroy;
		
		//init
		public void Init(Material material, int size, PlaceInstantiate pi)
		{
			meshRenderer.material = material;
			this.size = size;
			placeInstantiate = pi;
		
			particleSystemRender.material = material;
		}

		//end cube update on collision
		public void Init(Material material, GameObject prefabParticle)
		{
			meshRenderer.material = material;
			this.prefabParticle = prefabParticle;

			particleSystemRender.material = material;
		}

		//start cube update on collision
		public void ReInit()
		{
			placeInstantiate.ReInitCube(this);
		}

		//collision effect
		public void UpdateParticle()
		{
			Instantiate(prefabParticle, gameObject.transform.position, Quaternion.identity).
				GetComponent<CubeParticle>().Init(meshRenderer.material);
		}
		
		//collision's
		private void OnCollisionEnter(Collision other)
		{
			Cube cube = other.gameObject.GetComponent<Cube>();
			if (cube && cube.size == size)
			{
				if (!isDestroy && !cube.isDestroy)
				{
					cube.ReInit();
					cube.GetComponent<Rigidbody>().velocity +=
						Vector3.up * (Random.Range(0, 6)) +
						Vector3.right * (Random.Range(0, 6) - 3) +
						Vector3.forward * (Random.Range(0, 6) - 3);
					
					cube.UpdateParticle();
					
					isDestroy = true;
					Destroy(gameObject);
				}
			}
		}
	}
}