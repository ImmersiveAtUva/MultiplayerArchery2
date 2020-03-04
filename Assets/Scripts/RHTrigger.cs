using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Normal.Realtime;

namespace Normal.Realtime {
    [DisallowMultipleComponent]
    public class RHTrigger : RealtimeTransform {
        //Detect collisions between the GameObjects with Colliders attached
        InputDevice rh;
        /*
        private RealtimeTransformModel _model;
        public RealtimeTransformModel model { get { return _model; } set { SetModel(value); } }
        // TODO: Rather than getting getting the client ID from realtime to compare, I'd rather the model be able to tell us whether it's owned locally or not. The model should have a reference to the room/datastore it belongs to.
        //       Once IModel becomes a class instead of an interface, we'll be able to do this.
        public int ownerID { get { return _model.ownerID; } }
        public bool isOwnedLocally { get { return _model.ownerID == realtime.clientID; } }
        */
        void Start() {
            rh = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        }
        void OnTriggerEnter(Collider other) {
            Debug.Log(realtimeView);
            if (!realtimeView.isOwnedLocally)
                return;
            Debug.Log("Enter collision");

            vibe(rh);
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