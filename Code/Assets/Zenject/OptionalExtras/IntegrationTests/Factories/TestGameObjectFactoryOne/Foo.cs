using UnityEngine;
using Zenject;

namespace Zenject.Tests.Factories.GameObjectFactoryOne
{
    public class Foo : MonoBehaviour
    {
        [Inject]
        public void Init(string value)
        {
            Value = value;
        }

        public string Value
        {
            get;
            private set;
        }
    }
}
