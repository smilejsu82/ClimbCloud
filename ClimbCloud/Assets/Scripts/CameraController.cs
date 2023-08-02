using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject catGo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.catGo.transform.position.y > 0)
        {
            this.transform.position
                = new Vector3(this.transform.position.x, this.catGo.transform.position.y, this.transform.position.z);
        }
        
    }
}
