using System.Collections;
using NUnit.Framework;
using SwipeOrDie.Model;
using UnityEngine;
using UnityEngine.TestTools;

namespace Source.Tests.Movement
{
    [TestFixture]
    public sealed class MovementTest
    {
        private IPosition _position;
        private Vector3 _correctPosition;
        private Vector3 _direction;

        [UnityTest]
        public IEnumerator CorrectNextPosition()
        {
            var transform = Object.Instantiate(new GameObject("Player")).transform;
            var radius = new Radius(0.5f);
            
            var border = Object.Instantiate(new GameObject("Border"));
            border.transform.position = new Vector3(10, 0);
            border.AddComponent<BoxCollider>().size = Vector3.one;
            border.AddComponent<Border>();

            _direction = Vector2.right;
            _position = new RayPosition(transform, radius);
            _correctPosition = border.transform.position + radius.Indent(_direction) * 2;
            
            Logger.Log(_position.Next(_direction));
            Assert.That(_position.Next(_direction) == _correctPosition);
            yield return new WaitForSeconds(0);
        }
    }
}