import { Component, OnInit } from '@angular/core';
import { User } from '../models/user.model';

const data: User[] = [
  {
    name: 'John',
    address: 'No 1, Lane',
    email: 'email@email.com',
    estimate: 50.2,
    id: 1,
    phone: '119',
  },
];

@Component({
  selector: 'app-right-bar',
  templateUrl: './right-bar.component.html',
  styleUrls: ['./right-bar.component.scss'],
})
export class RightBarComponent implements OnInit {
  displayedColumns = ['name', 'address', 'email', 'phone', 'estimate'];
  dataSource = data;

  ngOnInit(): void {}
}
