using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace SwipeOrDie.Web
{
    public class Url : IUrl
    {
        [SerializeField] private string _value;

        public Url(string value)
        {
            _value = Uri.IsWellFormedUriString(value, UriKind.Absolute)
                ? value
                : throw new InvalidOleVariantTypeException("value is not url");
        }

        public void Open() =>
            Application.OpenURL(_value);
    }
}