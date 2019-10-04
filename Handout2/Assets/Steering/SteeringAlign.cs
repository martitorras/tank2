using UnityEngine;
using System.Collections;

public class SteeringAlign : MonoBehaviour {

	public float min_angle = 0.01f;
	public float slow_angle = 0.1f;
	public float time_to_target = 0.1f;

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}

    // Update is called once per frame
    void Update()
    {
        // TODO 7: Very similar to arrive, but using angular velocities
        // Find the desired rotation and accelerate to it
        // Use Vector3.SignedAngle() to find the angle between two directions
        Vector3 diff = transform.forward;
        Vector3 axis;
        axis.x = 0.0f;
        axis.y = 1.0f;
        axis.z = 0.0f;
        Vector3 current = move.movement;
        float desired = Vector3.SignedAngle(diff, current, axis);
        //move.SetRotationVelocity(desired);
        float accel = (desired - move.rotation) * Time.deltaTime;
        //desired = desired.normalized * move.max_mov_speed * slow_distance;
        if (desired < 0) desired = -desired;
        if (desired < min_angle)//desired absolut
        {
            move.SetRotationVelocity(0.0f);
        }
        else
        {
            Mathf.Clamp(accel, move.max_rot_acceleration, -move.max_rot_acceleration);
            move.AccelerateRotation(accel);
        }
    }
}
