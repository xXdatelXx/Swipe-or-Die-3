using System.Collections.Generic;

namespace Source.Model.Timer
{
    public class GamePause : IPause
    {
        private List<IPauseView> _views = new();

        public void Add(IPauseView view)
        {
            _views.Add(view);
        }

        public void Pause()
        {
            _views.ForEach(i => i.View());
        }
    }
}