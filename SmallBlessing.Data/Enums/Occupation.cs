// -----------------------------------------------------------------------
// <copyright file="Occupation.cs" company="John">
// Socia Member club Demo ©2013
// </copyright>
// -----------------------------------------------------------------------

namespace SmallBlessing.Data.Enum
{
    using System.ComponentModel;

    /// <summary>
    /// Enumerator for occupation
    /// </summary>
    public enum Occupation
    {
        /// <summary>
        /// Occupation - Doctor
        /// </summary>
        [Description("No")]
        False = 0,

        /// <summary>
        /// Occupation - Engineer
        /// </summary>
        [Description("Yes")]
        True,

        /// <summary>
        /// Occupation - Professor
        /// </summary>
        [Description("Professor")]
        Professor,
    }
}
