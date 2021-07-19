using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Sfx
{
	interface IAudioManager : IAddable<AudioSource>
    {
		void Stop();
		void Play();
    }


	class AudioManager : IAudioManager
	{
		// === Fields ===

		private readonly List<AudioSource> _chanels = new List<AudioSource>();

		public bool Add(AudioSource source)
        {
			if (_chanels.Contains(source))
				return false;

			_chanels.Add(source);
			return true;
		}

		public void Stop() => _chanels.ForEach((source) => source.Stop());
		public void Play() => _chanels.Find((source) => source.isPlaying is false)?.Play();
	}
}
