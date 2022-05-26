import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { User } from '../models/user.model';
import { UsersService } from '../services/users.service';

@Component({
  selector: 'app-left-bar',
  templateUrl: './left-bar.component.html',
  styleUrls: ['./left-bar.component.scss'],
})
export class LeftBarComponent implements OnInit {
  form: FormGroup = this.fb.group({});

  constructor(
    private readonly fb: FormBuilder,
    private readonly usersService: UsersService,
    private readonly toast: ToastrService
  ) {}

  ngOnInit(): void {
    this.initForm();
  }

  private initForm() {
    this.form = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', Validators.required],
      address: ['', Validators.required],
      estimate: ['', [Validators.required, Validators.min(0)]],
    });
  }

  async onSubmit(): Promise<void> {
    if (!this.form.valid) return;

    try {
      const user: User = { id: 0, ...this.form.value };

      if (!(await this.usersService.isEmailAvailable(user.email))) {
        this.toast.error('This email address is already taken');
        return;
      } else if (!(await this.usersService.isPhoneAvailable(user.phone))) {
        this.toast.error('This phone number is already taken');
        return;
      }

      await this.usersService.addUser(user);
      this.form.reset();
    } catch (error) {
      this.toast.error('Creating user failed');
    }
  }
}
