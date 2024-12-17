using UnityEngine;

public class CameraController : MonoBehaviour
{
[SerializeField] private Transform player; //serialiseing this variable means it can bee pulled form memory for use at runtime while not being exposed at a public level.
[SerializeField] private float cameraLead; // Distance the camera aims ahead of the player
[SerializeField] private float cameraSpeed; // Movement rate of camera, ideally interp

private float cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.position.y + cameraOffset, transform.position.z);
        cameraOffset = Mathf.Lerp(cameraOffset, cameraLead, Time.deltaTime * cameraSpeed );
    }
}
