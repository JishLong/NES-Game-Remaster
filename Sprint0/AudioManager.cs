using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace Sprint0
{
    public class AudioManager
    {
        private static AudioManager Instance;
        private List<SoundEffectInstance> SoundEffects;

        private AudioManager() 
        {
            SoundEffects = new List<SoundEffectInstance>();
        }

        public void PlaySound(SoundEffect sound) 
        {
            SoundEffectInstance instance = sound.CreateInstance();
            instance.IsLooped = false;
            instance.Play();
            SoundEffects.Add(instance);
        }

        public void PlayMusic(SoundEffect music)
        {
            SoundEffectInstance instance = music.CreateInstance();
            instance.IsLooped = true;
            instance.Play();
            SoundEffects.Add(instance);
        }

        public void StopAllSound() 
        {
            foreach (var sound in SoundEffects) 
            {
                sound.Stop(true);
                sound.Dispose();
            }
        }

        public static AudioManager GetInstance() 
        {
            Instance ??= new AudioManager();
            return Instance;
        }
    }
}
