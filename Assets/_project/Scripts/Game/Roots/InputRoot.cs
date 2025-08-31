using _project.Scripts.Game.Input;
using Cysharp.Threading.Tasks;
using VampireSquid.Common.CompositeRoot;

namespace _project.Scripts.Game.Roots
{
    public class InputRoot : CompositeRootBase, IUpdateLoop
    {
        private InputService _inputService;

        public override async UniTask InstallBindings()
        {
            _inputService = new InputService();
        
            BindAsGlobal<IInputService>(_inputService);
        }

        public void OnUpdate(float deltaTime)
        {
            _inputService.OnUpdate(deltaTime);
        }
    }
}