using UnityEngine;
using GameplayFramework.Core.Logging;
namespace GameplayFramework.Core.Bootstrap
{
    /// <summary>
    /// Initializes the framework.
    /// </summary>
    public sealed class Bootstrapper : MonoBehaviour
    {
        private static Bootstrapper _instance;
        private void Awake()
        {
            if (_instance != null)
            {
                FrameworkLogger.Warning("Another instance of Bootstrapper already exists. Destroying this instance.");
                Destroy(gameObject);
                return;
            }

            _instance = this;

            DontDestroyOnLoad(gameObject);

            Initialize();
        }

        private void Initialize()
        {
            // Log the framework name and version
            FrameworkLogger.Info($"Initialized. V:{FrameworkInfo.Version} ");
        }
    }
}
