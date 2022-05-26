import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UsersService } from '../services/users.service';

@Component({
  selector: 'app-right-bar',
  templateUrl: './right-bar.component.html',
  styleUrls: ['./right-bar.component.scss'],
})
export class RightBarComponent implements OnInit {
  displayedColumns = ['name', 'address', 'email', 'phone', 'estimate'];

  constructor(
    public readonly usersService: UsersService,
    private readonly toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.fetchData();
  }

  private async fetchData(): Promise<void> {
    try {
      await this.usersService.fetchUsers();
    } catch (error) {
      this.toastr.error('Loading users data failed');
    }
  }
}
