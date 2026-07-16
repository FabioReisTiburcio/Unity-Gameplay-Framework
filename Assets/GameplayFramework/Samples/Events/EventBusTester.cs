using UnityEngine;
using GameplayFramework.Core.Events;
using GameplayFramework.Core.Logging;

namespace GameplayFramework.Samples.Events
{
    public class EventBusTester : MonoBehaviour
    {
        private void OnEnable()
        {
            EventBus.Subscribe<PlayerDiedEvent>(OnPlayerDied);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<PlayerDiedEvent>(OnPlayerDied);
        }

        private void Start()
        {
            EventBus.Publish(new PlayerDiedEvent(1));
        }

        private void OnPlayerDied(PlayerDiedEvent e)
        {
            FrameworkLogger.Info($"Player {e.PlayerId} died.");
        }
    }
}
