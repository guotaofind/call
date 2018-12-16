using System.Linq;
using System.Web.Http;

namespace Call.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public string Get()
        {
            using (var db = new IndexERPContext())
            {
                var flow = new Flowttt { Id = 2, flow_bpmn = @"", flow_js = @"" };
                db.Flows.Add(flow);
                db.SaveChanges();
                var query = from b in db.Flows select b;
                foreach (var item in query.ToList())
                {
                    string sss = item.flow_bpmn;
                }
            }

            //var func = Edge.Func(File.ReadAllText("flow.js"));
            //return func(new
            //{
            //    processXml = File.ReadAllText("flow.bpmn")
            //}).Result.ToString();
            return "";
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
