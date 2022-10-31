using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace Sprint0
{
    public class AudioManager
    {
        private static AudioManager Instance;
        private List<SoundEffectInstance> LoopedAudio;

        private AudioManager() 
        {
            LoopedAudio = new List<SoundEffectInstance>();
        }

        public void PlayOnce(SoundEffect audio) 
        {
            SoundEffectInstance instance = audio.CreateInstance();
            instance.IsLooped = false;
            instance.Play();
        }

        public void PlayLooped(SoundEffect audio)
        {
            SoundEffectInstance instance = audio.CreateInstance();
            instance.IsLooped = true;
            instance.Play();
            LoopedAudio.Add(instance);
        }

        public void StopLoopedAudio() 
        {
            foreach (var audio in LoopedAudio) 
            {
                audio.Stop(true);
                audio.Dispose();
            }
        }

        public static AudioManager GetInstance() 
        {
            Instance ??= new AudioManager();
            return Instance;
        }
    }
}
