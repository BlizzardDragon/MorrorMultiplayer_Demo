using Cysharp.Threading.Tasks;
using VampireSquid.Common.CompositeRoot;

namespace _project.Scripts.Game.Roots
{
    public class GameRoot : CompositeRootBase
    {
        public override async UniTask InstallBindings()
        {
            BindAsGlobal<IGameManager>(new GameManager());
        }
    }
}