using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


namespace Game.Managers
{
    public class MusicManager : MonoBehaviour
    {
        private AudioSource _audioSource;

        public List<AudioClip> clips;
        
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (!_audioSource.isPlaying)
            {
                var random = new Random();
                var index = random.Next(clips.Count);
                _audioSource.clip = clips[index];
                _audioSource.Play();
            }

            
        }
    }
}