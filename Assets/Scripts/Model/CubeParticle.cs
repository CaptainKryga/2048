using UnityEngine;

public class CubeParticle : MonoBehaviour
{
	[SerializeField] private ParticleSystem particleSystem;
	[SerializeField] private ParticleSystemRenderer particleSystemRender;

	public void Init(Material material)
	{
		particleSystemRender.material = material;
		
		ParticleSystem.MainModule main = particleSystem.main;
		main.stopAction = ParticleSystemStopAction.Destroy;
	}
}
