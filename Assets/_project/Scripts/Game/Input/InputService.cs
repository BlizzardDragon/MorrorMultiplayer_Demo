using System;
using UnityEngine;
using VampireSquid.Common.CompositeRoot;

namespace _project.Scripts.Game.Input
{
    public interface IInputService
    {
        float HorizontalAxisRaw { get; }
        float VerticalAxisRaw { get; }

        event Action SpaceDown;
    }

    public class InputService : IInputService, IUpdateLoop
    {
        public float HorizontalAxisRaw { get; private set; }
        public float VerticalAxisRaw { get; private set; }
        
        public event Action SpaceDown;

        public void OnUpdate(float deltaTime)
        {
            HorizontalAxisRaw = UnityEngine.Input.GetAxisRaw("Horizontal");
            VerticalAxisRaw = UnityEngine.Input.GetAxisRaw("Vertical");
            
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                SpaceDown?.Invoke();
            }
        }
    }
}