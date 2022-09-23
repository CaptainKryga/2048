using UnityEngine;

namespace Model
{
	[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Database", order = 1)]
	public class Database : ScriptableObject
	{
		public GameObject prefab;
		public Material[] materials;
	}
}