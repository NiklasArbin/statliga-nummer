using System;

namespace StatligaNummer
{
    public class InvalidPersonnummerException : Exception
    {
        public InvalidPersonnummerException(string personNummer): base(string.Format("'{0}' is not a valid Personnummer", personNummer))
        {

        }
    }
}