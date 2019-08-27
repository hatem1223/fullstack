import { Component, OnInit, Injector } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { EmployeeDTO, EmployeeServiceProxy, PagedResultDtoOfDepartmentDTO, PagedResultDtoOfEmployeeDTO, DepartmentServiceProxy } from '@shared/service-proxies/service-proxies';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { CreateEmployeeDialogComponent } from '../create-employee-dialog/create-employee-dialog.component';
import { EditEmployeeDialogComponent } from '../edit-employee-dialog/edit-employee-dialog.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { empty } from 'rxjs';
import { request } from 'http';
import { HttpClient } from '@angular/common/http';
class PagedEmployeesRequestDto extends PagedRequestDto {
  keyword: string;
}
@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
  animations: [appModuleAnimation()],
  // providers:[EmployeeServiceProxy]
})
export class EmployeeListComponent extends PagedListingComponentBase<EmployeeDTO> implements OnInit {
  emp: EmployeeDTO[] = [];
  keyword = '';
  key = '';
  public http: HttpClient
  //str=undefined;
  constructor(injector: Injector, private _EmployeeService: EmployeeServiceProxy,
    private _dialog: MatDialog, http: HttpClient) {
    super(injector)
    this.http = http;
  }
  ngOnInit() {
    this.refresh();



  }

  protected list(request: PagedEmployeesRequestDto, pageNumber: number, finishedCallback: Function): void {
    request.keyword = this.keyword;
   //request.keyword=this.key;
    //this.key=request.keyword;
    //request.keyword=this.str;
    this._EmployeeService.getAll(request.keyword, request.skipCount, request.maxResultCount).pipe(finalize(() => {

      { finishedCallback(); }
    })).subscribe((result: PagedResultDtoOfEmployeeDTO) => {
      this.emp = result.items;
      this.showPaging(result, pageNumber);
    })
  }
  Search() {

    this.http.post("http://localhost:21021/api/services/app/Employee/SearchByName?keyword=" + this.key, {})
      .subscribe((res: any) => {
        this.emp = res.result;
      });
  }
  /*getDataPage(pageNumber:number)
  {
   this._EmployeeService.getAll(this.keyword,0,5).subscribe((res:PagedResultDtoOfEmployeeDTO)=>{
     this.emp=res.items;
     this.showPaging(res,pageNumber);
   
   })
  }*/

  protected delete(emp: EmployeeDTO): void {
    abp.message.confirm(this.l('EmployeeDeleteWarningMessage'), (result: boolean) => {
      if (result) {
        this._EmployeeService.delete(emp.id).subscribe(() => {
          abp.notify.success(this.l('SuccessfullyDeleted'));
          this.refresh();
        });
      }
    });
  }

  create(): void {
    this.showCreateOrEditDialog(0)
  }

  edit(emp: EmployeeDTO): void {
    this.showCreateOrEditDialog(emp.id);


  }

  private showCreateOrEditDialog(id: number): void {
    let dialog;

    if (id === undefined || id <= 0) {
      dialog = this._dialog.open(CreateEmployeeDialogComponent);
    } else {

      dialog = this._dialog.open(EditEmployeeDialogComponent, {
        data: id
      });


    }

    dialog.afterClosed().subscribe(result => {
      if (result) {
        this.refresh();
      }
    });
  }
}