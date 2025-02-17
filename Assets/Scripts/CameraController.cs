using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] 
    private GameObject player;
    
    private Vector3 _cameraOffset;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cameraOffset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + _cameraOffset;
    }
}
