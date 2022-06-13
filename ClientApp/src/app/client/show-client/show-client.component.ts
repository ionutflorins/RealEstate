import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { filter, map, tap } from 'rxjs/operators';
import { ClientApiService } from 'src/app/Service/client-api.service';
import { DeveloperApiService } from 'src/app/Service/developer-api.service';
import { take } from 'rxjs/operators';
import jwt_decode from 'jwt-decode';
import { UserService } from 'src/app/Service/user.service';
@Component({
  selector: 'app-show-client',
  templateUrl: './show-client.component.html',
  styleUrls: ['./show-client.component.css']
})
export class ShowClientComponent implements OnInit {

  clientList$!: Observable<any[]>;
  devID!: number | string;
  decoded: any;

  constructor(private clientService: ClientApiService,
    private developerService: DeveloperApiService,
    private userServ:UserService,
    private activatedRoute: ActivatedRoute,
    private router: Router) {
    console.log(this.router.getCurrentNavigation()!.extras.state);
    this.devID = this.router.getCurrentNavigation()?.extras.state?.devID;
  }

  ngOnInit(): void {
    var token = localStorage.getItem('token');
    this.decoded = jwt_decode(`${token}`);

    if (this.devID) {
      this.clientList$ = this.clientService.getClientDev(this.devID);
    } else if (this.decoded.UserID) {
      this.clientList$ = this.clientService.getClientByUserID(this.decoded.UserID)
    } else {
      this.clientList$ = this.clientService.getClientList();
    }
  }
  //Variables(properties)
  clientModalTitle: string = "";
  activateAddEditClientComponent: boolean = false;
  client: any;

  regClient(){
    this.userServ.register();
  }

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
      developerID: this.devID
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

        if (this.devID) {
          this.clientList$ = this.clientService.getClientDev(this.devID);
        } else if (this.decoded.UserID) {
          this.clientList$ = this.clientService.getClientByUserID(this.decoded.UserID)
        } else {
          this.clientList$ = this.clientService.getClientList();
        }
      })
    }
  }

  clientModalClose() {
    this.activateAddEditClientComponent = false;
    if (this.devID) {
      this.clientList$ = this.clientService.getClientDev(this.devID);
    } else if (this.decoded.UserID) {
      this.clientList$ = this.clientService.getClientByUserID(this.decoded.UserID)
    } else {
      this.clientList$ = this.clientService.getClientList();
    }
  }

  getContract(clientID: number | string) {
    this.router.navigateByUrl('Contract-List', {
      state: {
        clientID
      }
    });
  }
}
