using Call.Models;
using EdgeJs;
using System.Linq;
using System.Web.Http;

namespace Call.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public State Get(Value value)
        {
            //测试数据
            value = new Value();
            value.flowId = "2";
            value.workflowId = "1000";
            WorkFlow workFlow;
            using (var db = new IndexERPContext())
            {
                //获取流程状态
                workFlow = db.WorkFlows.SingleOrDefault(p => p.Name == value.workflowId);
                if (workFlow == null)
                {
                    workFlow = new WorkFlow();
                    workFlow.Name = value.workflowId;
                    workFlow.Resume = false;
                }
                else
                {
                    workFlow.Resume = true;
                }
                //获取流程图
                Flow flow = db.Flows.Single(p => p.Name == value.flowId);
                workFlow.FlowBpmn = flow.FlowBpmn;
            }
            workFlow.Level = value.level;
            workFlow.CashAmount = value.cashAmount;
            var func = Edge.Func(@"const Bpmn = require('bpmn-engine');
const EventEmitter = require('events').EventEmitter;

let state;
let engine;
let result;
let listener = new EventEmitter();

//配置监听
listener.on('taken', (flow) => {
    result.flow = result.flow + ',' + flow.id;
});
listener.once('wait', (activity) => {
    engine.signal(activity.id);
});
return function (data, cb) {
    engine = new Bpmn.Engine({
        source: data.processXml,
        moddleOptions: {
            camunda: require('camunda-bpmn-moddle/resources/camunda')
        }
    });
    if (cb.resume) {
        engine = Bpmn.Engine.resume(state, {
            listener: listener
        });
    }
    else {
        // 基本执行
        engine.execute({
            variables:
            {
                manager: data.variables
            }
        }, (err, definition) => {
            if (err) cb(err, null);
            cb(err, 'Bpmn definition definition started with id' + definition.getProcesses()[0].context.variables.sum);
        });
    }
    engine.signal(data.activityId);
    setTimeout(() => {
        const pending = engine.getPendingActivities();
        console.log(JSON.stringify(pending, null, 2));

        const task = pending.definitions[0].children.find(c => c.type === 'bpmn:UserTask');
        
        engine.signal(task.id);
    }, 300);
}");
            State state = (State)func(workFlow).Result;
            return state;
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
