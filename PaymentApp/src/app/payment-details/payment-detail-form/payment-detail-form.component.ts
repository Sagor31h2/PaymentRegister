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

    if (this.service.formData.paymentDetailsId == 0) {
      this.insertRecord(form);
    }
    else
      this.updateRecord(form)

  }

  insertRecord(form: NgForm) {
    console.log("sumit");
    this.service.postPaymentDetail().subscribe(

      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('User details submitted', 'Payment Details Register')
      },
      err => { }
    );
  }

  updateRecord(form: NgForm) {
    console.log("Update");
    this.service.putPaymentDetail().subscribe(

      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('User details Updated', 'Payment Details Register')
      },
      err => { }
    );
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new PaymentDetail();
  }

}
