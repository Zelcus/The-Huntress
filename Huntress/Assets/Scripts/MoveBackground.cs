 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

    [SerializeField]
    private Transform centerBackground;
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("center pos:" + centerBackground.position.y);
        Debug.Log("Transform pos:" + transform.position.y);

        if (transform.position.y >= centerBackground.position.y)
        {
            Vector3 temp = new Vector2(centerBackground.position.x, transform.position.y + 4f);
            centerBackground.position += temp;
        }

        else if (transform.position.y <= centerBackground.position.y)
        {
            Vector3 temp = new Vector2(centerBackground.position.x, transform.position.y - 4f);
            centerBackground.position += temp;
        }
        
        if(transform.position.x >= centerBackground.position.x)
        {
            Vector3 temp = new Vector2(transform.position.x + 2.4f, centerBackground.position.y);
            centerBackground.position += temp;
        }

        else if (transform.position.x <= centerBackground.position.x)
        {
            Vector3 temp = new Vector2(transform.position.x -2.4f, centerBackground.position.y);
            centerBackground.position += temp;
        }
    }
}
