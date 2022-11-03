using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace Sprint0
{
    public class AudioManager_BACKUP
    {
        private static AudioManager_BACKUP Instance;
        private List<SoundEffectInstance> LoopedAudio;

        private AudioManager_BACKUP() 
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

        public static AudioManager_BACKUP GetInstance() 
        {
            Instance ??= new AudioManager_BACKUP();
            return Instance;
        }
    }
}
