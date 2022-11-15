using System.Collections.Generic;

namespace Source.Model.Timer
{
    public sealed class GamePause : IPause
    {
        private readonly List<IPauseHandler> _handlers = new();

        public void Add(IPauseHandler handler) => 
            _handlers.Add(handler);

        public void Pause() => 
            _handlers.ForEach(i => i.Disable());

        public void Play() => 
            _handlers.ForEach(i => i.Enable());
    }
}