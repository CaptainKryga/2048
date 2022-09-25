using UnityEngine;

namespace Model
{
	public class CubeAttack : MonoBehaviour
	{
		private Rigidbody cubeRigidbody;

		public void SetRigidbody(Rigidbody rb)
		{
			cubeRigidbody = rb;
		}
		
		public void MoveAttack(Vector3 position)
		{
			if (!cubeRigidbody)
				return;

			float x = position.x;
			if (x < -4.5f || x > 4.5f)
				return;
			
			Vector3 pos = cubeRigidbody.transform.position;
			cubeRigidbody.transform.position = new Vector3(x, pos.y, pos.z);
		}

		public bool PushAttack()
		{
			if (!cubeRigidbody)
				return false;
			
			cubeRigidbody.velocity = -Vector3.forward * 30;
			cubeRigidbody = null;
			return true;
		}

		public void ClearRigidbody()
		{
			cubeRigidbody = null;
		}
	}
}