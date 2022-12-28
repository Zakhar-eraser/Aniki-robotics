using UnityEngine;

public class WireBending : MonoBehaviour
{
    private int layerMask;
    private const float sqrBendingRad = 0.0025f;
    private const float bendingOffsetFromHit = 0.07f;
    private const float normalOffsetFromHit = 0.01f;
    private bool obserivng = false;
    public WireBending previousBending;
    public WireBending nextBending;

    private void Awake() {
        layerMask = ~LayerMask.NameToLayer("Ignore Wire");
    }
    private void FixedUpdate() {
        if (previousBending) {
            RaycastHit toPreviousHit;
            RaycastHit fromPreviousHit;
            bool areHits = Physics.Linecast(transform.position,
                    previousBending.transform.position,
                    out toPreviousHit, layerMask);
            areHits &= Physics.Linecast(previousBending.transform.position,
                    transform.position,
                    out fromPreviousHit, layerMask);
            if (areHits) {
                if (obserivng) {

                }
            } else {
                obserivng = false;
            }
        }
    }

    private void AddBendig(in RaycastHit hit) {
        GameObject newBendingObject = new GameObject("bending", typeof(WireBending));
        newBendingObject.transform.position = hit.point;
        newBendingObject.transform.SetParent(hit.transform);
        WireBending newBending = newBendingObject.GetComponent<WireBending>();
        previousBending.nextBending = newBending;
        newBending.previousBending = previousBending;
        newBending.nextBending = this;
        previousBending = newBending;
    }

    private void SetProbe(in RaycastHit hit) {

    }
    
    private void RemoveProbes() {

    }

    private bool ArePositionsNear(Vector3 position1, Vector3 position2, float radius) {
        return (position1 - position2).sqrMagnitude < radius;
    }
}
