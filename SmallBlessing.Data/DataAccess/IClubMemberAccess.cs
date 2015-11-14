// -----------------------------------------------------------------------
// <copyright file="IClubMemberAccess.cs" company="John">
// Socia Member club Demo ©2013
// </copyright>
// -----------------------------------------------------------------------

namespace SmallBlessing.Data.DataAccess
{
    using System.Data;
    using SmallBlessing.Data.DataModel;

    /// <summary>
    /// Interface IClubMemberAccess
    /// </summary>
    public interface IClubMemberAccess
    {
        /// <summary>
        /// Method to get all club members
        /// </summary>
        /// <returns>Data table</returns>
        DataRow GetClubMemberById(int Id);

        /// <summary>
        /// Method to get all club members
        /// </summary>
        /// <returns>Data table</returns>
        DataRow GetFullClubMemberById(int Id);

        /// <summary>
        /// Method to get all club members
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetAllClubMembers();

        DataTable GetClubMembertoExport(int days);

        DataTable GetClubMemberItemsById(int PersonID);

        int GetClubMemberVisits(int PersonID);

        DataTable GetDependents(int PersonID);
        /// <summary>
        /// Method to search club members by multiple parameters
        /// </summary>
        /// <param name="occupation">occupation value</param>
        /// <param name="maritalStatus">marital status</param>
        /// <param name="operand">AND OR operand</param>
        /// <returns>Data table</returns>
        //DataTable SearchClubMembers(object occupation, object maritalStatus, string operand);
        DataTable SearchClubMembers(string firstName, string lastName, string operand);
        
        /// <summary>
        /// Method to create new member
        /// </summary>
        /// <param name="clubMember">club member model</param>
        /// <returns>true or false</returns>
        bool AddPerson(PersonModel clubMember);

        bool AddDependent(DependentModel dependentModel);



        /// <summary>
        /// Method to update club member details
        /// </summary>
        /// <param name="clubMember">club member</param>
        /// <returns></returns>
        bool UpdateClubMember(PersonModel clubMember);

        /// <summary>
        /// Method to delete a club member
        /// </summary>
        /// <param name="id">member id</param>
        /// <returns>true / false</returns>
        bool DeleteClubMember(int id);
    }
}
