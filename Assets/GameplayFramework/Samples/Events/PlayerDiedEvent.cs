namespace GameplayFramework.Samples.Events
{
    public readonly struct PlayerDiedEvent
    {
        public readonly int PlayerId;

        public PlayerDiedEvent(int playerId)
        {
            PlayerId = playerId;
        }
    }
}
