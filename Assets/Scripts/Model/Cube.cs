using UnityEngine;

namespace Model
{
	public class Cube : MonoBehaviour
	{
		[SerializeField] private MeshRenderer meshRenderer;
		public int Size { get; private set; }
		public bool IsActive { get; set; } 
		
		public void Init(Material material, int size)
		{
			meshRenderer.material = material;
			Size = size;
		}
	}
}