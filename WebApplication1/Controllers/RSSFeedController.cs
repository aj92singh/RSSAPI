using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using CommonLib.Models;
using Microsoft.AspNetCore.Mvc;
using RSSDal;
using static CommonLib.Models.Response;

namespace RSSWebAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class RSSFeedController : ControllerBase
    {
        RSSFeedDal dal = new RSSFeedDal();

        [HttpPost]
        public async Task<List<FeedData>> ReadFeed(ReadFeed request)
        {
            List<FeedData> response = new List<FeedData>();


            XmlReader reader = XmlReader.Create(request.URL);

            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            foreach (SyndicationItem item in feed.Items)
            {
                response.Add(new FeedData
                {
                    Title = item.Title.Text,
                    Summary = item.Summary.Text,
                    URL = item.Id

                }); ; ;
            }


            return response;

        }

        [HttpGet]
        public async Task<List<FeedCollection>> GetAllRSS()
        {
            return await dal.GetAllSavedFeed();
        }

        [HttpPost]
        public async Task<SimpleResponse> InsertRSS(InsertRSS request)
        {
            return await dal.InsertRSS(request);
        }

        [HttpDelete]
        public async Task<SimpleResponse> DeleteRSS(int id)
        {
            return await dal.DeleteRSS(id);
        }
    }
}