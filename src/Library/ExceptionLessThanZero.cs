//--------------------------------------------------------------------------------------
// <copyright file="Product.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------------

namespace Full_GRASP_And_SOLID
{

    public class LessThanZero : System.Exception
    {
        public LessThanZero() { }
        public LessThanZero(string message) : base(message) { }
        public LessThanZero(string message, System.Exception inner) : base(message, inner) { }
        protected LessThanZero(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}