using System;
using System.Diagnostics;

namespace Nintenlord.Utility.Contracts
{
    public class Contract
    {
        public static void Requires<TException>( bool Predicate, string Message )
            where TException : Exception, new()
        {
           if ( !Predicate )
           {
              Debug.WriteLine( Message );
              throw new TException();
           }
        }

        public static void Requires<TException>( bool Predicate )
            where TException : Exception, new()
        {
           if ( !Predicate )
           {
              throw new TException();
           }
        }

        public static void Requires( bool Predicate )
        {
           if ( !Predicate )
           {
              throw new Exception();
           }
        }
    }
}
