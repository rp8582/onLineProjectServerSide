import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { TurnService } from '../turn.service';


@Component({
  selector: 'app-get-turn',
  templateUrl: './get-turn.component.html',
  styleUrls: ['./get-turn.component.scss']
})
export class GetTurnComponent implements OnInit {
  @Input() turn: any;
  @Output()finishTurn = new EventEmitter<any>();
  constructor(private turnService:TurnService) { }

  ngOnInit(): void {
  }

  completeTurn() {
    this.finishTurn.emit("true");
   }
  

}
