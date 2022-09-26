using Model;
using UnityEngine;

namespace Controller
{
	//input mouse and push controller
	public class Mouse : MonoBehaviour
	{
		[SerializeField] private MController mController;

		private bool isDown;
		
		private void Update()
		{
			if (Input.GetKey(KeyCode.Mouse0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, 100))
				{
					mController.MoveAttack(hit.point);
				}

				isDown = true;
			}

			if (Input.GetKeyUp(KeyCode.Mouse0) && isDown)
			{
				mController.PushAttack();
				isDown = false;
			}
		}
	}
}
