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
    private RealtimeTransform collisionRTT = null;
    // Start is called before the first frame update
    void Start()
    {
        rtt = transform.parent.GetComponent<RealtimeTransform>();
        // Start by figuring out which hand we're tracking
        XRNode node = _hand == Hand.LeftHand ? XRNode.LeftHand : XRNode.RightHand;
        input = InputDevices.GetDeviceAtXRNode(node);
        
    }
    void OnCollisionEnter(Collision collision) {
        GameObject other = collision.gameObject;
        RealtimeTransform otherRTT = other.GetComponent<RealtimeTransform>();
        if (otherRTT) {
            // may need to check if this is the local copy of the avatar
            // current version works because clones collide on both clients but 
            // this may cause bugs in the future
            otherRTT.RequestOwnership();
            collisionRTT = otherRTT;
        }
        vibe(input, 0.5f);
    }
    private void vibe(InputDevice hand, float amplitude) {
        if (!rtt.isOwnedLocally) {
            return;
        }
        HapticCapabilities capabilities;
        if (hand.TryGetHapticCapabilities(out capabilities)) {
            if (capabilities.supportsImpulse) {
                uint channel = 0;
                float duration = 1.0f;
                hand.SendHapticImpulse(channel, amplitude, duration);
                Debug.Log("We vibin");
            }
        }
    }
    void OnCollisionExit(Collision collision) {
        // collisionRTT.ClearOwnership();
        collisionRTT = null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
