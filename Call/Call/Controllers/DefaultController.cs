using Call.Models;
using EdgeJs;
using System.Linq;
using System.Web.Http;

namespace Call.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public string Get()
        {
            string flowBpmn = "";
            using (var db = new IndexERPContext())
            {
                //var flow = new Flow { name = "flow", flow_bpmn = @"asdf", flow_js = @"ddd" };
                //db.Flows.Add(flow);
                //db.SaveChanges();
                
                var query = from b in db.Flows where b.name == "1002" select b;
                foreach (var item in query.ToList())
                {
                    flowBpmn = item.flow_bpmn;
                }
            }

            var func = Edge.Func(@"const Bpmn = require('bpmn-engine');
const EventEmitter = require('events').EventEmitter;
const fs = require('fs');

let state;
let engine;
// 开始执行
function centerExe(variables, callback) {
    const listener = new EventEmitter();
    // 流程执行的线
    listener.on('taken', (flow) => {
        if (callback instanceof Function) {
            callback(flow.id);
        }
    });
    // 基本执行
    engine.execute({
        variables: variables,
        listener: listener
    }, (err, definition) => {
        if (err) {
            callback('error');
        };
        console.log('Bpmn definition definition started with id', definition.getProcesses()[0].context.variables.sum);
    });
}
// 中间节点执行
function centerExe(state, variables, callback) {
    const listener = new EventEmitter();
    listener.once('wait-UserTask_1fis4zu', (child, instance) => {
        console.log(child.activity.id);
        instance.signal(child.activity.id, {
            sirname: 'von Rosen'
        });
    });
    // 流程执行的线
    listener.on('taken', (flow) => {
        if (callback instanceof Function) {
            callback(flow.id);
        }
        console.log(flow.id);
    });
    const engine = Bpmn.Engine.resume(state, {
        listener: listener
    });
}
// 停止
function exe() {
    const listener = new EventEmitter();
    listener.once('wait-UserTask_1fis4zu', (child, instance) => {
        // engine.stop();
        state = engine.getState();
        instance.signal(child.activity.id, {
            sirname: 'von Rosen'
        });
    });
    listener.once('wait-UserTask_09l4c4c', (child, instance) => {
        state = engine.getState();
        console.log(`task <${child.activity.id}> was taken`);
        instance.signal(child.activity.id, {
            sirname: '333'
        });
    });

    // 流程执行的线
    listener.on('taken', (flow) => {
        console.log(`flow <${flow.id}> was taken`);
    });
    engine.once('start', (definition) => {
        console.log(`User sirname is`);
    });
    engine.once('end', (definition) => {
        console.log(`User sirname is`);
    });

    const variables = {
        manager: 90,
        sum: 100
    };

    // 基本执行
    engine.execute({
        variables: variables,
        listener: listener
    }, (err, definition) => {
        if (err) throw err;
        console.log('Bpmn definition definition started with id', definition.getProcesses()[0].context.variables.sum);
    });
}
return function (data, cb) {
    engine = new Bpmn.Engine({
        source: data.processXml,
        moddleOptions: {
            camunda: require('camunda-bpmn-moddle/resources/camunda')
        }
    });
    // 基本执行
    engine.execute({
        variables: 
        {manager:data.variables,
        sum: 100}
    }, (err, definition) => {

        cb(err, 'Bpmn definition definition started with id' + definition.getProcesses()[0].context.variables.sum);
    });
}");
            return func(new { processXml = flowBpmn, variables = 50}).Result.ToString();

            //return new Value
            //{
            //    workflowId = "oa",
            //    level = 100,
            //    userName = "chengt",
            //    cashAmount = 10000
            //};
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
