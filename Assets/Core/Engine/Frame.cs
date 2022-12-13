using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Assets.Core.Engine
{
    public class Frame
    {
        public Input input
        {
            get
            {
                return _input;
            }
            set
            {
                _input = value;
            }
        }
        public ReadOnlyCollection<GameObject> objects => _objects.AsReadOnly();
        public bool isDirty { get; private set; }

        private Input _input;
        private readonly List<GameObject> _objects;
    }
}
