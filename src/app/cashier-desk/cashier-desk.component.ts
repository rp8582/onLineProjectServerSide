import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ParamMap, Router, ActivatedRoute } from '@angular/router';
import Swal from 'sweetalert2';
import { TurnService } from '../turn.service';


@Component({
  selector: 'app-cashier-desk',
  templateUrl: './cashier-desk.component.html',
  styleUrls: ['./cashier-desk.component.scss']
})
export class CashierDeskComponent implements OnInit {
  serviceId: any;
  nextTurn: any;
  acceptFlag: boolean = false;
  showFiller = false;

  constructor(private http: HttpClient, private route: ActivatedRoute, private turnService: TurnService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.serviceId = +params['id']; // (+) converts string 'id' to a number         
      console.log(this.serviceId);
      this.turnService.getNextTurn(this.serviceId).subscribe((turn => {
        this.nextTurn = turn;
        console.log(this.nextTurn);
      }), (error => {
        Swal.fire('Oops...', error.error.Message, 'error')
      })

      )
    });
  }
  getTurn() {
    this.acceptFlag = true;
  }
  completedTurn(flag) {
    if (flag == "true") {
      this.turnService.completeTurn(this.nextTurn).subscribe((turn =>
       { console.log(turn);
        this.nextTurn = turn;
      }
      ));}
   this.acceptFlag=false; 
  }
}
