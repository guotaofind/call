'use strict';

const Bpmn = require('bpmn-engine');

const id = Math.floor(Math.random() * 10000);

return function (data, cb) {
    const engine = new Bpmn.Engine({
        name: 'execution example',
        source: data.processXml
    });

    engine.execute({
        variables: {
            id: id
        }
    }, (err, definition) => {
        cb(err, definition.getProcesses()[0].context.variables.id);
    });
}