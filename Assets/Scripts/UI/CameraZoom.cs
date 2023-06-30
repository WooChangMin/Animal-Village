using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 0.008f;    // 줌 속도 조절 변수
    public float minFOV = 20f;      // 최소 FOV 값
    public float maxFOV = 60f;      // 최대 FOV 값

    private CinemachineVirtualCamera mainCamera;
    private float targetFOV;

    private void Awake()
    {
        mainCamera = GetComponent<CinemachineVirtualCamera>();
        targetFOV = mainCamera.m_Lens.FieldOfView;  
    }

    private void Update()
    {
        /*// 마우스 휠 입력을 받아 FOV 조정
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // FOV를 조정하여 줌 인/아웃
        targetFOV -= scroll * zoomSpeed;
        targetFOV = Mathf.Clamp(targetFOV, minFOV, maxFOV);

        // 부드러운 줌 인/아웃을 위해 Lerp 사용
        mainCamera.m_Lens.FieldOfView = Mathf.Lerp(mainCamera.m_Lens.FieldOfView, targetFOV, Time.deltaTime * zoomSpeed);*/
    }
    private void OnEnable()
    {
        FindObjectOfType<PlayerControll>().OnInventoryOpen += InventoryZoomIn;
        FindObjectOfType<PlayerControll>().OnInventoryClose += InventoryZoomOut;
    }

    private void OnDisable()
    {
        FindObjectOfType<PlayerControll>().OnInventoryOpen -= InventoryZoomIn;
        FindObjectOfType<PlayerControll>().OnInventoryClose -= InventoryZoomOut;
    }

    private void InventoryZoomIn()
    {
        StartCoroutine(ZoomCoroutine(minFOV));
    }
    private void InventoryZoomOut()
    {
        StartCoroutine(ZoomCoroutine(targetFOV));
    }
    
    IEnumerator ZoomCoroutine(float FOV)
    {
        while(Mathf.Abs(mainCamera.m_Lens.FieldOfView - FOV) > 0.1f)
        {
            mainCamera.m_Lens.FieldOfView = Mathf.Lerp(mainCamera.m_Lens.FieldOfView, FOV, zoomSpeed);
            yield return null;
        }
    }
}