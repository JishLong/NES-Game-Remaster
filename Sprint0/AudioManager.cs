using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace Sprint0
{
    public class AudioManager
    {
        private static AudioManager Instance;
        private readonly List<SoundEffectInstance> PlayingAudio;
        private readonly List<SoundEffectInstance> ToBeRemoved;
        private bool IsMuted;

        private AudioManager() 
        {
            PlayingAudio = new List<SoundEffectInstance>();
            ToBeRemoved = new List<SoundEffectInstance>();
            IsMuted = true;
        }

        public void PlaySelfishSound(SoundEffect audio) 
        {
            foreach (var audioPlaying in PlayingAudio)
            {
                if (audioPlaying.State == SoundState.Playing) audioPlaying.Pause();
            }
            SoundEffectInstance instance = audio.CreateInstance();
            if (IsMuted) instance.Volume = 0;
            instance.Play();
            while (instance.State != SoundState.Stopped) ;
            instance.Dispose();
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
            foreach (var audio in PlayingAudio)
            {
                if (!audio.IsLooped && audio.State == SoundState.Stopped) 
                {
                    audio.Dispose();
                    ToBeRemoved.Add(audio);
                }
            }
            foreach (var audio in ToBeRemoved)
            {
                PlayingAudio.Remove(audio);
            }
            ToBeRemoved.Clear();
        }
    }
}
