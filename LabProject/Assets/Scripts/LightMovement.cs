using UnityEngine;

public class LightMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private float moveUnits = 0.3f;

    private Vector3 offset;

    private void Awake() {
        offset = transform.localPosition;
    }

    private void Update() {
        float moveValue = Mathf.Sin(Time.time * moveSpeed) * moveUnits;
        transform.localPosition = new Vector3(moveValue, moveValue / 2, 0) + offset;
    }
}