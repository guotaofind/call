using Call.Models;
using EdgeJs;
using Newtonsoft.Json;
using System;
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
            value.level = 100;
            value.cashAmount = 10000;

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
    result = {
        sum: ''
    };
    engine = new Bpmn.Engine({
        source: data.FlowBpmn,
        moddleOptions: {
            camunda: require('camunda-bpmn-moddle/resources/camunda')
        }
    });
    if (data.resume) {
        engine = Bpmn.Engine.resume(state, {
            listener: listener
        });
    }
    else {
        // 基本执行
        engine.execute({
            variables:
            {
                manager: data.variables,
                sum: data.variables
            }
        }, (err, definition) => {
            if (err) cb(err, null);
            result.sum =  20;
            cb(err, result);
        });
    }
    setTimeout(() => {
        const pending = engine.getPendingActivities();
    }, 300);
}");
            var cb = func(workFlow).Result;
            string json = JsonConvert.SerializeObject(cb);
            Result result = JsonConvert.DeserializeObject<Result>(json);
            //Result result = func(workFlow).Result as Result;
            return new State();
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
