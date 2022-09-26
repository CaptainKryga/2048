using UnityEngine;

namespace Model
{
	//cube attack controller
	public class CubeAttack : MonoBehaviour
	{
		private Rigidbody cubeRigidbody;

		//update actual ube attack
		public void SetRigidbody(Rigidbody rb)
		{
			cubeRigidbody = rb;
		}
		public void ClearRigidbody()
		{
			cubeRigidbody = null;
		}
		
		//moved attack cube
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

		//push attack cube
		public bool PushAttack()
		{
			if (!cubeRigidbody)
				return false;
			
			cubeRigidbody.velocity = -Vector3.forward * 30;
			cubeRigidbody = null;
			return true;
		}
	}
}