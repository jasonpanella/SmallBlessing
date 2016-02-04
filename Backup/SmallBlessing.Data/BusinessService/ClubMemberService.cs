// -----------------------------------------------------------------------
// <copyright file="ClubMemberService.cs" company="John">
// Socia Member club Demo ©2013
// </copyright>
// -----------------------------------------------------------------------

namespace SmallBlessing.Data.BusinessService
{
    using System.Data;
    using SmallBlessing.Data.DataAccess;
    using SmallBlessing.Data.DataModel;

    /// <summary>
    /// class to query the DataAccess, implements IClubMemberService interface
    /// </summary>
    public class ClubMemberService : IClubMemberService
    {
        /// <summary>
        /// interface of ClubMemberAccess
        /// </summary>
        private IClubMemberAccess memberAccess;

        /// <summary>
        /// Initializes a new instance of the ClubMemberService class
        /// </summary>
        public ClubMemberService()
        {
            this.memberAccess = new ClubMemberAccess();
        }

        /// <summary>
        /// Service method to get club member by Id
        /// </summary>
        /// <param name="id">member id</param>
        /// <returns>Data row</returns>
        public DataRow GetClubMemberById(int id)
        {
            return this.memberAccess.GetClubMemberById(id);
        }

        


        /// <summary>
        /// Service method to get club member by Id
        /// </summary>
        /// <param name="id">member id</param>
        /// <returns>Data row</returns>
        public DataRow GetFullClubMemberById(int id)
        {
            return this.memberAccess.GetFullClubMemberById(id);
        }


        /// <summary>
        /// Service method to get all club members
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetAllClubMembers()
        {            
            return this.memberAccess.GetAllClubMembers();
        }

        public DataTable GetClubMembertoExport(int days)
        {
            return this.memberAccess.GetClubMembertoExport(days);
        }


        public DataTable GetClubMemberItemsById(int Id)
        {
            return this.memberAccess.GetClubMemberItemsById(Id);
            //date, descr, comments, initials
        }


        public DataTable GetDependents(int PersonID)
        {
            return this.memberAccess.GetDependents(PersonID);
        }
        /// <summary>
        /// Service method to search records by multiple parameters
        /// </summary>
        /// <param name="occupation">occupation value</param>
        /// <param name="maritalStatus">marital status</param>
        /// <param name="operand">AND OR operand</param>
        /// <returns>Data table</returns>
        //public DataTable SearchClubMembers(object occupation, object maritalStatus, string operand)
        //{
        //    return this.memberAccess.SearchClubMembers(occupation, maritalStatus, operand);
        //}
        public DataTable SearchClubMembers(string firstName, string lastName, string operand)
        {
            return this.memberAccess.SearchClubMembers(firstName, lastName, operand);
        }
        
        /// <summary>
        /// Service method to create new member
        /// </summary>
        /// <param name="clubMember">club member model</param>
        /// <returns>true or false</returns>
        public bool RegisterPerson(PersonModel person)
        {
            return this.memberAccess.AddPerson(person);
        }

        public bool RegisterDependent(DependentModel dependent)
        {
            return this.memberAccess.AddDependent(dependent);
        }

        //public int GetClubMemberVisits(int Id, string date)
        //{
        //    return this.memberAccess.GetClubMemberVisits(Id, date);
        //}

        public int GetClubMemberVisits(int Id)
        {
            return this.memberAccess.GetClubMemberVisits(Id);
        }

        public int GetClubMemberVisitsInMonth(int Id, string date)
        {
            return this.memberAccess.GetClubMemberVisitsInMonth(Id, date);
        }

        /// <summary>
        /// Service method to update club member
        /// </summary>
        /// <param name="clubMember">club member</param>
        /// <returns>true / false</returns>
        public bool UpdateClubMember(PersonModel clubMember)
        {
            return this.memberAccess.UpdateClubMember(clubMember);
        }

        //public bool GetClubMemberLockDate(string date, int id)
        //{
        //    //return this.memberAccess.GetClubMemberLockDate(date, id);
        //}

        public bool UpdateClubMemberLockItemFlag(PersonModel person)
        {
            return this.memberAccess.UpdateClubMemberLockItemFlag(person);
        }

        /// <summary>
        /// Method to delete a club member
        /// </summary>
        /// <param name="id">member id</param>
        /// <returns>true / false</returns>
        public bool DeleteClubMember(int id)
        {
            return this.memberAccess.DeleteClubMember(id);
        }
    }
}
