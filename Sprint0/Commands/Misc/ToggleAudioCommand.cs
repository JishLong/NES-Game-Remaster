namespace Sprint0.Commands.Misc
{
    public class ToggleAudioCommand : ICommand
    {
        private static bool IsMuted = false;

        public void Execute()
        {
            IsMuted = !IsMuted;
            if (IsMuted) AudioManager.GetInstance().MuteAudio();
            else AudioManager.GetInstance().UnmuteAudio();
        }
    }
}
