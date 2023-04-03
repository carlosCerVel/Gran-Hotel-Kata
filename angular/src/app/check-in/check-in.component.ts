import { Component, Injector, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import { CheckInServiceProxy } from '@shared/service-proxies/service-proxies';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng-lts/api';

@Component({
  selector: 'app-check-in',
  templateUrl: './check-in.component.html',
  animations: [appModuleAnimation()],
  styleUrls: ['./check-in.component.css'],
  providers: [MessageService, ConfirmationService],

})
export class CheckInComponent extends AppComponentBase {

  saving: boolean = false;
  form: FormGroup;

  date7: Date;

  constructor(
    injector: Injector,
    private formBuilder: FormBuilder,
    private spinner: NgxSpinnerService,
    private _checkInService: CheckInServiceProxy,
  ) 
  {
    super(injector);
    this.form = new FormGroup({});
  }

  ngOnInit(): void {
    this.initForm()
  }

  /**
  * Method for init form of component
  */
  initForm() {
    this.form = this.formBuilder.group({
      name: ['', Validators.required],
      surname: ['', Validators.required],
      id: ['', Validators.required],
      registrationStartDate: [new Date(), Validators.required],
      registrationEndDate: [new Date(), Validators.required],
    });
  }


  save() {
    this.spinner.show();
    this.saving = true;
    this.form.controls;
    this._checkInService.test().subscribe(
      (resp) => {
        this.saving = false;
        this.spinner.hide();
      },
      () => {
        this.saving = false;
        this.spinner.hide();
      }
    );
    
  }

  close() {      
  }
}
