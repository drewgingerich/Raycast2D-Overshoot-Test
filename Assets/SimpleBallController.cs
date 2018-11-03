using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Actor))]
public class SimpleBallController : MonoBehaviour {

	private Actor actor;

	void Awake() {
		actor = GetComponent<Actor>();
	}

	void FixedUpdate() {
		actor.Move(Vector2.down * Time.fixedDeltaTime);
	}
}
