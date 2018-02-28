using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyoBehaviour : MonoBehaviour
{

	public Text outputText;
	public Text myoButtonText;
	public Button myoButton;
	private bool isMyoConnected;

	// Use this for initialization
	void Start ()
	{
	}

	
	// Update is called once per frame
	void Update ()
	{
		
	}

	class DateCallback : AndroidJavaProxy
	{
		public DateCallback() : base("com.reuben.unityplugin.OnDateSetListener") {}
		void CallFunc()
		{
			Debug.Log ("onCallFunc");

		}
	}

	class MyoCallback : AndroidJavaProxy
	{
		Text sText;

		public MyoCallback () : base ("com.reuben.myo.DeviceListener")
		{
			
		}

		public void onAttach (AndroidJavaObject myo, long timestamp)
		{
			Debug.Log ("onAttach");
			this.sText.text = "onAttach";
		}

		public void onDetach (AndroidJavaObject myo, long timestamp)
		{
			Debug.Log ("onDetach");
			this.sText.text = "onDetach";
		}

		public void onConnect (AndroidJavaObject myo, long timestamp)
		{
			Debug.Log ("onConnect");
			this.sText.text = "onConnect";
			Debug.Log ("myo name = " + myo.Call<string> ("getName"));

		}

		public void onDisconnect (AndroidJavaObject myo, long timestamp)
		{
			Debug.Log ("onDisconnect");
			this.sText.text = "onDisconnect";
		}

		public void onArmSync (AndroidJavaObject myo, long timestamp, Arm arm, XDirection xDirection)
		{
			Debug.Log ("onArmSync");
			this.sText.text = "onArmSync";
		}

		public void onArmUnsync (AndroidJavaObject myo, long timestamp)
		{
			Debug.Log ("onArmUnsync");
			this.sText.text = "onArmUnsync";
		}

		public void onUnlock (AndroidJavaObject myo, long timestamp)
		{
			Debug.Log ("onUnlock");
			this.sText.text = "onUnlock";
		}

		public void onLock (AndroidJavaObject myo, long timestamp)
		{
			Debug.Log ("onLock");
			this.sText.text = "onLock";
		}

		public void onPose (AndroidJavaObject myo, long timestamp, Pose pose)
		{
			Debug.Log ("onPose");
			this.sText.text = "onPose";
		}

		public void onOrientationData (AndroidJavaObject myo, long timestamp, Quaternion rotation)
		{
			Debug.Log ("onOrientationData");
			this.sText.text = "onOrientationData";
		}

		public void onAccelerometerData (AndroidJavaObject myo, long timestamp, Vector3 accel)
		{
			Debug.Log ("onAccelerometerData");
			this.sText.text = "onAccelerometerData";
		}

		public void onGyroscopeData (AndroidJavaObject myo, long timestamp, Vector3 gyro)
		{
			Debug.Log ("onGyroscopeData");
			this.sText.text = "onGyroscopeData";
		}

		public void onRssi (AndroidJavaObject myo, long timestamp, int rssi)
		{
			Debug.Log ("onRssi");
			this.sText.text = "onRssi";
		}
	}

	public void myoConnectBtn_onClicked ()
	{
		if (Application.platform == RuntimePlatform.Android) {
			using (AndroidJavaClass javaUnityPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer")) {
				using (AndroidJavaObject context = javaUnityPlayer.GetStatic<AndroidJavaObject> ("currentActivity")) {
					using (AndroidJavaObject myoManager = new AndroidJavaObject ("com.reuben.myo.MyoManager", context)) {
						if (myoManager.Call<bool> ("launchMyoScreen", new MyoCallback ())) {
							outputText.text = "It worked";
						} else {
							outputText.text = "It failed";
						}
					}
				}
			}
		} else {
			outputText.text = "Not on android. ";

		}
	}
}

/*
 AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        var unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");

        // The Hub needs to be initialized on the Android UI thread.
        unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() => {
            createHub();
        }));
*/