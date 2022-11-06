using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace Sprint0
{
    public class AudioManager
    {
        private static AudioManager Instance;
        private readonly List<SoundEffectInstance> LoopedAudio;
        private bool IsMuted;

        private AudioManager() 
        {
            LoopedAudio = new List<SoundEffectInstance>();
            IsMuted = false;
        }

        public void PlayOnce(SoundEffect audio) 
        {
            if (!IsMuted) 
            {
                SoundEffectInstance instance = audio.CreateInstance();
                instance.IsLooped = false;
                instance.Play();
            }           
        }

        public void PlayLooped(SoundEffect audio)
        {
            SoundEffectInstance instance = audio.CreateInstance();
            instance.IsLooped = true;
            if (!IsMuted) 
            {
                instance.Play();
            }
            LoopedAudio.Add(instance);
        }

        public void StopLoopedAudio() 
        {
            foreach (var audio in LoopedAudio) 
            {
                audio.Stop(true);
                audio.Dispose();
            }
            LoopedAudio.Clear();
        }

        public void MuteAudio() 
        {
            IsMuted = true;
            foreach (var audio in LoopedAudio)
            {
                audio.Stop(true);
            }
        }

        public void UnmuteAudio()
        {
            IsMuted = false;
            foreach (var audio in LoopedAudio)
            {
                audio.Play();
            }
        }

        public static AudioManager GetInstance() 
        {
            Instance ??= new AudioManager();
            return Instance;
        }
    }
}
