using System;

namespace Model
{
    public class SpeedModel //На будущее для персонажей
    {
        public SpeedModel(float speed)
        {
            if (speed < 0.0f)
                throw new ArgumentOutOfRangeException();
            Speed = speed;
        }
        
        public float Speed { get; private set;}
    }
}