import { Component,NgModule, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { ICar } from "../../models/ICar"
import { CarService } from './../../services/car-service.service';
import { NotifService } from './../../services/notif-service.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-updatecar',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateCarComponent  implements OnInit {
  complexForm : FormGroup ;

  constructor(private fb: FormBuilder
    , private carService : CarService
    , private notifService : NotifService
    , private route: ActivatedRoute ){
    // Here we are using the FormBuilder to build out our form.
   this.route.params.subscribe(params => {

      let id = +params['id']; // (+) converts string 'id' to a number
      this.complexForm = fb.group({
        // We can set default values by passing in the corresponding value or leave blank if we wish to not set the value. For our example, we’ll default the gender to female.
        'id' : [""],
        'name' : ["", Validators.required],
        'mark': ["", Validators.required],
        'model' : ["", Validators.required],
       });
 
      this.carService.getCar(id).then(resp => {
        let car = resp.json() as ICar;
 
        this.complexForm = fb.group({
          // We can set default values by passing in the corresponding value or leave blank if we wish to not set the value. For our example, we’ll default the gender to female.
          'id' : [car.id],
          'name' : [car.name, Validators.required],
          'mark': [car.mark, Validators.required],
          'model' : [car.model, Validators.required],
         });
    
      }).catch(exp => {
          this.notifService.error("Server Exception was raised");
       }) ;
     });
  }
  
  ngOnInit() {
  }

  public updateCar(model: ICar){
    console.log(model);
    this.carService.updateCar(model).then(resp => {
      this.notifService.success("Update operation is well done");      
    }).catch(exp => {
        this.notifService.error("Server Exception was raised");
     }) ;
  }
}
