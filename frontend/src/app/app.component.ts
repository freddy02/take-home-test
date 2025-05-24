import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { LoanListComponentComponent } from './components/loan-list-component/loan-list-component.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    LoanListComponentComponent,
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  displayedColumns: string[] = [
    'loanAmount',
    'currentBalance',
    'applicant',
    'status',
  ];
  loans = [
    {
      loanAmount: 25000.0,
      currentBalance: 18750.0,
      applicant: 'John Doe',
      status: 'active',
    },
    {
      loanAmount: 15000.0,
      currentBalance: 0,
      applicant: 'Jane Smith',
      status: 'paid',
    },
    {
      loanAmount: 50000.0,
      currentBalance: 32500.0,
      applicant: 'Robert Johnson',
      status: 'active',
    },
  ];
}
