using UnityEngine;

public class TestTimer : MonoBehaviour
{
    private Timer _timer;
    private float _startTime;

    private void Start()
    {
        _timer = gameObject.AddComponent<Timer>();
        _timer.Duration = 5.0f;
        _startTime = Time.time;
        _timer.Run();
    }

    private void Update()
    {
        if (!_timer.Finished)
            return;

        Debug.Log($"Timer ran for {Time.time - _startTime} seconds");
        _startTime = Time.time;
        _timer.Restart();
    }
}