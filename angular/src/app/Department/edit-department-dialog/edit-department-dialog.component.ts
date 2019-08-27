import { Component, OnInit, Injector, Inject, Optional } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { DepartmentServiceProxy, DepartmentDTO } from '@shared/service-proxies/service-proxies';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-edit-department-dialog',
  templateUrl: './edit-department-dialog.component.html',
  styleUrls: ['./edit-department-dialog.component.css'],
  providers:[DepartmentServiceProxy]
})
export class EditDepartmentDialogComponent extends AppComponentBase implements OnInit {

  dept:DepartmentDTO=new DepartmentDTO(); 
  saving = false;
  constructor(injector: Injector,
    public prox: DepartmentServiceProxy,
    @Optional() @Inject(MAT_DIALOG_DATA) private _id: number,
    private _dialogRef: MatDialogRef<EditDepartmentDialogComponent>) {
    super(injector);
  }

  ngOnInit() {
    this.prox.get(this._id).subscribe(result=>{
      this.dept=result;
      console.log("random id "+this._id)
    })
  }
  
  save(): void {
    this.saving = true;

  

    this.prox
      .update(this.dept)
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
