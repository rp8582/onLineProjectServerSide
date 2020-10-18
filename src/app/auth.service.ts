import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from '../environments/environment';

@Injectable({ providedIn: 'root' })

export class AuthService {

    private key = 'currentUser';

    constructor(
        private httpClient: HttpClient,
        private router: Router
    ) { }

    login(name, password) {
        let user = { 'userName': name, 'password': password };
        this
            .httpClient
            .post<any>(`${environment.apiUrl}/credentials`, user)
            .subscribe((user: any) => {
                localStorage.setItem(this.key, JSON.stringify(user));
                this.router.navigate(['/']);

            },
                (error: any) => console.log('err', error))

    }

    logout() {
        localStorage.removeItem(this.key);
        this.router.navigate(['/login']);
    }

    //signup(){}

    getCurrentUser() {
        return localStorage.getItem(this.key);
    }
}