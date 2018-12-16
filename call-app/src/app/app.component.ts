import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { FormArray } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'call-app';
  favoriteColorControl = new FormControl('');
}
string   ss = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
  "  <definitions xmlns=\"http://www.omg.org/spec/BPMN/20100524/MODEL\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\n" +
  "  <process id=\"theProcess2\" isExecutable=\"true\">\n" +
  "    <startEvent id=\"theStart\" />\n" +
  "    <exclusiveGateway id=\"decision\" default=\"flow2\" />\n" +
  "    <endEvent id=\"end1\" />\n" +
  "    <endEvent id=\"end2\" />\n" +
  "    <sequenceFlow id=\"flow1\" sourceRef=\"theStart\" targetRef=\"decision\" />\n" +
  "    <sequenceFlow id=\"flow2\" sourceRef=\"decision\" targetRef=\"end1\" />\n" +
  "    <sequenceFlow id=\"flow3\" sourceRef=\"decision\" targetRef=\"end2\">\n" +
  "      <conditionExpression>true</conditionExpression>\n" +
  "    </sequenceFlow>\n" +
  "  </process>\n" +
  "</definitions>"
