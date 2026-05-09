using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class SocketVelocityCheck : MonoBehaviour
{
    public float maxPlacementVelocity = 0.5f; // Maximum velocity allowed for placement

    public void CheckVeclotyOnEnter(SelectEnterEventArgs args)
    {
        Rigidbody interactorRigidbody = args.interactorObject.transform.GetComponent<Rigidbody>();

        if (interactorRigidbody != null)
        {
            float speed = interactorRigidbody.velocity.magnitude;
            if (speed > maxPlacementVelocity)
            {
                Debug.Log("Object placed too quickly! Speed: " + speed);
                XRSocketInteractor socket = GetComponent<XRSocketInteractor>();
                socket.interactionManager.SelectExit(socket, args.interactableObject);
            }
            else
            {
                Debug.Log("Object placed successfully. Speed: " + speed);
            }
        }
    }
}
