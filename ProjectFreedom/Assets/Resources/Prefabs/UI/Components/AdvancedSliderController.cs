#region File Header
// File Name:		AdvancedSliderController.cs
// Author:			John Whitsell
// Creation Date:	
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

public class AdvancedSliderController : MonoBehaviour
{
	#region UI Game Objects
	public GameObject goNameLabel = null;
	
	public GameObject goSlider = null;
	
	public GameObject goValueLabel = null;
	#endregion
	
	#region UI Components
	private Text cNameLabel = null;
	
	private Slider cSlider = null;
	
	private Text cValueLabel = null;
	#endregion
	
	#region Dirty Flags
	private Boolean nameTextChanged = false;
	
	private Boolean valueChanged = false;
	#endregion
	
	#region Events
	public delegate void SingleDelegate( Single value );
	
	public SingleDelegate OnValueChange;
	#endregion
	
	private String nameText = "";
	
	private Single value = 1f;
	
	#region Accessors/Mutators
	
	//	This variable is not initialized from the UI until after Start()
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
	
	void Update()
	{
		CommitProperties();
	}
	
	#endregion
	
	public void OnSliderChange( Slider slider )
	{
		if ( slider != null )
		{
			Value = slider.value;
		}
	}
	
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