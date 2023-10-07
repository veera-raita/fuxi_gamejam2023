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
        WaveNumber = 1;
        StartCoroutine(Wave());
    }

    IEnumerator Wave()
    {
        yield return new WaitForSeconds(WaveCountdown);
        WaveRunning = true;
        WaveTimer = 20.0f + 5.0f * (float)WaveNumber;
        yield return new WaitForSeconds(WaveTimer);
        Debug.Log("yeah " + Time.time);
        Invoke("WavesPaused", 0);
        WaveNumber++;
        WaveRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
