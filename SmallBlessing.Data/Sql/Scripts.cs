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
        /// 

        public static readonly string SqlGetClubMemberVisits = "SELECT count(*) From Items i" +
            " inner join Person p on i.PersonID = p.PersonID" +
            " where i.Date >= DATEADD(year,-1,@Date) and (i.PersonID = @PersonID)";//DateUpdated > DATEADD(year,-1,GETDATE())";

        public static readonly string SqlGetClubMemberVisitsInMonth = "SELECT count(*) From Items i" +
           " inner join Person p on i.PersonID = p.PersonID" +
           " where i.Date >= DATEADD(mm, -1,@Date) and (i.PersonID = @PersonID)";//DateUpdated > DATEADD(year,-1,GETDATE())";

        public static readonly string sqlGetFullClubMemberById = "Select" +
            " PersonID, FirstName, MiddleInitial as MI, LastName, Address, City, State, Zip, Phone,PhoneContactFlag,ChurchHomeName, ChurchHomeFlag, BirthDate, Opinion, DateUpdated,ProofGuardianFlag,LockItemDate, LockItemFlag" +
            " From Person Where PersonID = @PersonID";
        
        /// <summary>
        /// Sql to get a club member details by Id
        /// </summary>
        public static readonly string sqlGetClubMemberById = "Select" +
            " PersonID, FirstName, MiddleInitial as MI, LastName, Address, City, State, Zip, Phone, ChurchHomeName, BirthDate, DateUpdated, ProofGuardianFlag " +
            " From Person Where PersonID = @PersonID";

        public static readonly string sqlGetDependentsById = "Select" +
            " [DependentID], [Name] as 'Name of Child', [BirthDate], [Relationship], [LivesWith]" +
            " From [Dependents] Where PersonID = @PersonID";

        /// <summary>
        /// Sql to get all club members
        /// </summary>
        public static readonly string SqlGetAllClubMembers = "Select" +
            " PersonID, FirstName as 'First Name', MiddleInitial as MI, LastName as 'Last Name', Address, City, State, Zip, Phone, ChurchHomeName 'Church Home', BirthDate, DateUpdated as 'Last Visit' " +
            " FROM Person";

        public static readonly string SqlGetAllClubMembersToExport = "Select" +
           " PersonID, FirstName, MiddleInitial as MI, LastName, Address, City, State, Zip, Phone, ChurchHomeName, BirthDate" +
           " FROM Person" +
           " WHERE DATEDIFF(DAY,[DateUpdated],GETDATE()) <= @DaysToExport and ExportFlag = 0";

        public static readonly string SqlUpdateClubMembersExportFlag = "Update Person" +
           " set [ExportFlag] = 1" +
           " WHERE DATEDIFF(DAY,[DateUpdated],GETDATE()) <= @DaysToExport and ExportFlag = 0";

        
        public static readonly string SqlGetPersonItems = "Select" +
            " ItemID, Description, Comments, Initials, Date"+//, LockItemsDate" +
            " FROM Items where PersonID = @PersonID";


        /// <summary>
        /// sql to insert a club member details
        /// </summary>
        public static readonly string SqlInsertPerson = "Insert Into" +
            " Person(FirstName, MiddleInitial, LastName,Address,City,State,Zip,Phone,PhoneContactFlag,ChurchHomeFlag,ChurchHomeName,Opinion,BirthDate,DateCreated,DateUpdated,ExportFlag,ProofGuardianFlag,LockItemFlag)" +
            " Values(@FirstName, @MiddleInitial, @LastName,@Address,@City,@State,@Zip,@Phone,@PhoneContactFlag,@ChurchHomeFlag,@ChurchHomeName,@Opinion,@BirthDate,GETDATE(),GETDATE(),0,@ProofGuardianFlag,'False')" +
            "SELECT SCOPE_IDENTITY()";

        public static readonly string SqlInsertDependent = "Insert Into" +
            " Dependents(Name, BirthDate, Relationship, LivesWith, PersonID)" +
            " Values(@Name, @BirthDate, @Relationship,@LivesWith,@PersonID)";

        public static readonly string SqlInsertItems = "Insert Into" +
            " Items(Description, Date, Comments, Initials, PersonID)" +
            " Values(@Description, @Date, @Comments,@Initials,@PersonID)";

        public static readonly string SqlDeleteDependent = "Delete from" +
            " Dependents" +
            " where (PersonID = @PersonID)";

        public static readonly string SqlDeleteItems = "Delete from" +
            " Items" +
            " where (PersonID = @PersonID)";


        /// <summary>
        /// sql to search for club members
        /// </summary>
        public static readonly string SqlSearchPeople = "Select " +
            " PersonID, FirstName as 'First Name', MiddleInitial as MI, LastName as 'Last Name', Address, City, State, Zip, Phone, ChurchHomeName 'Church Home', BirthDate, DateUpdated as 'Last Visit' " +
            " From Person Where (@FirstName is null or FirstName like @FirstName) {0} (@LastName is null or LastName like @LastName)";
            
            
            //(@FirstName is null or @FirstName like FirstName" + "%" + " ) {0} (@LastName is null or @LastName like LastName " + "%" + ")";

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
            " [Opinion] = @Opinion, [BirthDate] = @BirthDate, [ChurchHomeName] = @ChurchHomeName, [DateUpdated] = @DateUpdated, [ProofGuardianFlag] = @ProofGuardianFlag," +
            " [LockItemDate] = @LockItemDate, [LockItemFlag] = @LockItemFlag Where ([PersonID] = @ID)";

        public static readonly string sqlUpdateClubMemberDependent = "Update Dependents " +
            " Set [Name] = @Name, [BirthDate] = @BirthDate, [Relationship] = @Relationship, [LivesWith] = @LivesWith" +
            " Where ([PersonID] = @PersonID and [DependentID] = @DependentID)";

        /// <summary>
        /// sql to delete a club member record
        /// </summary>
        public static readonly string sqlDeleteClubMember = "Delete From ClubMember Where (Id = @Id)";
    }
}
