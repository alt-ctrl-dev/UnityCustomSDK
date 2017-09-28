using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyoBehaviour : MonoBehaviour {

	public Text outputText;
	public Text sliderText;
	public Slider mainSlider;

	// Use this for initialization
	void Start () {
		//Adds a listener to the main slider and invokes a method when the value changes.
		mainSlider.onValueChanged.AddListener(delegate {slider_OnChanged(); });
		slider_OnChanged ();
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	class DateCallback : AndroidJavaProxy
	{
		public DateCallback() : base("com.reuben.unityplugin.OnDateSetListener") {}
		void CallFunc()
		{
			Debug.Log ("onCallFunc");
		}
	}

	public void Btn_Clicked(bool isStatic){
		if (Application.platform == RuntimePlatform.Android) {
			using (var androidPlugin = new AndroidJavaClass ("com.reuben.unityplugin.AndroidPluin")) {
				if (isStatic) {
					var opS = androidPlugin.CallStatic<string> ("getTextFromPluginStatic", (int)mainSlider.value);
					Debug.Log ("Static output = "+opS);
					outputText.text = opS;
				} else {
					
					AndroidJavaObject jo = new AndroidJavaObject ("com.reuben.unityplugin.AndroidPluin", new DateCallback());

					var opJNI = jo.Call<string> ("getTextFromPlugin", (int)mainSlider.value);
					Debug.Log ("JNI output = " + opJNI);
					outputText.text = opJNI;

					jo.Call("getMessageCallback");
				}
			}
		} else
			outputText.text = "Not on android. " +(isStatic?"It's static":"Not static");
	}
		
	private void slider_OnChanged(){
		sliderText.text = mainSlider.value.ToString();
	}
}