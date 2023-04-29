using System.Collections.Generic;
using UnityEngine;

public class GravitySimulator : MonoBehaviour
{
    public Rigidbody        heavyObject;
    public List<Rigidbody>  orbitingObjects;

    private void FixedUpdate()
    {
        foreach (Rigidbody orbitingObject in orbitingObjects)
        {
            Vector3 gravityDirection = (heavyObject.position - orbitingObject.position).normalized;
            float gravityMagnitude = Physics.gravity.magnitude * heavyObject.mass * orbitingObject.mass / (heavyObject.position - orbitingObject.position).sqrMagnitude;
            Vector3 gravity = gravityDirection * gravityMagnitude;

            orbitingObject.AddForce(gravity);

            orbitingObject.transform.LookAt(heavyObject.transform);

            float distance = Vector3.Distance(heavyObject.position, orbitingObject.position);
            float orbitalVelocity = Mathf.Sqrt((Physics.gravity.magnitude * heavyObject.mass) / distance);
            orbitingObject.transform.RotateAround(heavyObject.position, Vector3.up, orbitalVelocity * Time.deltaTime);
        }
    }
}
