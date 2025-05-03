using UnityEngine;
using System;
using UnityEditor;

namespace SB.Runtime.Editor {
    /// <summary>
    /// Defines an attribute that makes the array use enum values as labels.<br/>
    /// Use like this:<br/>
    /// [NamedArray(typeof(eDirection))] public GameObject[] m_Directions;
    /// </summary>
    public class NamedArrayAttribute : PropertyAttribute
    {
        public Type TargetEnum;
        /// <summary>
        /// Defines an attribute that makes the array use enum values as labels.
        /// </summary>
        /// <param name="TargetEnum">Enum type to use</param>
        public NamedArrayAttribute(Type TargetEnum)
        {
            this.TargetEnum = TargetEnum;
        }
    }
}