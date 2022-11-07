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
            IsMuted = false;
        }

        public void PlayOnce(SoundEffect audio) 
        {
            SoundEffectInstance instance = audio.CreateInstance();
            instance.IsLooped = false;
            if (!IsMuted) 
            {
                PlayingAudio.Add(instance);
                instance.Play();
            }        
        }

        public void PlayLooped(SoundEffect audio)
        {
            SoundEffectInstance instance = audio.CreateInstance();
            instance.IsLooped = true;
            PlayingAudio.Add(instance);
            if (!IsMuted) 
            {
                instance.Play();
            }
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
                audio.Pause();
            }
        }

        public void UnmuteAudio()
        {
            IsMuted = false;
            foreach (var audio in PlayingAudio)
            {
                audio.Play();
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
