using UnityEngine;

namespace Model
{
	//database system variables
	[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Database", order = 1)]
	public class Database : ScriptableObject
	{
		public GameObject prefabCube;
		public GameObject prefabParticle;
		public Material[] materials;

		public int[] chanceDrop;
	}
}