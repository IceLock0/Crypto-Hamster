using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Music", menuName = "Shop/Music", order = 0)]
    public class MusicItem : ShopItem
    {
        [SerializeField] private AudioClip _music;

        public AudioClip Music => _music;
    }
}