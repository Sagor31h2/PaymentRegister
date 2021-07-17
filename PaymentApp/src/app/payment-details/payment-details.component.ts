import { Component, OnInit } from '@angular/core';
import { tick } from '@angular/core/testing';
import { ToastrService } from 'ngx-toastr';
import { PaymentDetail } from '../shared/payment-detail.model';
import { PaymentDetailService } from '../shared/payment-detail.service';

@Component({
  selector: 'app-payment-details',
  templateUrl: './payment-details.component.html',
  styles: [
  ]
})
export class PaymentDetailsComponent implements OnInit {

  constructor(public service: PaymentDetailService,
    public toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(seletedRecord: PaymentDetail) {
    this.service.formData = Object.assign({}, seletedRecord);
  }

  onDelete(id: number) {
    if (confirm("Are sure to delete this record")) {
      this.service.deletePaymentDetail(id).subscribe(
        res => {
          this.service.refreshList();
          this.toastr.error("Deleted", "Payment Information")

        },
        err => {
          this.toastr.info("Can't delete", "Payment Information")
        }
      )
    }
  }

}
