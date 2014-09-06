#region File Header
// File Name:		AdvancedSliderController.cs
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
#endregion

namespace LunarGrin.UI
{
	/// <summary>
	/// The Advanced slider controller manages the various UI components that make up the advanced slider.
	/// </summary>
	public class AdvancedSliderController : MonoBehaviour
	{
		#region UI Game Objects
		/// <summary>
		/// The UI name label game object.
		/// </summary>
		public GameObject goNameLabel = null;
		
		/// <summary>
		/// The UI slider game object.
		/// </summary>
		public GameObject goSlider = null;
		
		/// <summary>
		/// The UI value label game object.
		/// </summary>
		public GameObject goValueLabel = null;
		#endregion
		
		#region UI Components
		/// <summary>
		/// The UI name label component.
		/// </summary>
		private Text cNameLabel = null;
		
		/// <summary>
		/// The UI slider component.
		/// </summary>
		private Slider cSlider = null;
		
		/// <summary>
		/// The value label component.
		/// </summary>
		private Text cValueLabel = null;
		#endregion
		
		#region Dirty Flags
		/// <summary>
		/// A flag that is used to determine when a value has been submitted for the name label and needs to be committed to the UI.
		/// </summary>
		private Boolean nameTextChanged = false;
		
		/// <summary>
		/// A flag that is used to determine when a value has been submitted for the slider value and needs to be committed to the UI.
		/// </summary>
		private Boolean valueChanged = false;
		#endregion
		
		#region Events
		public delegate void SingleDelegate( Single value );
		
		/// <summary>
		/// A delegate that makes a callback when the value of the slider has changed.
		/// </summary>
		public SingleDelegate OnValueChange;
		#endregion
		
		/// <summary>
		/// Name text caches the changed name value so that it can be committed to the UI on the next update.
		/// </summary>
		private String nameText = "";
		
		/// <summary>
		/// Value caches the slider's changed value so that it can be committed to the UI on the next update.
		/// </summary>
		private Single value = 1f;
		
		#region Accessors/Mutators
		
		/// <summary>
		/// Gets or sets the name text.  Note:  This variable is not initialized from the UI until after Start().
		/// </summary>
		/// <value>The name text.</value>
		public String NameText
		{
			get
			{
				return nameText;
			}
			set
			{
				if ( nameText.Equals( value ) == false )
				{
					nameText = value;
					nameTextChanged = true;
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the value.  If value is changing the OnValueChange delegate will be called.  Note:  This variable is not initialized from the UI until after Start().
		/// </summary>
		/// <value>The value.</value>
		public Single Value
		{
			get
			{
				return this.value;
			}
			set
			{
				if ( this.value != value )
				{
					this.value = value;
					valueChanged = true;
					
					CommitProperties();
					
					if ( OnValueChange != null )
					{
						OnValueChange( this.value );
					}
				}
			}
		}
		
		#endregion
		
		#region Unity Functions
		
		/// <summary>
		/// Handles Unity's start event by initializing UI's values.
		/// </summary>
		void Start()
		{
			if ( goNameLabel != null )
			{
				cNameLabel = goNameLabel.GetComponent<Text>();
				
				nameText = cNameLabel.text;
			}
			
			if ( goSlider != null )
			{
				cSlider = goSlider.GetComponent<Slider>();
			}
			
			if ( goValueLabel != null )
			{
				cValueLabel = goValueLabel.GetComponent<Text>();
			}
		}
		
		/// <summary>
		/// Handles Unity's update by committing and changed properties to the UI.
		/// </summary>
		void Update()
		{
			CommitProperties();
		}
		
		#endregion
		
		/// <summary>
		/// Handles the UI's slider change event by caching the current value.
		/// </summary>
		/// <param name="slider">Slider.</param>
		public void OnSliderChange( Slider slider )
		{
			if ( slider != null )
			{
				Value = slider.value;
			}
		}
		
		/// <summary>
		/// Commits all changed properties to the UI.
		/// </summary>
		private void CommitProperties()
		{
			if ( cNameLabel != null )
			{
				if ( nameTextChanged == true )
				{
					cNameLabel.text = nameText;
					nameTextChanged = false;
				}
			}
			
			if ( valueChanged == true )
			{
				if ( cSlider != null )
				{
					cSlider.value = Value;
				}
				
				if ( cValueLabel != null )
				{
					cValueLabel.text = ((Int32)(Value * 100)).ToString();
				}
			
				valueChanged = false;
			}
		}
	}
}