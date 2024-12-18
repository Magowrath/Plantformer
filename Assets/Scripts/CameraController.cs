using UnityEngine;

public class CameraController : MonoBehaviour
{
[SerializeField] private Transform player; //serialiseing this variable means it can bee pulled form memory for use at runtime while not being exposed at a public level.
[SerializeField] private float cameraLead; // Distance the camera aims ahead of the player
[SerializeField] private float cameraSpeed; // Movement rate of camera, ideally interp

private float cameraOffset;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.position.y + cameraOffset, transform.position.z);
        //Moves the camera to follow a point just above the player in the y axis. it is also locked in the x and z axis as to thesure the camera doesn't wonder off out of bounds
        cameraOffset = Mathf.Lerp(cameraOffset, cameraLead, Time.deltaTime * cameraSpeed );
        //Uses a linear Interpolation to smooth the camera movements.
    }
}
