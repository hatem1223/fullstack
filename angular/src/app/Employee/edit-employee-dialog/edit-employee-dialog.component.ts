import { Component, OnInit, Injector, Optional, Inject } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';

import { EmployeeServiceProxy, EmployeeDTO } from '@shared/service-proxies/service-proxies';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-edit-employee-dialog',
  templateUrl: './edit-employee-dialog.component.html',
  styleUrls: ['./edit-employee-dialog.component.css'],
  providers:[EmployeeServiceProxy]
})
export class EditEmployeeDialogComponent extends AppComponentBase implements OnInit {
emp:EmployeeDTO=new EmployeeDTO();
saving = false;
  constructor(inject:Injector,public empservice:EmployeeServiceProxy,
    @Optional() @Inject(MAT_DIALOG_DATA) private _id: number,
    private _dialogRef:MatDialogRef<EditEmployeeDialogComponent>
    
    
    ) {
    super(inject);
  }



  ngOnInit() {
    this.empservice.get(this._id).subscribe(result=>{
  this.emp=result;
  console.log(this._id);
    })
  }

  save(): void {
    this.saving = true;

  

    this.empservice
      .update(this.emp)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close(true);
      });
  }
  close(result: any): void {
    this._dialogRef.close(result);
  }

}
