using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Normal.Realtime;

public class ClientHaptics : MonoBehaviour
{
    // Which hand should this brush instance track?
    private enum Hand { LeftHand, RightHand };
    [SerializeField] private Hand _hand = Hand.LeftHand;
    private InputDevice input;
    private RealtimeTransform rtt;
    // Start is called before the first frame update
    void Start()
    {
        rtt = transform.parent.GetComponent<RealtimeTransform>();
        // Start by figuring out which hand we're tracking
        XRNode node = _hand == Hand.LeftHand ? XRNode.LeftHand : XRNode.RightHand;
        input = InputDevices.GetDeviceAtXRNode(node);

    }
    void OnTriggerEnter(Collider other) {
        Debug.Log("Enter collision");
        vibe(input);
    }
    private void vibe(InputDevice hand) {
        if (!rtt.isOwnedLocally) {
            return;
        }
        HapticCapabilities capabilities;
        if (hand.TryGetHapticCapabilities(out capabilities)) {
            if (capabilities.supportsImpulse) {
                uint channel = 0;
                float amplitude = 0.5f;
                float duration = 1.0f;
                hand.SendHapticImpulse(channel, amplitude, duration);
                Debug.Log("We vibin");
            }
        }
    }
    void OnTriggerExit(Collider other) {
        Debug.Log("Exit collision");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
