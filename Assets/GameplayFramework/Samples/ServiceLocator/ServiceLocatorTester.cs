using GameplayFramework.Core.Services;
using UnityEngine;

public class ServiceLocatorTester : MonoBehaviour
{
	private void Start()
	{
		ServiceLocator.Register(new AudioManager());

		if (ServiceLocator.Contains<AudioManager>())
		{
			var audio = ServiceLocator.Get<AudioManager>();
			audio.Play();
		}
		ServiceLocator.Unregister<AudioManager>();

		Debug.Log(ServiceLocator.Contains<AudioManager>());

		ServiceLocator.Clear();
	}
}

public class AudioManager
{
	public void Play()
	{
		Debug.Log("Playing audio...");
	}
}
