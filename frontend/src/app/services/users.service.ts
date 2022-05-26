import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../models/user.model';

import * as endpoint from './api-endpoints.json';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private _users: User[] = [];
  public get users(): User[] {
    return this._users;
  }

  constructor(private readonly http: HttpClient) {}

  fetchUsers(): Promise<void> {
    const url = `${environment.apiUrl}/${endpoint.users.common}`;

    return new Promise<void>((resolve, reject) => {
      this.http.get<User[]>(url).subscribe({
        next: (value) => {
          this._users = value;
          resolve();
        },
        error: (err) => {
          console.error(err);
          reject();
        },
      });
    });
  }
}
