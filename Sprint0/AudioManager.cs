using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace Sprint0
{
    public class AudioManager
    {
        private static AudioManager Instance;

        private readonly List<SoundEffectInstance> PlayingAudio;
        private bool IsMuted;

        private AudioManager() 
        {
            PlayingAudio = new List<SoundEffectInstance>();
            IsMuted = true;
        }

        // Pauses literally all other activity on the thread and plays only the sound effect [audio]
        // This is very niche functionality; it's used for picking up items such as the bow
        public void PlaySelfishSound(SoundEffect audio) 
        {
            // Pause all current audio
            foreach (var audioPlaying in PlayingAudio)
            {
                if (audioPlaying.State == SoundState.Playing) audioPlaying.Pause();
            }

            // Play the sound effect
            SoundEffectInstance instance = audio.CreateInstance();
            if (IsMuted) instance.Volume = 0;
            instance.Play();

            // Wait until the sound effect has completed
            while (instance.State != SoundState.Stopped) ;
            instance.Dispose();

            // Resume all other audio that was playing before
            foreach (var audioPlaying in PlayingAudio)
            {
                if (audioPlaying.State == SoundState.Paused) audioPlaying.Resume();
            }
        }

        public void PlayOnce(SoundEffect audio) 
        {
            SoundEffectInstance instance = audio.CreateInstance();
            instance.IsLooped = false;
            if (IsMuted) instance.Volume = 0;
            PlayingAudio.Add(instance);
            instance.Play();
        }

        public void PlayLooped(SoundEffect audio)
        {
            SoundEffectInstance instance = audio.CreateInstance();
            instance.IsLooped = true;
            if (IsMuted) instance.Volume = 0;
            PlayingAudio.Add(instance);
            instance.Play();
        }

        public void StopAudio() 
        {
            foreach (var audio in PlayingAudio) 
            {
                audio.Stop(true);
                audio.Dispose();
            }
            PlayingAudio.Clear();
        }

        public void MuteAudio() 
        {
            IsMuted = true;
            foreach (var audio in PlayingAudio)
            {
                audio.Volume = 0;
            }
        }

        public void UnmuteAudio()
        {
            IsMuted = false;
            foreach (var audio in PlayingAudio)
            {
                audio.Volume = 1f;
            }
        }

        public static AudioManager GetInstance() 
        {
            Instance ??= new AudioManager();
            return Instance;
        }

        public void Update() 
        {
            for (int i = PlayingAudio.Count - 1; i >= 0; i--) 
            {
                if (!PlayingAudio[i].IsLooped && PlayingAudio[i].State == SoundState.Stopped)
                {
                    PlayingAudio[i].Dispose();
                    PlayingAudio.RemoveAt(i);
                }
            }
        }
    }
}
