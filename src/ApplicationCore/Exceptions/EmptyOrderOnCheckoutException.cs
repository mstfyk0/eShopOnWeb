using System;

namespace Microsoft.eShopWeb.ApplicationCore.Exceptions;

public class EmptyOrderOnCheckoutException : Exception
{
    public EmptyOrderOnCheckoutException()
        : base($"Basket cannot have 0 items on checkout")
    {
    }

    protected EmptyOrderOnCheckoutException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
    {
    }

    public EmptyOrderOnCheckoutException(string message) : base(message)
    {
    }

    public EmptyOrderOnCheckoutException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
