using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class LogClientId : MonoBehaviour
{
    private RealtimeTransform rtv;
    // Start is called before the first frame update
    void Start()
    {
        rtv = GetComponent<RealtimeTransform>();
        Debug.Log("XXXXXXXXXXXX");
        Debug.Log("Here is the rtv locality");
        Debug.Log(rtv.isOwnedLocally);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
