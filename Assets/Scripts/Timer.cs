using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _duration;

    public float Duration 
    { 
        get { return _duration; }
        set
        {
            if (Running)
                return;

            if (value > 0)
                _duration = value;
            else
                _duration = 0;
        } 
    }
    [field: SerializeField] public float ElapsedTime { get; private set; }
    [field: SerializeField] public bool Running { get; private set; }
    public bool Finished { get { return ElapsedTime >= Duration; } }

    private void Awake()
    {
        Stop();
    }

    private void Update()
    {
        if (!Running)
            return;

        ElapsedTime += Time.deltaTime;
        if (Finished)
            Running = false;
    }

    public void Run() => Running = true;

    public void Pause() => Running = false;

    public void Stop()
    {
        ElapsedTime = 0;
        Running = false;
    }

    public void Restart()
    {
        Stop();
        Run();
    }
}