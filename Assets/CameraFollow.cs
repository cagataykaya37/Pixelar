using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothness;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 smoothCamMovement = Vector3.Lerp(transform.position, target.position + offset, smoothness * Time.fixedDeltaTime);
        transform.position = smoothCamMovement;
        // Lerp ile iki nokta arasýndaki geçiþe float deðeri kadar gecikme verdim
    }

}
