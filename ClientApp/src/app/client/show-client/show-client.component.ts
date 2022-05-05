import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ClientApiService } from 'src/app/Service/client-api.service';

@Component({
  selector: 'app-show-client',
  templateUrl: './show-client.component.html',
  styleUrls: ['./show-client.component.css']
})
export class ShowClientComponent implements OnInit {

  clientList$!:Observable<any[]>;

  constructor(private clientService : ClientApiService) { }

  ngOnInit(): void {
    this.clientList$ = this.clientService.getClientList();
  }

}
