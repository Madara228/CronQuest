using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.2f;
    public GameObject background;
    private Vector3 _velocity = Vector3.zero;
    [SerializeField]
    private Camera _mainCamera;
    private void Start()
    {
        _mainCamera = GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
        background.transform.position = new Vector2(transform.position.x, transform.position.y);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (Physics2D.Raycast(worldPoint,Vector2.zero))
            {
                if (hit.collider.tag == "Key")
                {
                    var scr = hit.collider.gameObject.GetComponent<GetKeyScript>();
                    Debug.Log(scr.KeyNumber1);
                }
            }
        }
    }
}
