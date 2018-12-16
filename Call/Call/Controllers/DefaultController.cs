using Call.Models;
using System.Linq;
using System.Web.Http;

namespace Call.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public Value Get()
        {
            //using (var db = new IndexERPContext())
            //{
            //    var flow = new Flow {name = "flow", flow_bpmn = @"asdf", flow_js = @"ddd" };
            //    db.Flows.Add(flow);
            //    db.SaveChanges();
            //    var query = from b in db.Flows select b;
            //    foreach (var item in query.ToList())
            //    {
            //        string sss = item.flow_bpmn;
            //    }
            //}

            //var func = Edge.Func(File.ReadAllText("flow.js"));
            //return func(new
            //{
            //    processXml = File.ReadAllText("flow.bpmn")
            //}).Result.ToString();
            return new Value
            {
                workflowId = "oa",
                level = 100,
                userName = "chengt",
                cashAmount = 10000
            };
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
