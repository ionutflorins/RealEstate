import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { filter, map, tap } from 'rxjs/operators';
import { ClientApiService } from 'src/app/Service/client-api.service';
import { DeveloperApiService } from 'src/app/Service/developer-api.service';





@Component({
  selector: 'app-show-client',
  templateUrl: './show-client.component.html',
  styleUrls: ['./show-client.component.css']
})
export class ShowClientComponent implements OnInit {

  clientList$!: Observable<any[]>;
  clientId!: number | string;

  constructor(private clientService: ClientApiService,
    private developerService: DeveloperApiService,
    private activatedRoute: ActivatedRoute) {
    this.activatedRoute.params.subscribe(params => {
      this.clientId = params['id'];
    });
  }

  ngOnInit(): void {
    if (this.clientId) {
      this.clientList$ = this.clientService.getClientDev(this.clientId);
    } else
      this.clientList$ = this.clientService.getClientList();

  }

  //Variables(properties)
  clientModalTitle: string = "";
  activateAddEditClientComponent: boolean = false;
  client: any;


  modalAdd() {
    this.client = {
      id: 0,
      firstName: null,
      lastName: null,
      phoneNumber: null,
      personalID: null,
      serieNo: null,
      address: null,
      issuedBy: null,
      validity: null,
      developerID: 0
    }
    this.clientModalTitle = "Add Client";
    this.activateAddEditClientComponent = true;
  }

  modalEdit(clientItem: any) {
    this.client = clientItem;
    this.clientModalTitle = "Edit Client"
    this.activateAddEditClientComponent = true;
  }

  deleteClient(clientItem: any) {
    if (confirm(`Are you sure you want to delete ${clientItem.firstName} ${clientItem.lastName} client?`)) {
      this.clientService.deleteClient(clientItem.id).subscribe(res => {
        var closeModalBtn = document.getElementById('add-edit-modal-close');
        if (closeModalBtn) {
          closeModalBtn.click();
        }

        var showDeleteSucces = document.getElementById('delete-succes-alert');
        if (showDeleteSucces) {
          showDeleteSucces.style.display = "block";
        }

        setTimeout(function () {
          if (showDeleteSucces) {
            showDeleteSucces.style.display = "none"
          }
        }, 4000);

        this.clientList$ = this.clientService.getClientList();
      })
    }
  }

  clientModalClose() {
    this.activateAddEditClientComponent = false;
    this.clientList$ = this.clientService.getClientList();
  }
}
