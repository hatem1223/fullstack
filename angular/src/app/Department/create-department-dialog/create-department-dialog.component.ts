import { Component, OnInit, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { DepartmentServiceProxy, DepartmentDTO } from '@shared/service-proxies/service-proxies';
import { MatDialogRef } from '@angular/material';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-create-department-dialog',
  templateUrl: './create-department-dialog.component.html',
  styleUrls: ['./create-department-dialog.component.css'],
  providers:[DepartmentServiceProxy]
})
export class CreateDepartmentDialogComponent extends AppComponentBase implements OnInit {
  dept:DepartmentDTO=new DepartmentDTO(); 
  saving = false;
  constructor(injector: Injector,
    public prox: DepartmentServiceProxy,
    private _dialogRef: MatDialogRef<CreateDepartmentDialogComponent>) {
    super(injector);
  }

  ngOnInit() {
  }
  save():void
  {
  this.saving=true;
  this.prox.create(this.dept).pipe(finalize(()=>{
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


