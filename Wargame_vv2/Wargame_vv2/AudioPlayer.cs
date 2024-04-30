using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Wargame_vv2
{
    public class AudioPlayer
    {
        private static SoundPlayer backSong;
        private static SoundPlayer suono;
        private static bool mute = false;

        public static void CaricaAudioInLoop(string audio)
        {
            if (backSong != null)
            {
                backSong.Stop();
                backSong.Dispose();
            }

            backSong = new SoundPlayer(audio);
            backSong.Load();
            backSong.PlayLooping();
        }

        public static void CaricaAudio(string audio)
        {
            if (suono != null)
            {
                suono.Stop();
                suono.Dispose();
            }

            suono = new SoundPlayer(audio);
            suono.Load();
        }

        public static void PlayAudio()
        {
            if (suono != null && mute != true)
            {
                suono.Play();
            }
        }

        public static void StopAudio()
        {
            if (suono != null)
            {
                suono.Stop();
            }
        }

        public static void Mute()
        {
            if (mute != true)
                mute = true;
            else
                mute = false;
        }
    }
}
