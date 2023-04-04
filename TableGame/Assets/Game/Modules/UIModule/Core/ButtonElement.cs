using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TableGame.Modules.UIModule.Core
{
	[RequireComponent(typeof(Button))]
	public class ButtonElement : MonoBehaviour
	{
		[Inject] private SignalBus signalBus;
		
		private int selectedInstance;
		private bool isAvailable = true;
        
		public Button Button { get; private set; }
        
		private void Awake()
		{
			Button = GetComponent<Button>();

			SetActive(selectedInstance,false);
            
			signalBus.Subscribe<BoolSignal>(__b => isAvailable = __b.Value);
		}
        
		public void SetActive(int __instanceId, bool __active, Action __onClick = null)
		{
			if (__active)
			{
				gameObject.SetActive(__active);
				selectedInstance = __instanceId;

				Button.onClick.RemoveAllListeners();
				Button.onClick.AddListener(() => {
					if (!isAvailable) return;
                    
					__onClick?.Invoke();
					__onClick?.Invoke();
				});
			}
			else if (selectedInstance == __instanceId)
			{
				gameObject.SetActive(__active);
				isAvailable = true;
			}
		}
	}
}
