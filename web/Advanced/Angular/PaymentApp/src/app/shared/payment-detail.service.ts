import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PaymnetDetail } from './paymnet-detail.model';

@Injectable({
  providedIn: 'root'
})
export class PaymentDetailService {

  constructor(private http: HttpClient) { }

  readonly baseUrl = 'http://localhost:61236/api/PaymentDetail';
  formData: PaymnetDetail = new PaymnetDetail();
}
