using NUnit.Framework;
using SwipeOrDie.Model;
using UnityEngine;

namespace Source.Tests.Movement
{
    public sealed class RadiusTest
    {
        [Test]
        public void CorrectIndent()
        {
            var radius = new Radius(1);
            Assert.That(radius.Indent(Vector3.right) == new Vector3(-1, 0));
        }
    }
}