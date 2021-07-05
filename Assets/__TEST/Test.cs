using UnityEngine;

public class Test: MonoBehaviour
{
    private void Awake()
    {
        Log.Message("Awake");
    }

    private void OnEnable()
    {
        Log.Message("OnEnable");
    }
	
    private void Start()
    {
        Log.Message("Start");
    }

    private void Update()
    {
        //Log.Message("Update");
    }

    private void FixedUpdate()
    {
        //Log.Message("FixedUpdate");
    }

    private void OnDisable()
    {
        Log.Message("OnDisable");
    }

    private void OnDestroy()
    {
        Log.Message("OnDestroy");
    }
}
