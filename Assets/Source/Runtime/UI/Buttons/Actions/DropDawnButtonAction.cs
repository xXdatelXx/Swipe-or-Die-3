using System.Collections.Generic;
using System.Linq;
using SwipeOrDie.Extension;

namespace SwipeOrDie.Ui
{
    public sealed class DropDawnButtonAction : IButtonAction
    {
        private readonly List<IButton> _objects;
        private bool _active;

        public DropDawnButtonAction(bool active = false, params IButton[] objects) : this(objects.ToList(), active)
        { }

        public DropDawnButtonAction(List<IButton> objects, bool active = false)
        {
            _objects = objects.ThrowExceptionIfArgumentNull(nameof(_objects));
            _active = active;
        }

        public void OnClick()
        {
            _objects.ForEach(i =>
            {
                if (_active) i.Disable();
                else i.Enable();
            }); 
            
            _active = !_active;
        }
    }
}