using UnityEngine;
using CustomScreen.Core;
using UnityEngine.UI;
using System;

namespace CustomScreen
{
    public class SettingsScreen : BaseScreen
    {
		#region Events
		public static event Action<bool> OnMusicToggleChanged = null;
		public static event Action<bool> OnSoundToggleChanged = null;
        #endregion

        #region Fields
        [Header("Кнопки")]
		[SerializeField] Button button_Music = null;
		[SerializeField] Button button_Sound = null;

		[Header("Цвета вкл/выкл")]
		[SerializeField] Color c_allowAudio = Color.blue;
		[SerializeField] Color c_disallowAudio = Color.red;

		bool state_Sound = true;
		bool state_Music = true;
        #endregion

        #region MonoBehaviour Callbacks
        private void OnEnable()
        {
			Log.Message("Загрузка и выставление значений.");
			button_Music.interactable = true;
			button_Sound.interactable = true;

			state_Music = Serialization.Load(SerializationKeys.MusicState, true);
			state_Sound = Serialization.Load(SerializationKeys.SoundState, true);

			SetupButtonColor(button_Music, state_Music);
			SetupButtonColor(button_Sound, state_Sound);
		}
        #endregion

        #region Screens Open Methods
        public void OpenMainMenuScreen()
		{
			Log.Message("Нажатие на кнопку <Back>.");
			ScreenManager.OpenScreen(ScreenType.MainMenuScreen);
		}
		#endregion

		/// <summary>
		/// Переключить звук.
		/// </summary>
		public void ToggleSound()
		{
			Log.Message("Переключение звука.");

			state_Sound = ToggleAudio(SerializationKeys.SoundState, button_Sound, state_Sound);
			OnSoundToggleChanged?.Invoke(state_Sound);
        }

        /// <summary>
        /// Переключить музыку.
        /// </summary>
        public void ToggleMusic()
		{
			Log.Message("Переключение музыки.");

			state_Music = ToggleAudio(SerializationKeys.MusicState, button_Music, state_Music);
			OnMusicToggleChanged?.Invoke(state_Music);
		}

		bool ToggleAudio(SerializationKeys key, Button button, bool state)
        {
			state = !state;
			SetupButtonColor(button, state);
			Serialization.Save(key, state);

			return state;
		}

		void SetupButtonColor(Button button, bool state)
		{
			button.GetComponent<Image>().color = state ? c_allowAudio : c_disallowAudio;
		}
	}
}