using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helix : MonoBehaviour
{
    Vector2 lasttappos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 currentmousepos=Input.mousePosition;
            if (lasttappos == Vector2.zero)
            {
                lasttappos= currentmousepos;
            }
            float delta = lasttappos.x - currentmousepos.x;
            transform.Rotate(Vector3.up * delta);
            lasttappos = currentmousepos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            lasttappos = Vector2.zero;
        }
        
        
    }
}
