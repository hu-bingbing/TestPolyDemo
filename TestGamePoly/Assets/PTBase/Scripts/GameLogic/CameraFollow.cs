using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float upSpeed = 5;
    public float downSpeed = 4;
    public float posOffset = 0;
    public float height = 30f;
    public float distance = 10f;
    public float rotation_x = 70f;
    public float rotation_y = 0f;
    public float rotation_z = 0;
    private Vector3 lastPos;
    
	void LateUpdate () {
	    if(target != null)
        {
            Vector3 desiredPos = new Vector3(target.position.x + posOffset, target.position.y + height, target.position.z - distance);
            if(desiredPos.y > lastPos.y)
            {
                transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * upSpeed);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * downSpeed);
            }
            lastPos = desiredPos;

            Quaternion rot = Quaternion.Euler(rotation_x, rotation_y, rotation_z);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.2f);
        }
	}
}
