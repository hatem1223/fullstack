import { Component, OnInit, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { EmployeeDTO, EmployeeServiceProxy } from '@shared/service-proxies/service-proxies';
import { MatDialogRef } from '@angular/material';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-create-employee-dialog',
  templateUrl: './create-employee-dialog.component.html',
  styleUrls: ['./create-employee-dialog.component.css'],
  providers:[EmployeeServiceProxy]
})
export class CreateEmployeeDialogComponent extends AppComponentBase implements OnInit {
emp:EmployeeDTO=new EmployeeDTO();
saving = false;
  constructor( inject:Injector,public empservice:EmployeeServiceProxy,
    private _dialogRef: MatDialogRef<CreateEmployeeDialogComponent>
    ) { super(inject) }

  ngOnInit() {
  }
  save():void
  {
  this.saving=true;
  this.empservice.create(this.emp).pipe(finalize(()=>{
    this.saving=false;
  })).subscribe(()=>{
    this.notify.info(this.l("Saved Successfully"))
    this.close(true);
  })
  }
  close(result: any): void {
    this._dialogRef.close(result);
  }

}
