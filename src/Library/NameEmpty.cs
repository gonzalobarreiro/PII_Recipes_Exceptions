//--------------------------------------------------------------------------------------
// <copyright file="Product.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------------

namespace Full_GRASP_And_SOLID
{

    public class NameEmpty : System.Exception
    {
        public NameEmpty() { }
        public NameEmpty(string message) : base(message) { }
        public NameEmpty(string message, System.Exception inner) : base(message, inner) { }
        protected NameEmpty(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}