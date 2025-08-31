using UnityEngine;

namespace _project.Scripts.Game.Entities.Player.Movement
{
    public interface IRotateToDirection
    {
        void Rotate(Vector2 direction);
    }
}