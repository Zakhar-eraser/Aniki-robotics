using UnityEngine;

[RequireComponent(typeof(WireBending))]
public class BendableWire : MonoBehaviour
{
    [SerializeField]
    private GameObject providerObject;
    private WireBending origin;
    private WireBending provider;
    void Start() {
        origin = GetComponent<WireBending>();
        provider = providerObject.GetComponent<WireBending>();
        if (provider) {
            origin.nextBending = provider;
            provider.previousBending = origin;
        } else {
            Debug.LogError("Provider object requires Wire Bending component", providerObject);
        }
    }

    void Update() {
        
    }


}
