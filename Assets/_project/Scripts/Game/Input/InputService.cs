using System;
using UnityEngine;
using VampireSquid.Common.CompositeRoot;

namespace _project.Scripts.Game.Input
{
    public interface IInputService
    {
        float HorizontalAxis { get; }
        float VerticalAxis { get; }

        event Action SpaceDown;
    }

    public class InputService : IInputService, IUpdateLoop
    {
        public float HorizontalAxis { get; private set; }
        public float VerticalAxis { get; private set; }
        
        public event Action SpaceDown;

        public void OnUpdate(float deltaTime)
        {
            HorizontalAxis = UnityEngine.Input.GetAxis("Horizontal");
            VerticalAxis = UnityEngine.Input.GetAxis("Vertical");
            
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                SpaceDown?.Invoke();
            }
        }
    }
}