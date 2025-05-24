import { Component, OnInit } from '@angular/core';
import { LoanService } from '../../services/Loan.service';
import { Loan } from '../../models/Loan.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-loan-list-component',
  imports: [CommonModule],
  templateUrl: './loan-list-component.component.html',
  styleUrl: './loan-list-component.component.scss',
})
export class LoanListComponentComponent implements OnInit {
  LoanStatusMap = {
    1: 'Active',
    2: 'Inactive',
    3: 'Pending',
  };
  loans: Loan[] = [];

  constructor(private loanService: LoanService) {}

  async ngOnInit() {
    try {
      this.loans = await this.loanService.getAllLoans();
      console.log('Loans loaded successfully:', this.loans);
    } catch (error) {
      console.error('Failed to load loans');
    }
  }
}
