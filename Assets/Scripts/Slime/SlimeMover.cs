using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime
{
    public class SlimeMover : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 3;

        private float maxMoveSpeed = 20;

        private Rigidbody2D _rigidbody;


        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }


        void Start()
        {
            _InitializeVelocity();
        }

        void FixedUpdate()
        {
            var velocity = _rigidbody.velocity;
            if (velocity.sqrMagnitude > maxMoveSpeed * maxMoveSpeed)
                _rigidbody.velocity = velocity.normalized * maxMoveSpeed;
        }

        private void _InitializeVelocity()
        {
            var random = Random.Range(0, 360);
            var moveAngle = random * Mathf.Deg2Rad;
            var moveVector = new Vector2(Mathf.Cos(moveAngle), Mathf.Sin(moveAngle));

            _rigidbody.velocity = moveVector * moveSpeed;
        }

        public void Stop()
        {
            _rigidbody.velocity = Vector3.zero;
        }

    }
}

