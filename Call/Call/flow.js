const Bpmn = require('bpmn-engine');
const EventEmitter = require('events').EventEmitter;

let state;
let engine;
let result;
let listener = new EventEmitter();

//配置监听
listener.on('taken', (flow) => {
    result.flow = result.flow + ',' + flow.id;
});

engine.once('end', (definition) => {
    console.log(`User sirname is`);
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
    setTimeout(() => {
        const pending = engine.getPendingActivities();
        console.log(JSON.stringify(pending, null, 2));

        const task = pending.definitions[0].children.find(c => c.type === 'bpmn:UserTask');

        engine.signal(task.id);
    }, 300);
}
