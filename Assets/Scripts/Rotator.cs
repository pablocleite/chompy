using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var initialRotation = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        
        transform.Rotate(initialRotation);
    }

    // Update is called once per frame
    void Update()
    {
        var rotation = new Vector3(15f, 30f, 45f) * Time.deltaTime;
        
        transform.Rotate(rotation);
    }
}
