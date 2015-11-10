// -----------------------------------------------------------------------
// <copyright file="Scripts.cs" company="John">
// Socia Member club Demo ©2013
// </copyright>
// -----------------------------------------------------------------------

namespace SmallBlessing.Data.Sql
{
    /// <summary>
    /// DBConstants static class contains sql string constants
    /// </summary>
    public static class Scripts
    {
        /// <summary>
        /// Sql to get a club member details by Id
        /// </summary>
        public static readonly string sqlGetFullClubMemberById = "Select" +
            " PersonID, FirstName, MiddleInitial as MI, LastName, Address, City, State, Zip, Phone,PhoneContactFlag,ChurchHomeName, ChurchHomeFlag, BirthDate, Opinion" +
            " From Person Where PersonID = @PersonID";
        
        /// <summary>
        /// Sql to get a club member details by Id
        /// </summary>
        public static readonly string sqlGetClubMemberById = "Select" +
            " PersonID, FirstName, MiddleInitial as MI, LastName, Address, City, State, Zip, Phone, ChurchHomeName, BirthDate" +
            " From Person Where PersonID = @PersonID";

        public static readonly string sqlGetDependentsById = "Select" +
            " [DependentID], [Name] as 'Name of Child', [BirthDate], [Relationship], [LivesWith]" +
            " From [Dependents] Where PersonID = @PersonID";

        /// <summary>
        /// Sql to get all club members
        /// </summary>
        public static readonly string SqlGetAllClubMembers = "Select" +
            " PersonID, FirstName, MiddleInitial as MI, LastName, Address, City, State, Zip, Phone, ChurchHomeName, BirthDate" +
            " FROM Person";
        
        /// <summary>
        /// sql to insert a club member details
        /// </summary>
        public static readonly string SqlInsertPerson = "Insert Into" +
            " Person(FirstName, MiddleInitial, LastName,Address,City,State,Zip,Phone,PhoneContactFlag,ChurchHomeFlag,ChurchHomeName,Opinion,BirthDate,DateCreated,DateUpdated)" +
            " Values(@FirstName, @MiddleInitial, @LastName,@Address,@City,@State,@Zip,@Phone,@PhoneContactFlag,@ChurchHomeFlag,@ChurchHomeName,@Opinion,@BirthDate,GETDATE(),GETDATE())" +
            "SELECT SCOPE_IDENTITY()";

        public static readonly string SqlInsertDependent = "Insert Into" +
            " Dependents(Name, BirthDate, Relationship, LivesWith, PersonID)" +
            " Values(@Name, @BirthDate, @Relationship,@LivesWith,@PersonID)";


        public static readonly string SqlDeleteDependent = "Delete from" +
            " Dependents" +
            " where (PersonID = @PersonID)";


        /// <summary>
        /// sql to search for club members
        /// </summary>
        public static readonly string SqlSearchPeople = "Select " +
            " PersonID, FirstName, MiddleInitial as MI, LastName, Address, City, State, Zip, Phone, ChurchHomeName, BirthDate" +
            " From Person Where(@FirstName is null or @FirstName = FirstName) {0} (@LastName is null or @LastName = LastName)";

        //public static readonly string SqlSearchPeople = "Select " +
        //    " Id, Name, DateOfBirth, Occupation, MaritalStatus, HealthStatus, Salary, NumberOfChildren" +
        //    " From ClubMember Where (@Occupation Is NULL OR @Occupation = Occupation) {0}" +
        //    " (@MaritalStatus Is NULL OR @MaritalStatus = MaritalStatus)";


        /// <summary>
        /// sql to update club member details
        /// </summary>
        public static readonly string sqlUpdateClubMember = "Update Person " +
            " Set [FirstName] = @FirstName,[MiddleInitial] = @MiddleInitial, [LastName] = @LastName, [Address] = @Address," +
            " [City] = @City, [Zip] = @Zip, [State] = @State, [Phone] = @Phone, [PhoneContactFlag] = @PhoneCOntactFlag," +
            " [Opinion] = @Opinion, [BirthDate] = @BirthDate, [ChurchHomeName] = @ChurchHomeName" +
            " Where ([PersonID] = @ID)";

        public static readonly string sqlUpdateClubMemberDependent = "Update Dependents " +
            " Set [Name] = @Name, [BirthDate] = @BirthDate, [Relationship] = @Relationship, [LivesWith] = @LivesWith" +
            " Where ([PersonID] = @PersonID and [DependentID] = @DependentID)";

        /// <summary>
        /// sql to delete a club member record
        /// </summary>
        public static readonly string sqlDeleteClubMember = "Delete From ClubMember Where (Id = @Id)";
    }
}
