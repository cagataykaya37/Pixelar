using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceGravity : MonoBehaviour
{
    public GameObject boxDelete;
    bool check = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player" && check) 
        {
            check = false;
            StartCoroutine(coundownDestroyGravity());
            StartCoroutine(coundownDestroy());
        }
    }

    IEnumerator coundownDestroy() 
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

    IEnumerator coundownDestroyGravity()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(boxDelete);
    }

}
