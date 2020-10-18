import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { AuthService } from '../auth.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  //@Input() error: string | null;
 // @Output() submitEM = new EventEmitter();

 form: FormGroup = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });

constructor(private authService:AuthService) { }
 

  ngOnInit(): void {
  }
 
 
  submit() {
    if (this.form.valid) {
      //קריאה לשרת לבדוק אם הוא משתמש רשום ואם לא:
      this.authService.login(this.form.value.username,this.form.value.password);
      console.log(this.form);
    }
  }

}
