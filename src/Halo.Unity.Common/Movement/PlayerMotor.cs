using GladBehaviour.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Halo.Unity.Common
{
	/// <summary>
	/// Provides a simple player motor for local or networked movement.
	/// </summary>
	public class PlayerMotor : GladMonoBehaviour, ITimeSimulation
	{
		/// <summary>
		/// Motor input.
		/// </summary>
		[SerializeField]
		private IMovementInput motorInput;
		
		/// <summary>
		/// Parameters for movement.
		/// </summary>
		[SerializeField]
		private IMovementParameters movementParameters;

		/// <summary>
		/// Service that computes movement direction
		/// </summary>
		[SerializeField]
		private IMovementDirectionService directionService;

		/// <summary>
		/// Character controller for the Motor
		/// </summary>
		[SerializeField]
		private CharacterController characterController;

		/// <summary>
		/// Keeps track of non-simple movement data.
		/// </summary>
		private Vector3 gravity;

		private void Start()
		{
			motorInput.ThrowIfNull();
			movementParameters.ThrowIfNull();
			characterController.ThrowIfNull();
			directionService.ThrowIfNull();
		}

		//Runs in a fixed timestep
		private void FixedUpdate()
		{
			//Simulate the motor forward
			Simulate(Time.fixedDeltaTime);
		}

		/// <summary>
		/// Simulates the motor forward in time.
		/// </summary>
		/// <param name="dt">Time delta.</param>
		public void Simulate(float dt)
		{
			//Simulation code based on: http://www.teapluscode.org/2012/02/client-side-prediction-in-unity.html

			Vector3 movementDelta = ((this.gravity + directionService.BuildDirection(motorInput, true) * movementParameters.MovementSpeed) * dt) + 0.5f * (Physics.gravity * dt * dt);
			this.characterController.Move(movementDelta);

			//Only reset gravity if it's negative
			if (characterController.isGrounded)
				gravity = Vector3.zero;

			this.gravity += Physics.gravity * dt;

			//Poll for a jump request.
			//Why do we poll? Well, FixedUpdate or simulate could be called for multiple frames and can't
			//directly depend on keypresses because a network client may be rewinding and resimulating for some reason.
			//(Warning: FixedUpdate can be called multiple times a frame or no times a frame so this means double input or input eating may occur without this)
			if(motorInput.TryConsumeJumpRequest())
				gravity += new Vector3(0, movementParameters.JumpIntensity, 0);
		}

		/// <summary>
		/// Will bounce the player when it comes in contact with a service when jumping.
		/// </summary>
		/// <param name="hit">Collision information.</param>
		public void OnControllerColliderHit(ControllerColliderHit hit)
		{
			//We don't want to mess with gravity if it's currently running.
			//This will give us a small bounce
			if (gravity.y > 0)
				this.gravity = hit.normal;
		}
	}
}
