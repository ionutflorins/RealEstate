import { Component, Input, OnInit } from '@angular/core';
import { ConfigurationOptionApiService } from 'src/app/Service/configuration-option-api.service';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-add-edit-configurationoption',
  templateUrl: './add-edit-configurationoption.component.html',
  styleUrls: ['./add-edit-configurationoption.component.css']
})
export class AddEditConfigurationoptionComponent implements OnInit {

  configurationOptionList$!: Observable<any[]>

  constructor(private configurationOptionService: ConfigurationOptionApiService) { }

  @Input() configOption: any;
  configOptId: number = 0;
  configOptDescription: string = '';
  configItemId: number = 0;


  ngOnInit(): void {
    this.configOptId = this.configOption.id;
    this.configOptDescription = this.configOption.description
    this.configItemId = this.configOption.configurationItemId
  }


  addConfigOption() {
    var configOption = {
      description: this.configOptDescription,
      configurationItemId: this.configItemId
    }
    this.configurationOptionService.addConfigurationOption(configOption).subscribe(res => {
      var closeModalBtn = document.getElementById('add-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }
      var showAddSucces = document.getElementById('add-succes-alert');
      if (showAddSucces) {
        showAddSucces.style.display = "block";
      }

      setTimeout(function () {
        if (showAddSucces) {
          showAddSucces.style.display = "none"
        }
      }, 4000);
    })

  }

  updateConfigOption() {
    var configOption = {
      id:this.configOptId,
      description: this.configOptDescription,
      configurationItemId: this.configItemId
      
    }
    debugger
    var id:number = this.configItemId;
    
    this.configurationOptionService.updateConfigurationOption(configOption).subscribe(res => {
      var closeModalBtn = document.getElementById('add-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }
      var showAddSucces = document.getElementById('update-succes-alert');
      if (showAddSucces) {
        showAddSucces.style.display = "block";
      }
      setTimeout(function () {
        if (showAddSucces) {
          showAddSucces.style.display = "none"
        }
      }, 4000);
    })
  }
}
