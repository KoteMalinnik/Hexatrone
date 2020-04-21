using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleRotationScript : MonoBehaviour
{
	RectTransform rect;
	public float deltaAngle;

	void Awake()
	{
		rect = GetComponent<RectTransform>();
	}

	float angle;

    void Update()
	{
		rect.Rotate(0,0, -deltaAngle, Space.Self);
	}
}
