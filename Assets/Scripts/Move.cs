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
    
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rtam.localAvatar.gameObject.transform.position);
     
    }
}
