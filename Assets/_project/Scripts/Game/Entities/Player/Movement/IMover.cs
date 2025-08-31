using UnityEngine;

namespace _project.Scripts.Game.Entities.Player.Movement
{
    public interface IMover
    {
        void Move(Vector2 direction, float deltaTime);
    }
}