using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Move : MonoBehaviour
{
    [SerializeField] RealtimeAvatarManager rtam;
    private Vector2 trackpad;
    private float Direction;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Joysticks:");
        //Debug.Log(Input.GetAxisRaw("Primary2DAxis"));
 
    }  

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 10;
        //Define the speed at which the object moves.

        float horizontalInput = Input.GetAxis("Horizontal");
        //Get the value of the Horizontal input axis.

        float verticalInput = Input.GetAxis("Vertical");
        //Get the value of the Vertical input axis.
        Vector3 dir = rtam.localAvatar.leftHand.gameObject.transform.forward;
        Vector3 final_dir =  new Vector3(dir.x, 0, dir.z);
        Vector3.Normalize(final_dir);
        rtam.localAvatar.gameObject.transform.Translate(final_dir * verticalInput * moveSpeed * Time.deltaTime);
        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively
    }
}
