using PersonalDataWebAPI_CRUD.Model;
using Dapper;
using System.Data.SqlClient;

namespace PersonalDataWebAPI_CRUD.Repository
{
    public class PersonalBioRepository
    {
        public readonly string connectionString;


        public PersonalBioRepository()
        {

            connectionString = @"Data Source = DESKTOP-21TGVVO; Initial Catalog = PersonalData; Integrated Security = True";
        }


        // HTTP Get select method
        public List<PersonalDataModel> SelectAllPersonalData()

        {
            try
            {
                List<PersonalDataModel> ListofPersonalData = new List<PersonalDataModel>();

                var connection = new SqlConnection(connectionString);
                connection.Open();
                ListofPersonalData = connection.Query<PersonalDataModel>("exec SelectPersonalBio", connectionString).ToList();
                connection.Close();
                return ListofPersonalData;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Select personalmdata with id
        public List<PersonalDataModel> SelectPersonalDataWithID(int id)

        {
            try
            {
                List<PersonalDataModel> schoolDataSelect = new List<PersonalDataModel>();

                var connection = new SqlConnection(connectionString);
                connection.Open();
                schoolDataSelect = connection.Query<PersonalDataModel>($" exec selecteithID {id}; ").ToList();
                connection.Close();

                return schoolDataSelect;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }



        public void InsertPersonalData(PersonalDataModel bio)
        {
            try
            {

                SqlConnection connectionObject = new SqlConnection(connectionString);

                connectionObject.Open();
                connectionObject.Execute($"exec InsertPersonalBio '{bio.Name}', '{bio.LastName}',{bio.Age},'{bio.Address}' ");


                connectionObject.Close();

            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       



        public void ubdatePersonalData(PersonalDataModel bio)
        {
            try
            {
                SqlConnection connectionObject = new SqlConnection(connectionString);



                connectionObject.Open(); // Age = @Age, Address = @Address where id = @id

                connectionObject.Execute($"  exec UbdatePersonalBio '{bio.Name}','{bio.LastName}',{bio.Age},'{bio.Address}','{bio.id}' ");


                connectionObject.Close();
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeletePersonalDataCRUD(int del)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);


                con.Open();
                con.Execute($"exec DeletePersonalBio '{del}'");


                con.Close();
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
