import { Component, OnInit, Injector } from '@angular/core';
import { DepartmentDTO, DepartmentServiceProxy, PagedResultDtoOfDepartmentDTO } from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { CreateDepartmentDialogComponent } from '../create-department-dialog/create-department-dialog.component';
import { EditDepartmentDialogComponent } from '../edit-department-dialog/edit-department-dialog.component';
import { HttpClient } from '@angular/common/http';

class PagedDepartmentsRequestDto extends PagedRequestDto {
  keyword: string;
}
@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.css'],
  animations: [appModuleAnimation()],
  // providers:[DepartmentServiceProxy]
})
export class DepartmentListComponent extends PagedListingComponentBase<DepartmentDTO> implements OnInit  {
  
 

  departs:DepartmentDTO[]=[];
  keyword = '';
  key='';
  public http:HttpClient
  constructor(
    injector: Injector,
    private _DepartmentService: DepartmentServiceProxy,
    private _dialog: MatDialog,  public ht:HttpClient
  ) {
    super(injector);
    this.http=ht;
   }

   ngOnInit() {
    this.refresh();
  
  }
   protected list(request:PagedDepartmentsRequestDto , pageNumber: number, finishedCallback: Function): void {
     request.keyword=this.keyword;
     
    this._DepartmentService.getAll(request.keyword,request.skipCount,request.maxResultCount).pipe(finalize(()=>{
    {finishedCallback();}
  })).subscribe((result:PagedResultDtoOfDepartmentDTO)=>{
    this.departs=result.items;
    this.showPaging(result,pageNumber);
  })
  }
  protected delete(dept: DepartmentDTO): void {
    abp.message.confirm(this.l('EmployeeDeleteWarningMessage'), (result: boolean) => {
      if (result) {
        this._DepartmentService.delete(dept.id).subscribe(() => {
          abp.notify.success(this.l('SuccessfullyDeleted'));
          this.refresh();
        });
      }
    });
  }
  
  create(): void {
   this.showCreateOrEditDialog(0)
  }
  Search()
  {
 this.http.post("http://localhost:21021/api/services/app/Department/SearchByDepartment?keyword="+this.key,{}).subscribe((res:any)=>{

  this.departs=res.result;
 })
  }

  edit(dept:DepartmentDTO): void {
    this.showCreateOrEditDialog(dept.id);

  
  }
  private showCreateOrEditDialog(id: number): void {
    let dialog;

    if (id === undefined || id <= 0) {
      dialog = this._dialog.open(CreateDepartmentDialogComponent);
    } else  {
      
        dialog = this._dialog.open(EditDepartmentDialogComponent, {
            data: id
        });
    

    }

    dialog.afterClosed().subscribe(result => {
      if (result) {
        this.refresh();
      }
    });
  }}





