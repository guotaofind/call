'use strict';

const Bpmn = require('bpmn-engine');
const EventEmitter = require('events').EventEmitter;

const definitionSource = `
<?xml version="1.0" encoding="UTF-8"?>
<definitions xmlns="http://www.omg.org/spec/BPMN/20100524/MODEL" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:bpmndi="http://www.omg.org/spec/BPMN/20100524/DI" xmlns:omgdc="http://www.omg.org/spec/DD/20100524/DC" xmlns:omgdi="http://www.omg.org/spec/DD/20100524/DI" xmlns:camunda="http://camunda.org/schema/1.0/bpmn" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:flowable="http://flowable.org/bpmn" targetNamespace="http://www.flowable.org/processdef">
  <collaboration id="Collaboration_16ho7mw">
    <participant id="Participant_1dmywp9" processRef="Process_1" />
  </collaboration>
  <process id="Process_1" isExecutable="true">
    <startEvent id="StartEvent_1" name="申请人">
      <outgoing>SequenceFlow_1ot4igx</outgoing>
    </startEvent>
    <userTask id="UserTask_1fis4zu" name="上级领导" camunda:assignee="sjld">
      <incoming>SequenceFlow_1ot4igx</incoming>
      <incoming>SequenceFlow_1bd25y3</incoming>
      <outgoing>SequenceFlow_01zld5a</outgoing>
    </userTask>
    <exclusiveGateway id="ExclusiveGateway_0v2hpl9">
      <incoming>SequenceFlow_01zld5a</incoming>
      <outgoing>SequenceFlow_145unte</outgoing>
      <outgoing>SequenceFlow_1bd25y3</outgoing>
    </exclusiveGateway>
    <userTask id="UserTask_09l4c4c" name="中心总监" camunda:assignee="zxzj">
      <incoming>SequenceFlow_145unte</incoming>
      <outgoing>SequenceFlow_09dbpb9</outgoing>
    </userTask>
    <userTask id="UserTask_0ytm91g" name="财务经理" camunda:assignee="cwjl">
      <incoming>SequenceFlow_09dbpb9</incoming>
      <outgoing>SequenceFlow_0xz9m3i</outgoing>
    </userTask>
    <userTask id="UserTask_1p6t0tx" name="总经理" camunda:assignee="zjl">
      <incoming>SequenceFlow_0b4ks7z</incoming>
      <incoming>SequenceFlow_1gftu34</incoming>
      <outgoing>SequenceFlow_0sunund</outgoing>
    </userTask>
    <exclusiveGateway id="ExclusiveGateway_0635stq">
      <incoming>SequenceFlow_0xz9m3i</incoming>
      <outgoing>SequenceFlow_1gnf0h3</outgoing>
      <outgoing>SequenceFlow_0b4ks7z</outgoing>
    </exclusiveGateway>
    <userTask id="UserTask_0agqui6" name="财务总监" camunda:assignee="cwzj">
      <incoming>SequenceFlow_1gnf0h3</incoming>
      <outgoing>SequenceFlow_1gftu34</outgoing>
    </userTask>
    <parallelGateway id="ExclusiveGateway_0yry08p">
      <incoming>SequenceFlow_0sunund</incoming>
      <outgoing>SequenceFlow_06aiog3</outgoing>
      <outgoing>SequenceFlow_0j1rz6u</outgoing>
    </parallelGateway>
    <userTask id="UserTask_0o1k9vf" name="会计" camunda:assignee="kj">
      <incoming>SequenceFlow_0j1rz6u</incoming>
      <outgoing>SequenceFlow_01u7fx2</outgoing>
    </userTask>
    <userTask id="UserTask_0dryav8" name="出纳" camunda:assignee="cn">
      <incoming>SequenceFlow_06aiog3</incoming>
      <outgoing>SequenceFlow_0ldzapz</outgoing>
    </userTask>
    <parallelGateway id="ExclusiveGateway_18cgx7h">
      <incoming>SequenceFlow_01u7fx2</incoming>
      <incoming>SequenceFlow_0ldzapz</incoming>
      <outgoing>SequenceFlow_0zi7hka</outgoing>
    </parallelGateway>
    <userTask id="UserTask_1vqa3hz" name="会计确认" camunda:assignee="kjqr">
      <incoming>SequenceFlow_0zi7hka</incoming>
      <outgoing>SequenceFlow_1q5zute</outgoing>
    </userTask>
    <endEvent id="EndEvent_1lfnxm7" name="归档">
      <incoming>SequenceFlow_1q5zute</incoming>
    </endEvent>
    <sequenceFlow id="SequenceFlow_1ot4igx" sourceRef="StartEvent_1" targetRef="UserTask_1fis4zu" />
    <sequenceFlow id="SequenceFlow_01zld5a" sourceRef="UserTask_1fis4zu" targetRef="ExclusiveGateway_0v2hpl9">

    </sequenceFlow>
    <sequenceFlow id="SequenceFlow_145unte" sourceRef="ExclusiveGateway_0v2hpl9" targetRef="UserTask_09l4c4c">
     <conditionExpression xsi:type="tFormalExpression" language="JavaScript">
            <![CDATA[this.variables.level >= 80]]>
      </conditionExpression>
    </sequenceFlow>
    <sequenceFlow id="SequenceFlow_09dbpb9" sourceRef="UserTask_09l4c4c" targetRef="UserTask_0ytm91g" />
    <sequenceFlow id="SequenceFlow_0xz9m3i" sourceRef="UserTask_0ytm91g" targetRef="ExclusiveGateway_0635stq" />
    <sequenceFlow id="SequenceFlow_1gnf0h3" name="" sourceRef="ExclusiveGateway_0635stq" targetRef="UserTask_0agqui6">
      <conditionExpression xsi:type="tFormalExpression" language="JavaScript">
        <![CDATA[this.variables.cashAmount < 10000]]>
      </conditionExpression>
    </sequenceFlow>
    <sequenceFlow id="SequenceFlow_0b4ks7z" name="" sourceRef="ExclusiveGateway_0635stq" targetRef="UserTask_1p6t0tx">
      <conditionExpression xsi:type="tFormalExpression" language="JavaScript">
        <![CDATA[this.variables.cashAmount >= 10000]]>
      </conditionExpression>
    </sequenceFlow>
    <sequenceFlow id="SequenceFlow_1gftu34" sourceRef="UserTask_0agqui6" targetRef="UserTask_1p6t0tx" />
    <sequenceFlow id="SequenceFlow_0sunund" sourceRef="UserTask_1p6t0tx" targetRef="ExclusiveGateway_0yry08p" />
    <sequenceFlow id="SequenceFlow_06aiog3" sourceRef="ExclusiveGateway_0yry08p" targetRef="UserTask_0dryav8" />
    <sequenceFlow id="SequenceFlow_0j1rz6u" sourceRef="ExclusiveGateway_0yry08p" targetRef="UserTask_0o1k9vf" />
    <sequenceFlow id="SequenceFlow_01u7fx2" sourceRef="UserTask_0o1k9vf" targetRef="ExclusiveGateway_18cgx7h" />
    <sequenceFlow id="SequenceFlow_0ldzapz" sourceRef="UserTask_0dryav8" targetRef="ExclusiveGateway_18cgx7h" />
    <sequenceFlow id="SequenceFlow_0zi7hka" sourceRef="ExclusiveGateway_18cgx7h" targetRef="UserTask_1vqa3hz" />
    <sequenceFlow id="SequenceFlow_1q5zute" sourceRef="UserTask_1vqa3hz" targetRef="EndEvent_1lfnxm7" />
    <sequenceFlow id="SequenceFlow_1bd25y3" sourceRef="ExclusiveGateway_0v2hpl9" targetRef="UserTask_1fis4zu">
     <conditionExpression xsi:type="tFormalExpression" language="JavaScript">
       <![CDATA[this.variables.level < 80]]>
      </conditionExpression>
    </sequenceFlow>
  </process>
</definitions>
    `;

const engine = new Bpmn.Engine({
    name: 'Pending game',
    source: definitionSource,
    moddleOptions: {
        camunda: require('camunda-bpmn-moddle/resources/camunda')
    }
});

const listener = new EventEmitter();

engine.execute({
    listener: listener
}, (err, execution) => {
    if (err) throw err;
});

setTimeout(() => {
    const pending = engine.getPendingActivities();
    console.log(JSON.stringify(pending, null, 2));

}, 300);