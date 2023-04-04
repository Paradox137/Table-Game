using TableGame.Modules.InputModule.Signals;
using TableGame.Modules.ItemModule.Core;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Zenject;

namespace TableGame.Modules.InputModule.Core
{
	public class InputService : IInitializable
	{
		private readonly PlayerInput input;

		private readonly SignalBus bus;

		private readonly Camera camera;

		private ReactiveProperty<IIdentifier> selectedIdentifier;

		private bool pointerOverUI;

		public InputService(Camera __camera, PlayerInput __input, SignalBus __bus)
		{
			input = __input;
			bus = __bus;
			camera = __camera;
		}

		public void Initialize()
		{
			input.Enable();
			input.Player.Select.performed += TrySelect;

			selectedIdentifier = new ReactiveProperty<IIdentifier>(null);

			selectedIdentifier.
				ObserveEveryValueChanged(__e => __e.Value).
				Subscribe(__id => bus.TryFire(new SelectSignal(__id))).
				AddTo(camera);

			StartUpdate();
		}
		
		private void StartUpdate()
		{
			Observable.EveryUpdate()
				.Subscribe(_ =>
				{
					pointerOverUI = EventSystem.current.IsPointerOverGameObject();
                    
					if (selectedIdentifier.Value == null) return;
                    
					Vector2 inputRealTime = input.Player.Move.ReadValue<Vector2>();
					bus.TryFire(new MoveSignal(selectedIdentifier.Value.InstanceId, inputRealTime));
				})
				.AddTo(camera);
		}
		
		private void TrySelect(InputAction.CallbackContext __callback)
		{
			var ray = camera.ScreenPointToRay(
				input.Player.Cursor.ReadValue<Vector2>());

			if (pointerOverUI) return;

			IIdentifier selected = null;

			if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
			{
				hit.transform.TryGetComponent(out selected);
			}

			selectedIdentifier.Value = selected;
		}
	}
}
