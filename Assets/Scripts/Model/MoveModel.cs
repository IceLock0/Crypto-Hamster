using System;

namespace Model
{
    public class MoveModel //На будущее для персонажей
    {
        public MoveModel(float speed)
        {
            if (speed < 0.0f)
                throw new ArgumentOutOfRangeException();
            Speed = speed;
        }
        
        public float Speed { get; private set;}
    }
}