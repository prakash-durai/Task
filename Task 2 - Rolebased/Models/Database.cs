using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;

namespace Rolebased.Models{
    public class Database{
        public static bool Login(LoginModel loginModel){
            SqlConnection connection = new SqlConnection(getConnection());
            connection.Open();
            SqlCommand sqlcommand = new SqlCommand($"select count(*) from UserTable where Username=@username and Password=@password",connection);
            sqlcommand.Parameters.Add("@username",sqlDbType:System.Data.SqlDbType.VarChar).Value = loginModel.Username;
            sqlcommand.Parameters.Add("@password",sqlDbType:System.Data.SqlDbType.VarChar).Value = loginModel.Password;
            if(Convert.ToInt32(sqlcommand.ExecuteScalar())==1){
                    return true;
                }
            return false;
        }
        public static string? GetRole(LoginModel loginModel){
            using(SqlConnection connection = new SqlConnection(getConnection())){
            connection.Open();
            SqlCommand sqlcommand = new SqlCommand($"select Role from UserTable where Username=@username",connection);
            sqlcommand.Parameters.Add("@username",sqlDbType:System.Data.SqlDbType.VarChar).Value = loginModel.Username;
            string? role = Convert.ToString(sqlcommand.ExecuteScalar());
            return role;  
        }
        }
        public static string? getConnection(){
            var build = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",optional:true,reloadOnChange:true);
            IConfiguration configuration = build.Build();
            string? connectionString = Convert.ToString(configuration.GetConnectionString("dbConnection"));
            return connectionString;
        }
    }
}