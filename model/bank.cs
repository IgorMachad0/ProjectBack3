using System.Data.SqlClient;
using projetoWEB_SA3.classes;

class Bank
{

    public string message="Hello!";

    private List<Customer> list = new List<Customer>();
    public List<Customer> getList()
    {
        return list;
    }

    public void loadData()
    {
        
        try{

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(

                "User ID=sa;Password=1234;"+
                "Server=localhost\\SQLEXPRESS;"+
                "Database=projectclients;"+
                "Trusted_Connection=False;"
            );

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                string sql = "Select * from Clients";

                using(SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    using(SqlDataReader table = cmd.ExecuteReader())
                    {
                        while(table.Read())
                        {
                            //Console.WriteLine(table["name"]);
                            list.Add(new Customer(){
                            id = Convert.ToInt32(table["id"]),
                            name = table["name"].ToString(),
                            });
                        }
                    }
                }
            }
        }catch(Exception e){

            Console.WriteLine("Error fff: " + e.ToString());
        }

    }
}