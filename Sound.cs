﻿using UnityEditor;
using UnityEngine;

namespace AudUnity
{
    [CanEditMultipleObjects]
    /// <summary>
    /// A scriptable object that stores a sound
    /// </summary>
    [CreateAssetMenu(fileName = "Sound", menuName = LocalAudioPlayer.menuCategory + "Sound", order = 0)]
    public class Sound : ScriptableObject
    {
        [Tooltip("The sound")]
        public SoundData sound;

        /// <summary>
        /// Set the name of the sound by the name of the scriptable objcet
        /// </summary>
        protected internal void NameByObject() => sound.soundName = name;

        /// <summary>
        /// Set the name of the sound by the name of the audio clip
        /// </summary>
        protected internal void NameByClip() => sound.soundName = sound.clip.name;

        /// <summary>
        /// Default constructor for Unity's Reset function
        /// </summary>
        public Sound()
        {
            sound = new SoundData("Unamed sound");
        }

        private void OnValidate()
        {
            SoundEditor.ReplayIfIsPlaying(this);
        }
    }
}
