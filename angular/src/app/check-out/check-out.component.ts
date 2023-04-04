import { Component, Injector} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import { CheckOutServiceProxy, GuestCheckOutRequest, RoomListItemDto } from '@shared/service-proxies/service-proxies';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationService, MessageService } from 'primeng-lts/api';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-check-out',
  templateUrl: './check-out.component.html',
  animations: [appModuleAnimation()],
  styleUrls: ['./check-out.component.css'],
  providers: [MessageService, ConfirmationService, ToastrService],
})
export class CheckOutComponent extends AppComponentBase {

  saving: boolean = false;
  form: FormGroup;

  roomsCurrentlyOccupied: RoomListItemDto[];
  filteredRoomsCurrentlyOccupied: RoomListItemDto[];

  constructor(
    injector: Injector,
    private formBuilder: FormBuilder,
    private spinner: NgxSpinnerService,
    private _checkOutService: CheckOutServiceProxy,
    private toastr: ToastrService,
  ) 
  {
    super(injector);
    this.form = new FormGroup({});
  }

  ngOnInit(): void {
    this.initForm();
    this.getCurrentlyOccupiedRooms();
  }

  /**
  * Method for init form of component
  */
  initForm() {
    this.form = this.formBuilder.group({
      roomSelected: [null, Validators.required],
    });
  }

  /**
  * Method for init form of component
  */
  getCurrentlyOccupiedRooms() {
    this._checkOutService.getRoomsCurrentlyOccupied().subscribe(
      (resp) => {
        this.roomsCurrentlyOccupied = resp;        
        this.filteredRoomsCurrentlyOccupied = this.roomsCurrentlyOccupied;
        this.toastr.success('Rooms Currently Occupied loaded and ready to selected')
        this.spinner.hide();
      },
      () => {
        this.saving = false;
        this.toastr.success('Failure when fetching the rooms currently occupied, please re load the page')
        this.spinner.hide();
      }
    );
  }

  /**
  * Method to search for the room
  */
  searchRoom(event) {
    return (this.filteredRoomsCurrentlyOccupied = [
      ...this.roomsCurrentlyOccupied.filter((r) => r.roomNumber.toLocaleLowerCase().includes(event.query)),
    ]);
  }
    
  
  /**
  * Method to send the check in request
  */
  save() {
    this.spinner.show();
    this.saving = true;
    this.form.controls;
    let checkOutRequest: GuestCheckOutRequest = new GuestCheckOutRequest;
    checkOutRequest.roomSelected = this.form.controls['roomSelected'].value.id;

    this._checkOutService.guestCheckOut(checkOutRequest)
      .pipe(finalize(() => this.spinner.hide))
      .subscribe(
      (resp) => {
        this.clean();
        this.getCurrentlyOccupiedRooms();
        this.saving = false;
        this.toastr.success('Check Out Successful')
      },
      () => {
        this.saving = false;
        this.toastr.error('Failure on Check Out')
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
  }
}
