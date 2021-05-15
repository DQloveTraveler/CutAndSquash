using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime
{
    public class SlimeMover
    {
        private float startSpeed;
        private float maxMoveSpeed = 20;
        private Rigidbody2D _rigidbody;

        public SlimeMover(float startSpeed, Rigidbody2D rigidbody2D)
        {
            this.startSpeed = startSpeed;
            _rigidbody = rigidbody2D;
        }

        public void FixedUpdate()
        {
            var velocity = _rigidbody.velocity;
            if (velocity.sqrMagnitude > maxMoveSpeed * maxMoveSpeed)
                _rigidbody.velocity = velocity.normalized * maxMoveSpeed;
        }

        public void SetVelocity()
        {
            var random = Random.Range(0, 360);
            var moveAngle = random * Mathf.Deg2Rad;
            var moveVector = new Vector2(Mathf.Cos(moveAngle), Mathf.Sin(moveAngle));

            _rigidbody.velocity = moveVector * startSpeed;
        }

        public void Stop()
        {
            _rigidbody.velocity = Vector3.zero;
        }

    }
}

