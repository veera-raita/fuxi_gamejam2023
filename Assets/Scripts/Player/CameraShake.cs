using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance {  get; private set; }
    private CinemachineVirtualCamera cam;
    private float shakeTimer;

    private void Awake()
    {
        instance = this;
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float t_intensity, float t_time)
    {
        CinemachineBasicMultiChannelPerlin t_perlin =
            cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        t_perlin.m_AmplitudeGain = t_intensity;
        shakeTimer = t_time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0)
            {
                CinemachineBasicMultiChannelPerlin t_perlin =
                    cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                t_perlin.m_AmplitudeGain = 0f;
            }
        }        
    }
}
