using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public int WaveNumber;
    public float WaveCountdown;
    public float WaveTimer;
    public bool WaveRunning;

    // Start is called before the first frame update
    void Start()
    {
        WaveNumber = 0;
        StartCoroutine(Wave());
    }

    public IEnumerator Wave()
    {
        yield return new WaitForSeconds(WaveCountdown);
        WaveRunning = true;
        WaveNumber++;
        WaveTimer = 20.0f + 5.0f * (float)WaveNumber;
        yield return new WaitForSeconds(WaveTimer);
        Debug.Log("yeah " + Time.time);
        Invoke("WavesPaused", 0);
        WaveRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
