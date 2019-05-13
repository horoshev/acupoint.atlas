using UnityEngine;

public class Selectable : MonoBehaviour {

    public float radius = 3f;
    private Transform interactionTransform;

    public virtual void Select() {

        // Debug.Log("Selectable Select " + transform.name);
    }

    void OnDrawGizmosSelected() {

        if (!interactionTransform) {
            interactionTransform = transform;
        }

        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}