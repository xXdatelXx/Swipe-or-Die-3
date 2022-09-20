using Source.Model;

namespace SwipeOrDie.Data
{
    public class Color
    {
        private float _force;

        public Color(Speed force)
        {
            _force = force.Value;
        }

        public UnityEngine.Color Random()
        {
            return new UnityEngine.Color(UnityEngine.Random.Range(0, _force), UnityEngine.Random.Range(0, _force), UnityEngine.Random.Range(0, _force));
        }
    }
}