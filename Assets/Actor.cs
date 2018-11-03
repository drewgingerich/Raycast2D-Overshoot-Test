using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Actor : MonoBehaviour {

	[SerializeField]
	private Collider2D otherCollider;

	private const float shellWidth = 0.001f;

	private Rigidbody2D rb2d;
	private Collider2D collider;
	private RaycastHit2D[] hitBuffer = new RaycastHit2D[8];
	private ContactFilter2D contactFilter;
	
	void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
		collider = GetComponent<Collider2D>();

		contactFilter = new ContactFilter2D();
		contactFilter.useTriggers = false;
		contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
	}

	public void Move(Vector2 move) {
		float distance = move.magnitude;
		Vector2 direction = move.normalized;
		float searchDistance = distance;

		int count = rb2d.Cast(direction, hitBuffer, searchDistance);
		if (count > 0) {
			distance = hitBuffer[0].distance;
		}

		// transform.Translate((Vector3)direction * distance);
		rb2d.MovePosition(rb2d.position + direction * distance);

		ColliderDistance2D colDistance = collider.Distance(otherCollider);
		Debug.Log(string.Format("Cast distance: {0}, Overlap distance: {1}", distance, colDistance.distance));
	}
}
