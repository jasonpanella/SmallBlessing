// -----------------------------------------------------------------------
// <copyright file="ClubMemberAccess.cs" company="John">
// Socia Member club Demo ©2013
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Data;
using System.Data.OleDb;
using SmallBlessing.Data.DataModel;
using SmallBlessing.Data.Sql;
using System.Data.SqlClient;
using System.Transactions;

namespace SmallBlessing.Data.DataAccess
{


    /// <summary>
    /// Data access class for ClubMember table
    /// </summary>
    public class ClubMemberAccess : ConnectionAccess, IClubMemberAccess
    {

        /// <summary>
        /// Method to get all club members
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetAllClubMembers()
        {
            DataTable dataTable = new DataTable();

            //DataSet DS = new DataSet();
            SqlDataAdapter xDA = new SqlDataAdapter();

            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Scripts.SqlGetAllClubMembers, cnn))
                {

                    // Assign the SQL to the command object
                    cmd.CommandType = CommandType.Text;

                    // Fill the datatable from adapter

                    xDA.SelectCommand = cmd;
                    xDA.SelectCommand.Connection = cnn;
                    xDA.Fill(dataTable);

                }

            }
            return dataTable;
        }


        public DataTable GetClubMemberItemsById(int id)
        {
            DataTable dataTable = new DataTable();

            //DataSet DS = new DataSet();
            SqlDataAdapter xDA = new SqlDataAdapter();

            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Scripts.SqlGetPersonItems, cnn))
                {

                    // Assign the SQL to the command object
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@PersonID", id);
                    // Fill the datatable from adapter

                    xDA.SelectCommand = cmd;
                    xDA.SelectCommand.Connection = cnn;
                    xDA.Fill(dataTable);

                }

            }
            return dataTable;
        }

        /// <summary>
        /// Method to get club member by Id
        /// </summary>
        /// <param name="id">member id</param>
        /// <returns>Data row</returns>
        public DataRow GetClubMemberById(int id)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    // Set the command object properties
                    cmd.Connection = conn;
                    // Assign the SQL to the command object
                    cmd.CommandText = Scripts.sqlGetClubMemberById;

                    // Add the input parameters to the parameter collection
                    cmd.Parameters.AddWithValue("@PersonID", id);

                    // Open the connection, execute the query and close the connection
                    cmd.Connection.Open();

                    SqlDataAdapter dataAdapt = new SqlDataAdapter();
                    dataAdapt.SelectCommand = cmd;
                    dataAdapt.Fill(dataTable);

                    // Get the datarow from the table
                    dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                    cmd.Connection.Close();
                    return dataRow;
                }

            }
        }

        /// <summary>
        /// Method to get club member by Id
        /// </summary>
        /// <param name="id">member id</param>
        /// <returns>Data row</returns>
        public DataRow GetFullClubMemberById(int id)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    // Set the command object properties
                    cmd.Connection = conn;
                    // Assign the SQL to the command object
                    cmd.CommandText = Scripts.sqlGetFullClubMemberById;

                    // Add the input parameters to the parameter collection
                    cmd.Parameters.AddWithValue("@PersonID", id);

                    // Open the connection, execute the query and close the connection
                    cmd.Connection.Open();

                    SqlDataAdapter dataAdapt = new SqlDataAdapter();
                    dataAdapt.SelectCommand = cmd;
                    dataAdapt.Fill(dataTable);

                    // Get the datarow from the table
                    dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                    cmd.Connection.Close();
                    return dataRow;
                }

            }
        }

        public DataTable GetDependents(int PersonID)
        {
            DataTable dataTable = new DataTable();

            //DataSet DS = new DataSet();
            SqlDataAdapter xDA = new SqlDataAdapter();

            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Scripts.sqlGetDependentsById, cnn))
                {

                    // Assign the SQL to the command object
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    //cmd.Parameters.AddWithValue("@DependentID", DependentID);
                    // Fill the datatable from adapter

                    xDA.SelectCommand = cmd;
                    xDA.SelectCommand.Connection = cnn;
                    xDA.Fill(dataTable);
                }

            }
            return dataTable;           
        }

        public DataTable GetClubMembertoExport(int days)
        {
            DataTable dataTable = new DataTable();

            //DataSet DS = new DataSet();
            SqlDataAdapter xDA = new SqlDataAdapter();

            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Scripts.SqlGetAllClubMembersToExport, cnn))
                {

                    // Assign the SQL to the command object
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DaysToExport", days);
                    //cmd.Parameters.AddWithValue("@DependentID", DependentID);
                    // Fill the datatable from adapter

                    xDA.SelectCommand = cmd;
                    xDA.SelectCommand.Connection = cnn;
                    xDA.Fill(dataTable);
                }

                using (SqlCommand cmd = new SqlCommand(Scripts.SqlUpdateClubMembersExportFlag, cnn))
                {
                    cnn.Open();
                    // Assign the SQL to the command object
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DaysToExport", days);
                    //cmd.Parameters.AddWithValue("@DependentID", DependentID);
                    // Fill the datatable from adapter

                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }


            }
            return dataTable; 

        }


        /// <summary>
        /// Method to search club members by multiple parameters
        /// </summary>
        /// <param name="occupation">occupation value</param>
        /// <param name="maritalStatus">marital status</param>
        /// <param name="operand">AND OR operand</param>
        /// <returns>Data table</returns>
        /// 

        //public DataTable SearchClubMembers(object occupation, object maritalStatus, string operand)
        public DataTable SearchClubMembers(string firstName, string lastName, string operand)
        {
            DataTable dataTable = new DataTable();
            firstName = string.Concat(firstName, '%');
            lastName = string.Concat(lastName, '%');


            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    // Set the command object properties
                    cmd.Connection = conn;
                    // Assign the SQL to the command object
                    cmd.CommandText = string.Format(Scripts.SqlSearchPeople, operand);

                    // Add the input parameters to the parameter collection
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);

                    // Open the connection, execute the query and close the connection
                    cmd.Connection.Open();

                    SqlDataAdapter dataAdapt = new SqlDataAdapter();
                    dataAdapt.SelectCommand = cmd;
                    dataAdapt.Fill(dataTable);

                    cmd.Connection.Close();

                }

            }
            return dataTable;
        }



        /// <summary>
        /// Method to add new member
        /// </summary>
        /// <param name="clubMember">club member model</param>
        /// <returns>true or false</returns>
        //public bool AddClubMember(ClubMemberModel clubMember)
        public bool AddPerson(PersonModel person)
        {
            var rowsAffected = 0;
            var id = 0;
            //SqlTransaction transaction;
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            // Set the command object properties
                            cmd.Connection = conn;
                            cmd.CommandText = Scripts.SqlInsertPerson;

                            // Add the input parameters to the parameter collection
                            cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
                            cmd.Parameters.AddWithValue("@LastName", person.LastName);
                            cmd.Parameters.AddWithValue("@MiddleInitial", person.MiddleIntial);
                            cmd.Parameters.AddWithValue("@Address", person.Address);
                            cmd.Parameters.AddWithValue("@Phone", person.PhoneNumber);
                            cmd.Parameters.AddWithValue("@ChurchHomeFlag", person.ChurchHome);
                            cmd.Parameters.AddWithValue("@ChurchHomeName", person.ChurchName);
                            cmd.Parameters.AddWithValue("@Opinion", person.Opinion);
                            cmd.Parameters.AddWithValue("@BirthDate", person.DateOfBirth);
                            cmd.Parameters.AddWithValue("@PhoneContactFlag", person.LeaveMessage);
                            cmd.Parameters.AddWithValue("@City", person.City);
                            cmd.Parameters.AddWithValue("@State", person.State);
                            cmd.Parameters.AddWithValue("@Zip", person.Zip);
                            cmd.Parameters.AddWithValue("@ProofGuardianFlag", person.ProofGuardianFlag);

                            id = (int)(decimal)cmd.ExecuteScalar();
                            rowsAffected = 1;                            
                        }

                        //throw new Exception("Let see...");

                        foreach (DependentModel dm in person.DependentModelList)
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.Connection = conn;
                                cmd.CommandText = Scripts.SqlInsertDependent;

                                // Add the input parameters to the parameter collection
                                cmd.Parameters.AddWithValue("@Name", dm.NameOfChild);
                                cmd.Parameters.AddWithValue("@Relationship", dm.Relationship);
                                cmd.Parameters.AddWithValue("@LivesWith", dm.ChildLivesWith);
                                cmd.Parameters.AddWithValue("@PersonID", id);
                                cmd.Parameters.AddWithValue("@BirthDate", dm.BirthDate);

                                rowsAffected = cmd.ExecuteNonQuery();
                            }
                        }
                        
                        ts.Complete();
                        
                    }
                }
            }
            catch { 
            //todo: add error handling
            
            }
            return rowsAffected > 0;
        }

        public int GetClubMemberVisits(int personID)
        {
            //var rowsAffected = 0;
            var id = 0;
            //SqlTransaction transaction;
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            // Set the command object properties
                            cmd.Connection = conn;
                            cmd.CommandText = Scripts.SqlGetClubMemberVisits;

                            // Add the input parameters to the parameter collection
                            cmd.Parameters.AddWithValue("@PersonID", personID);
                            //rowsAffected = cmd.ExecuteNonQuery();
                            id = (int)cmd.ExecuteScalar();
                            var rowsAffected = cmd.ExecuteNonQuery();
                            //rowsAffected = 1;
                        }
                      
                        ts.Complete();

                    }
                }
            }
            catch
            {
                //todo: add error handling

            }
            return id;
        }

        public bool AddDependent(DependentModel dependent)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    // Set the command object properties
                    cmd.Connection = conn;
                    cmd.CommandText = Scripts.SqlInsertDependent;

                    // Add the input parameters to the parameter collection
                    cmd.Parameters.AddWithValue("@Name", dependent.NameOfChild);
                    cmd.Parameters.AddWithValue("@Relationship", dependent.Relationship);
                    cmd.Parameters.AddWithValue("@LivesWith", dependent.ChildLivesWith);
                    cmd.Parameters.AddWithValue("@PersonID", dependent.PersonID);
                    cmd.Parameters.AddWithValue("@BirthDate", dependent.BirthDate);

                    // Open the connection, execute the query and close the connection
                    cmd.Connection.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    return rowsAffected > 0;
                }


            }
        }

        /// <summary>
        /// Method to update club member
        /// </summary>
        /// <param name="clubMember">club member</param>
        /// <returns>true / false</returns>
        public bool UpdateClubMember(PersonModel person)
        {
            var rowsAffected = 0;
            var memberID = person.PersonID;
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {

                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            // Set the command object properties
                            cmd.Connection = conn;
                            cmd.CommandText = Scripts.sqlUpdateClubMember;

                            // Add the input parameters to the parameter collection
                            cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
                            cmd.Parameters.AddWithValue("@LastName", person.LastName);
                            cmd.Parameters.AddWithValue("@MiddleInitial", person.MiddleIntial);
                            cmd.Parameters.AddWithValue("@Address", person.Address);
                            cmd.Parameters.AddWithValue("@Phone", person.PhoneNumber);
                            cmd.Parameters.AddWithValue("@ChurchHomeFlag", person.ChurchHome);
                            cmd.Parameters.AddWithValue("@ChurchHomeName", person.ChurchName);
                            cmd.Parameters.AddWithValue("@Opinion", person.Opinion);
                            cmd.Parameters.AddWithValue("@BirthDate", person.DateOfBirth);
                            cmd.Parameters.AddWithValue("@PhoneContactFlag", person.LeaveMessage);
                            cmd.Parameters.AddWithValue("@City", person.City);
                            cmd.Parameters.AddWithValue("@State", person.State);
                            cmd.Parameters.AddWithValue("@Zip", person.Zip);
                            cmd.Parameters.AddWithValue("@ID", person.PersonID);
                            cmd.Parameters.AddWithValue("@DateUpdated", person.DateUpdated);
                            cmd.Parameters.AddWithValue("@ProofGuardianFlag", person.ProofGuardianFlag);
                            cmd.Parameters.AddWithValue("@LockItemDate", person.LockItemsDate);
                            // Open the connection, execute the query and close the connection
                            //cmd.Connection.Open();
                            rowsAffected = cmd.ExecuteNonQuery();
                            //cmd.Connection.Close();
                            
                        }

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            // Set the command object properties
                            cmd.Connection = conn;
                            cmd.CommandText = Scripts.SqlDeleteDependent;

                            // Add the input parameters to the parameter collection
                            cmd.Parameters.AddWithValue("@PersonID", person.PersonID);
                            // Open the connection, execute the query and close the connection
                            rowsAffected = cmd.ExecuteNonQuery();

                        }

                        foreach (DependentModel dm in person.DependentModelList)
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.Connection = conn;
                                cmd.CommandText = Scripts.SqlInsertDependent;

                                // Add the input parameters to the parameter collection
                                cmd.Parameters.AddWithValue("@Name", dm.NameOfChild);
                                cmd.Parameters.AddWithValue("@Relationship", dm.Relationship);
                                cmd.Parameters.AddWithValue("@LivesWith", dm.ChildLivesWith);
                                cmd.Parameters.AddWithValue("@PersonID", memberID);
                                cmd.Parameters.AddWithValue("@BirthDate", dm.BirthDate);
                                cmd.Parameters.AddWithValue("@DependentID", dm.DependentID);

                                rowsAffected = cmd.ExecuteNonQuery();
                            }
                        }

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            // Set the command object properties
                            cmd.Connection = conn;
                            cmd.CommandText = Scripts.SqlDeleteItems;

                            // Add the input parameters to the parameter collection
                            cmd.Parameters.AddWithValue("@PersonID", person.PersonID);
                            // Open the connection, execute the query and close the connection
                            rowsAffected = cmd.ExecuteNonQuery();
                        }

                        foreach (ItemModel dm in person.ItemModelList)
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.Connection = conn;
                                cmd.CommandText = Scripts.SqlInsertItems;

                                // Add the input parameters to the parameter collection
                                cmd.Parameters.AddWithValue("@Comments", dm.Comments);
                                cmd.Parameters.AddWithValue("@Date", dm.Date);
                                cmd.Parameters.AddWithValue("@Description", dm.Description);
                                cmd.Parameters.AddWithValue("@PersonID", memberID);
                                cmd.Parameters.AddWithValue("@Initials", dm.Initials);
                                
                                //cmd.Parameters.AddWithValue("@DependentID", dm.DependentID);

                                rowsAffected = cmd.ExecuteNonQuery();
                            }
                        }


                        rowsAffected = 1;
                        ts.Complete();
                    }
                }
            }
            catch
            { 

            }
            return rowsAffected > 0;
        }

        /// <summary>
        /// Method to delete a club member
        /// </summary>
        /// <param name="id">member id</param>
        /// <returns>true / false</returns>
        public bool DeleteClubMember(int id)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlDeleteClubMember;

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@Id", id);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }
    }
}
