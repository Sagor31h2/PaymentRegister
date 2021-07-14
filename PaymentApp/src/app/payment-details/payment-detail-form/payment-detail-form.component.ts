import { from } from "rxjs";
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PaymentDetail } from "src/app/shared/payment-detail.model";
import { PaymentDetailService } from "src/app/shared/payment-detail.service";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: 'app-payment-detail-form',
  templateUrl: './payment-detail-form.component.html',
  styles: [
  ]
})
export class PaymentDetailFormComponent implements OnInit {

  constructor(public service: PaymentDetailService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {

    this.service.postPaymentDetail().subscribe(

      res => {
        this.resetForm(form);
        this.toastr.success('User details submitted', 'Payment Details Register')
      },
      err => { }
    );
  }
  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new PaymentDetail();
  }

}
