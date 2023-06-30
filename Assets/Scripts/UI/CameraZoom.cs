using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 0.008f;    // �� �ӵ� ���� ����
    public float minFOV = 20f;      // �ּ� FOV ��
    public float maxFOV = 60f;      // �ִ� FOV ��

    private CinemachineVirtualCamera mainCamera;
    private float targetFOV;

    private void Awake()
    {
        mainCamera = GetComponent<CinemachineVirtualCamera>();
        targetFOV = mainCamera.m_Lens.FieldOfView;  
    }

    private void Update()
    {
        /*// ���콺 �� �Է��� �޾� FOV ����
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // FOV�� �����Ͽ� �� ��/�ƿ�
        targetFOV -= scroll * zoomSpeed;
        targetFOV = Mathf.Clamp(targetFOV, minFOV, maxFOV);

        // �ε巯�� �� ��/�ƿ��� ���� Lerp ���
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