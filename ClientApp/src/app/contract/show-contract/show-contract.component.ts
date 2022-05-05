import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ContractApiService } from 'src/app/Service/contract-api.service';
@Component({
  selector: 'app-show-contract',
  templateUrl: './show-contract.component.html',
  styleUrls: ['./show-contract.component.css']
})
export class ShowContractComponent implements OnInit {

  contractList$!: Observable<any[]>
  constructor(private contractService : ContractApiService) { }

  ngOnInit(): void {
    this.contractList$ = this.contractService.getContractList();
  }

}
