using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    float oldLat = 0;
    float oldLong = 0;
    float totalDistance = 0f;
    float earthRadius = 6371000f;
    bool setup = true;
    public GUIStyle style;
    bool show = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Move();

        if(setup)
        {
            Input.location.Start();
            oldLong = Input.location.lastData.longitude;
            oldLat = Input.location.lastData.latitude;
            setup = false;
        }
        float newLong = Input.location.lastData.longitude;
        float newLat = Input.location.lastData.latitude;


        float deltaLong = newLong - oldLong;
        float deltaLat = newLat - oldLat;
        float temp = Mathf.Pow(Mathf.Sin(Mathf.Deg2Rad * deltaLat / 2), 2)
            + Mathf.Cos(Mathf.Deg2Rad * oldLat) * Mathf.Cos(Mathf.Deg2Rad * newLat)
            * Mathf.Pow(Mathf.Sin(Mathf.Deg2Rad * deltaLong / 2), 2);
        temp = 2 * Mathf.Atan2(Mathf.Sqrt(temp), Mathf.Sqrt(1 - temp));
        temp *= earthRadius;
        if (!float.IsNaN(temp))
        {
            totalDistance += Mathf.Abs(temp);
        }
        oldLong = newLong;
        oldLat = newLat;
	}
    public float TotalDistance {
        get
        {
            return totalDistance;
        }
    }

    void Move()
    {
        
        //Input.gyro.
        Input.gyro.enabled = true;

        Vector3 toRotate = -Input.gyro.rotationRate;
        toRotate.z = 0;

        transform.Rotate(toRotate);
    }

    void OnGUI()
    {
        
        

        if (show)
        {
            GUI.Box(new Rect(10, 10, Screen.width - 20, Screen.height - 20), "latitude: " + Input.location.lastData.latitude +
            "\n" + "longitude: " + Input.location.lastData.longitude +
            "\n" + "Total Distance: " + totalDistance, style);
            if ((GUI.Button(new Rect(Screen.width - 160, 240, 160, 40), "Hide")))
            {
                show = false;
            }
            if ((GUI.Button(new Rect(0, 240, 160, 40), "Add Distance")))
            {
                totalDistance += 10;
            }
        }
        else
        {
            if ((GUI.Button(new Rect(Screen.width - 160, 240, 160, 40), "Show")))
            {
                show = true;
            }
        }
       /* if (GUI.Button(new Rect(Screen.width - 160, 140, 160, 40), "Stop Tracking"))
        {
            Input.location.Stop();
        }
        if (GUI.Button(new Rect(Screen.width - 160, 240, 160, 40), "Start Tracking"))
        {
            Input.location.Start();
            oldLong = Input.location.lastData.longitude;
            oldLat = Input.location.lastData.latitude;
            started = true;
        }*/
    }
}
