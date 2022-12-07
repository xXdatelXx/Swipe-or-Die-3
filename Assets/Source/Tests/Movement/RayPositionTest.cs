using NUnit.Framework;
using SwipeOrDie.Model;
using UnityEngine;

namespace Source.Tests.Movement
{
    [TestFixture]
    public sealed class RayPositionTest
    {
        private Transform _player;
        private IPosition _rayPosition;
        private Vector3 _correctPosition;
        private Vector3 _direction;

        [SetUp]
        public void SetUp()
        {
            _player = Object.Instantiate(new GameObject()).transform;
            var radius = new Radius(0.5f);

            var rightBorder = CreateBorder(new Vector3(10, 0));
            var leftBorder = CreateBorder(new Vector3(-1, 0));

            _direction = Vector2.right;
            _rayPosition = new RayPosition(_player, radius);
            _correctPosition = rightBorder.transform.position + radius.Indent(_direction) * 2;
        }

        private Transform CreateBorder(Vector3 position)
        {
            var border = Object.Instantiate(new GameObject());
            border.transform.position = position;
            border.AddComponent<BoxCollider>().size = Vector3.one;
            border.AddComponent<Border>();

            return border.transform;
        }

        [Test]
        public void CorrectNextPosition() =>
            Assert.That(_rayPosition.Next(_direction) == _correctPosition);

        [Test]
        public void StayIfBorderFrontOfPlayer() =>
            Assert.That(_rayPosition.Next(-_direction) == _player.position);
    }
}