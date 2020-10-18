import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2'
import { Router } from '@angular/router';
@Component({
  selector: 'app-cashier-login',
  templateUrl: './cashier-login.component.html',
  styleUrls: ['./cashier-login.component.scss']
})
export class CashierLoginComponent implements OnInit {
  myControl = new FormControl();
  business: any;
  filteredbusinesses: Observable<any[]>;
  apiUri = '/businesses';
  selectedService: any;

  constructor(private http: HttpClient,private router:Router) { }

  ngOnInit() {
    // this.loadBusinesses();
  }

  public CheckPassword(password: string) {

    this.http.get(environment.apiUrl + this.apiUri+"/"+password).subscribe((business => {
      this.business = business;
      console.log(this.business);
    }),
    (error=>{Swal.fire('Oops...', 'password is wrong!', 'error')}))
  }
  next()
  {
    this.router.navigate(['/cashier-desk', this.selectedService.ServiceId]);
  }
  /*private _filter(value: any): any[] {
    console.log(this.filteredbusinesses);
    console.log(this.myControl.value);
    if (typeof (value) === 'string') {
      const filterValue = value.toLowerCase();
      return this.businesses.filter(option => option.BusinessName.toLowerCase().indexOf(filterValue) === 0);
    }
    this.selectedBusiness = value;
    this.myControl.setValue(value.BusinessName);
    const filterValue = value.BusinessName.toLowerCase();
    return this.businesses.filter(option => option.BusinessName.toLowerCase().indexOf(filterValue) === 0);
  }

  loadBusinesses() {
    this.http.get(environment.apiUrl + this.apiUri).subscribe((businesses: any[]) => {
      this.businesses = businesses;
      console.log('businesses', this.businesses);
      this.filteredbusinesses = this.myControl.valueChanges.pipe(
        startWith(''),
        map(value => this._filter(value))
      );
    });
  }*/
}
