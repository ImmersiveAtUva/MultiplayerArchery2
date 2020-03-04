using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Normal.Realtime;

namespace Normal.Realtime {
    [DisallowMultipleComponent]
    public class LHTrigger : RealtimeTransform {
        //Detect collisions between the GameObjects with Colliders attached
        InputDevice lh;
        void Start() {
            lh = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        }
        void OnTriggerEnter(Collider other) {
            if (!realtimeView.isOwnedLocally)
                return;
            Debug.Log("Enter collision");
            vibe(lh);
        }
        private void vibe(InputDevice hand) {
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
    }
}