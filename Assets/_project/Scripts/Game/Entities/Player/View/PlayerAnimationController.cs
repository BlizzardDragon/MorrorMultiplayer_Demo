using UnityEngine;
using VampireSquid.Common.CompositeRoot;

namespace _project.Scripts.Game.Entities.Player.View
{
    public class PlayerAnimationController : IUpdateLoop
    {
        private readonly int StateHash = Animator.StringToHash("State");

        private const int IdleIndex = 0;
        private const int RunIndex = 1;

        private readonly Animator _animator;
        private readonly Rigidbody _rigidbody;

        public PlayerAnimationController(Animator animator, Rigidbody rigidbody)
        {
            _animator = animator;
            _rigidbody = rigidbody;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_rigidbody.linearVelocity.magnitude < 0.1f)
            {
                _animator.SetInteger(StateHash, IdleIndex);
            }
            else
            {
                _animator.SetInteger(StateHash, RunIndex);
            }
        }
    }
}