using UnityEngine;
using UnityEngine.UI;

using CookingPrototype.Controllers;

using TMPro;
using System;

namespace CookingPrototype.UI {
	public sealed class StartWindow : MonoBehaviour {
		public TMP_Text GoalText = null;
		public Button PlayButton = null;
		public Button CloseButton = null;

		bool _isInit = false;

		void Start() {
			GameplayController.Instance.TotalOrdersServedChanged += OnOrdersQuantitySet;
		}

		private void OnOrdersQuantitySet() {

			var gc = GameplayController.Instance;

			GoalText.text = $"{gc.OrdersTarget}";
		}

		void Init() {
			var gc = GameplayController.Instance;

			PlayButton.onClick.AddListener(gc.StartGame);
			CloseButton.onClick.AddListener(gc.CloseGame);
		}

		public void Show() {
			if ( !_isInit ) {
				Init();
			}
			gameObject.SetActive(true);
		}

		public void Hide() {
			gameObject.SetActive(false);
		}
	}
}
