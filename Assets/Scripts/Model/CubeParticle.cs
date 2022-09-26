using UnityEngine;

namespace Model
{
	//particle system BOOM
	public class CubeParticle : MonoBehaviour
	{
		[SerializeField] private ParticleSystem particleSystem;
		[SerializeField] private ParticleSystemRenderer particleSystemRender;

		//init material and subscribe on destroy event
		public void Init(Material material)
		{
			particleSystemRender.material = material;
		
			ParticleSystem.MainModule main = particleSystem.main;
			main.stopAction = ParticleSystemStopAction.Destroy;
		}
	}
}
