using CommonLib.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CommonLib.Models.Response;

namespace RSSDal
{
    public class RSSFeedDal
    {
        private readonly string SqlConnection = "Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = RSSFeedStorage; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";



        public async Task<List<FeedCollection>> GetAllSavedFeed()
        {
            List<FeedCollection> response;
            using (SqlConnection con = new SqlConnection(SqlConnection))
            {
                response = con.Query<FeedCollection>("select Id, FeedURL,Name from RSSFeed").AsList();
            }
            return response;
        }

        public async Task<SimpleResponse> InsertRSS(InsertRSS request)
        {
            SimpleResponse response = new SimpleResponse();
            response.IsSuccess = true;
            try
            {
                string query = string.Format("Insert into RSSFeed (FeedURL, Name) values('{0}','{1}')", request.URL, request.Name);
                using (SqlConnection con = new SqlConnection(SqlConnection))
                {
                   var result=  con.QueryAsync(query).Result;
                }
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.error = e.Message;
            }
            return response;

           
        }

        public async Task<SimpleResponse> DeleteRSS(int id)
        {
            SimpleResponse response = new SimpleResponse();
            response.IsSuccess = true;
            try
            {
                string query = string.Format("Delete from RSSFeed where id ={0}", id);
                using(SqlConnection con= new SqlConnection(SqlConnection))
                {
                    var result = con.QueryAsync(query).Result;
                }

            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.error = e.Message;

            }
            return response;
        }

    }
}
