﻿using System;
using Ex = rm.Extensions.ExceptionHelper;

namespace rm.Extensions
{
    /// <summary>
    /// Check extensions.
    /// </summary>
    public static class CheckExtension
    {
        /// <summary>
        /// Throws exception if the object is null.
        /// </summary>
        /// <param name="exMessage">Exception message.</param>
        public static void NullCheck(this object o, string exMessage = "")
        {
            Ex.Throw<NullReferenceException>(o == null, exMessage);
        }
        /// <summary>
        /// Throws exception if the object argument is null.
        /// </summary>
        /// <param name="exMessage">Exception message.</param>
        public static void NullArgumentCheck(this object o, string exMessage = "")
        {
            Ex.Throw<ArgumentNullException>(o == null, exMessage);
        }
        /// <summary>
        /// Throws exception if the string is null or empty.
        /// </summary>
        /// <param name="exMessage">Exception message.</param>
        public static void NullOrEmptyCheck(this string s, string exMessage = "")
        {
            Ex.Throw<NullReferenceException>(s == null, exMessage);
            Ex.Throw<EmptyException>(s.Length == 0, exMessage);
        }
        /// <summary>
        /// Throws exception if the string argument is null or empty.
        /// </summary>
        /// <param name="exMessage">Exception message.</param>
        public static void NullOrEmptyArgumentCheck(this string s, string exMessage = "")
        {
            Ex.Throw<ArgumentNullException>(s == null, exMessage);
            Ex.Throw<EmptyException>(s.Length == 0, exMessage);
        }
    }
}