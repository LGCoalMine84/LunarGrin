#region File Header
// File Name:		SoundOptions.cs
// Author:			John Whitsell
// Creation Date:	2014/09/06
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.
#endregion

#region Using Directives
using UnityEngine;
using System;
using UnityEngine.UI;
using LunarGrin.Core;
#endregion

namespace LunarGrin.UI
{
	/// <summary>
	/// The Sound options controller manages the various components on the sound options panel in the game.  It handles the initialization of the panel's components as well as commits or reverts any changes that were made to the sound options when save or cancel are clicked.
	/// </summary>
	public class SoundOptionsController : MonoBehaviour
	{
		#region UI Components
		/// <summary>
		/// The effects UI controller.
		/// </summary>
		public AdvancedSliderController effectsController = null;
		
		/// <summary>
		/// The music UI controller.
		/// </summary>
		public AdvancedSliderController musicController = null;
		
		/// <summary>
		/// The speech UI controller.
		/// </summary>
		public AdvancedSliderController speechController = null;
		#endregion
		
		#region Unity Functions
		
		/// <summary>
		/// Handles Unity's disable event by removing child component listeners.
		/// </summary>
		void OnDisable()
		{
			RemoveListeners();
		}
		
		/// <summary>
		/// Handles Unity's enable event by initializing the UI with the latest game state and attaching listeners to managed children.
		/// </summary>
		void OnEnable()
		{
			InitializeUI();
		}
		
		#endregion
		
		#region Event Handlers
		
		/// <summary>
		/// Handles the UI's effect volume change event by setting the game config's effect volume.
		/// </summary>
		/// <param name="value">The value of the UI's current effect volume.</param>
		private void OnEffectVolumeChange( Single value )
		{
			GameServices.ConfigManager.Sound.SetEffectVolume( value );
		}
		
		/// <summary>
		/// Handles the UI's music volume change event by setting the game config's music volume.
		/// </summary>
		/// <param name="value">The value of the UI's current effect volume.</param>
		private void OnMusicVolumeChange( Single value )
		{
			GameServices.ConfigManager.Sound.SetMusicVolume( value );
		}
		
		/// <summary>
		/// Handles the UI's speech volume change event by setting the game config's speech volume.
		/// </summary>
		/// <param name="value">The value of the UI's current speech volume.</param>
		private void OnSpeechVolumeChange( Single value )
		{
			GameServices.ConfigManager.Sound.SetSpeechVolume( value );
		}
		
		#endregion
		
		/// <summary>
		/// Handles the UI's save button click event by saving the current sound options to the game config.
		/// </summary>
		public void OnSaveClick()
		{
			GameServices.ConfigManager.Sound.Save();
			
			gameObject.SetActive( false );
		}
		
		/// <summary>
		/// Handles the UI's cancel button click event by reverting the changes made in the sound options to the last saved game config state.
		/// </summary>
		public void OnCancelClick()
		{
			GameServices.ConfigManager.Sound.Revert();
			
			gameObject.SetActive( false );
		}
		
		/// <summary>
		/// Initializes the UI components with the latest game config state and attaches listeners to their change events.
		/// </summary>
		private void InitializeUI()
		{
			if ( effectsController != null )
			{
				effectsController.Value = GameServices.ConfigManager.Sound.EffectVolume;
				effectsController.OnValueChange += OnEffectVolumeChange;
			}
			
			if ( musicController != null )
			{
				musicController.Value = GameServices.ConfigManager.Sound.MusicVolume;
				musicController.OnValueChange += OnMusicVolumeChange;
			}
			
			if ( speechController != null )
			{
				speechController.Value = GameServices.ConfigManager.Sound.SpeechVolume;
				musicController.OnValueChange += OnSpeechVolumeChange;
			}
		}
		
		/// <summary>
		/// Removes listeners attached to the UI components managed by this controller.
		/// </summary>
		private void RemoveListeners()
		{
			if ( effectsController != null )
			{
				effectsController.OnValueChange -= OnEffectVolumeChange;
			}
			
			if ( musicController != null )
			{
				musicController.OnValueChange -= OnMusicVolumeChange;
			}
			
			if ( speechController != null )
			{
				speechController.OnValueChange -= OnSpeechVolumeChange;
			}
		}
	}
}