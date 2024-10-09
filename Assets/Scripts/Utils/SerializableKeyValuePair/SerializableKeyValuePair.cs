using System;

namespace Utils.SerializableKeyValuePair
{
    [Serializable]
    public struct SerializableKeyValuePair<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
    }
}