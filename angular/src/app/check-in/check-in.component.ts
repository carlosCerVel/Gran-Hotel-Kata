import { Component, Injector} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import { CheckInServiceProxy, GuestCheckInRequest, RoomListItemDto } from '@shared/service-proxies/service-proxies';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationService, MessageService } from 'primeng-lts/api';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-check-in',
  templateUrl: './check-in.component.html',
  animations: [appModuleAnimation()],
  styleUrls: ['./check-in.component.css'],
  providers: [MessageService, ConfirmationService, ToastrService],

})
export class CheckInComponent extends AppComponentBase {

  saving: boolean = false;
  form: FormGroup;

  roomsAvailable: RoomListItemDto[];
  filteredRoomsAvailable: RoomListItemDto[];

  constructor(
    injector: Injector,
    private formBuilder: FormBuilder,
    private spinner: NgxSpinnerService,
    private _checkInService: CheckInServiceProxy,
    private toastr: ToastrService,
  ) 
  {
    super(injector);
    this.form = new FormGroup({});
  }

  ngOnInit(): void {
    this.initForm();
    this.getAvailableRooms();
  }

  /**
  * Method for init form of component
  */
  initForm() {
    let startDate = new Date();
    let endDate = new Date();
    endDate.setDate(endDate.getDate() + 1);
    this.form = this.formBuilder.group({
      name: ['', Validators.required],
      surname: ['', Validators.required],
      guessID: ['', Validators.required],
      registrationStartDate: [startDate, Validators.required],
      registrationEndDate: [endDate, Validators.required],
      roomSelected: [null, Validators.required],
    });
  }

  /**
  * Method for init form of component
  */
  getAvailableRooms() {
    this._checkInService.getAvailableRooms().subscribe(
      (resp) => {
        this.roomsAvailable = resp;        
        this.filteredRoomsAvailable = this.roomsAvailable;
        this.toastr.success('Rooms Avaiable loaded and ready to selected')
        this.spinner.hide();
      },
      () => {
        this.saving = false;
        this.toastr.success('Failure when fetching the rooms available, please re load the page')
        this.spinner.hide();
      }
    );
  }

  /**
  * Method to search for the room
  */
  searchRoom(event) {
    return (this.filteredRoomsAvailable = [
      ...this.roomsAvailable.filter((r) => r.roomNumber.toLocaleLowerCase().includes(event.query)),
    ]);
  }
    
  
  /**
  * Method to send the check in request
  */
  save() {
    this.spinner.show();
    this.saving = true;
    this.form.controls;
    let checkInRequest: GuestCheckInRequest = this.form.value;
    checkInRequest.roomSelected = this.form.controls['roomSelected'].value.id;

    this._checkInService.newGuessCheckIn(checkInRequest)
      .pipe(finalize(() => this.spinner.hide))
      .subscribe(
      (resp) => {
        this.clean();
        this.getAvailableRooms();
        this.saving = false;
        this.toastr.success('Check In Successful')
      },
      () => {
        this.saving = false;
        this.toastr.error('Failure on Check In')
      }
    );    
  }

  get isInvalidDate() {
    return this.form.controls['registrationStartDate'].value >= this.form.controls['registrationEndDate'].value;
  }

  /*
  * Method to clear the current inputs
  */
  clean(){
    this.form.reset();
    let startDate = new Date();
    let endDate = new Date();
    endDate.setDate(endDate.getDate() + 1);
    this.form.controls['registrationStartDate'].setValue(startDate);
    this.form.controls['registrationEndDate'].setValue(endDate);
  }
}
