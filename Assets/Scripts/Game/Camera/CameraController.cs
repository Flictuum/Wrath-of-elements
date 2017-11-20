using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Q))
		{
			transform.Translate(-10 * Time.deltaTime, 0, 0);
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			transform.Translate(10 * Time.deltaTime, 0, 0);
		}

		if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			if (Camera.main.fieldOfView <= 125)
				Camera.main.fieldOfView += 2;
			if (Camera.main.orthographicSize <= 19)
				Camera.main.orthographicSize += 0.5f;
		}

		if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			if (Camera.main.fieldOfView > 2)
				Camera.main.fieldOfView -= 2;
			if (Camera.main.orthographicSize >= 8)
				Camera.main.orthographicSize -= 0.5f;
		}
	}
}