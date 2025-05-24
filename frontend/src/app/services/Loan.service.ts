import { Injectable } from '@angular/core';
import axios from 'axios';
import { Loan } from '../models/Loan.model';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class LoanService {
  private baseUrl = environment.apiUrl;

  async getAllLoans(): Promise<Loan[]> {
    try {
      const response = await axios.get<Loan[]>(`${this.baseUrl}/all`);
      console.log(response);
      return response.data;
    } catch (error) {
      console.error('Error fetching loans:', error);
      throw error;
    }
  }
}
