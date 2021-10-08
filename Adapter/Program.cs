using System;
using System.Collections.Generic;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var music = new List<IAudioFile>
            {
                new Mp3(),
                new Mp3(),
                new Wav(),
                new Flac(),
                new Mp3(),
                new OggMp3ObjectAdapter(),
                new OggMp3ClassAdapter()
            };

            foreach (var item in music) item.Play();
        }
    }

    public interface IAudioFile
    {
        void Play();
    }

    class Mp3 : IAudioFile
    {
        public void Play()
        {
            Console.WriteLine("Mp3 is playing");
        }
    }
    class Wav : IAudioFile
    {
        public void Play()
        {
            Console.WriteLine("WAV is playing");
        }
    }
    class Flac : IAudioFile
    {
        public void Play()
        {
            Console.WriteLine("FLAC is playing");
        }
    }

    // Nuget
    class OGG
    {
        public void PlaySomethingInteresting(bool repeat)
        {
            Console.WriteLine("smth");
            Console.WriteLine("smth");
        }
    }

    // Class adapter
    class OggMp3ClassAdapter : OGG, IAudioFile
    {
        public void Play()
        {
            this.PlaySomethingInteresting(false);
        }
    }

    // Object adapter
    class OggMp3ObjectAdapter:IAudioFile
    {
        public OGG Ogg { get; set; } = new OGG();
        public void Play()
        {
            Ogg.PlaySomethingInteresting(false);
        }
    }
}
