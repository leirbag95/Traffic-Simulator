using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class RadialSlider: MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{
	[Header("OBJECTS")]
	public Image sliderImage;
	public Transform indicatorPivot;
	public Text valueText;
	public Slider baseSlider;

	[Header("SETTINGS")]
	public int sliderID = 0;
	public float maxValue = 100;
	public float currentValue = 0;
	public bool isPercent;
	public bool saveValue;

	bool isPointerDown = false;
	float indicatorRotationZ;
	float angle;

	void Start ()
	{
		if (saveValue == true)
		{
			currentValue = PlayerPrefs.GetFloat (sliderID + "RadialValue");
		}
			
		valueText.text = currentValue.ToString();

		if (isPercent == true)
		{
			valueText.text = valueText.text + "%";
		}

		baseSlider.value = currentValue / maxValue;
		sliderImage.fillAmount = currentValue / maxValue;
		indicatorRotationZ = sliderImage.fillAmount * 360;
		indicatorPivot.transform.localEulerAngles = new Vector3 (180, 0, indicatorRotationZ);
	}

	public void OnPointerEnter( PointerEventData eventData )
	{
		StartCoroutine( "TrackPointer" );            
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		isPointerDown= true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		isPointerDown= false;
	}
		
	IEnumerator TrackPointer()
	{
		var ray = GetComponentInParent<GraphicRaycaster>();
		var input = FindObjectOfType<StandaloneInputModule>();
		
		if (ray != null && input != null) 
		{
			while (Application.isPlaying) 
			{                    
				if (isPointerDown) 
				{
					Vector2 localPos;
					RectTransformUtility.ScreenPointToLocalPointInRectangle (transform as RectTransform, Input.mousePosition, ray.eventCamera, out localPos);
						
					angle = (Mathf.Atan2 (-localPos.y, localPos.x) * 180f / Mathf.PI + 180f) / 360f;
					sliderImage.fillAmount = angle;

					indicatorRotationZ = sliderImage.fillAmount * 360;
					indicatorPivot.transform.localEulerAngles = new Vector3 (180, 0, indicatorRotationZ);

					currentValue = Mathf.Round(sliderImage.fillAmount * maxValue) / 1f;
					baseSlider.value = currentValue / maxValue;

					if (isPercent == true)
					{
						valueText.text = ((int)(angle * maxValue) + "%").ToString ();
					} 

					else 
					{
						valueText.text = ((int)(angle * maxValue)).ToString ();
					}

					if (saveValue == true)
					{
						PlayerPrefs.SetFloat (sliderID + "RadialValue", currentValue);
					}
				}
				yield return 0;
			}        
		} 

		else 
		{
			UnityEngine.Debug.LogWarning("Could not find GraphicRaycaster or StandaloneInputModule");    
		}	    
	}
}
