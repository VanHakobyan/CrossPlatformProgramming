import { NotifService } from './../../services/notif-service.service';
import { Component, NgModule , OnInit } from '@angular/core';
import { CarService } from '../../services/car-service.service';
import { Subscription }   from 'rxjs/Subscription';
import { ICar } from './../../models/ICar';
import { Subject } from 'rxjs/Rx';
import { RouterLink, Event } from '@angular/router';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
  
})
export class ListComponent implements OnInit {
   listCars : any = [];
   filtredCars : any = [];
   carName : string = "";
   selectedItem : number;
   dtTrigger = new Subject();
   dtOptions: DataTables.Settings = {};

   constructor(private _carService : CarService, private notifService : NotifService   )  {
      this.init();
   }

   private init()
   {
      this.dtOptions = {
        pagingType: 'full_numbers',
        pageLength: 10        
      };  

      this.selectedItem = -1;
      this._carService.getCars() .then( response => {
        this.listCars = response.json() as ICar[];
        this.filtredCars = this.listCars.slice(0);
        // Calling the DT trigger to manually render the table
        this.dtTrigger.next();
      
      }).catch((resp) => {
        console.log(resp);
        this.notifService.error("Server Exception was raised");
      });
   }
  public searchCar ()
  {
    if(this.selectedItem == -1)
    {
        this.filtredCars = this.listCars.slice(0);
    }else
    {
      this.filtredCars = this.listCars.filter(
        car => car.id == this.selectedItem );
    }
  }

  public deleteCar(id : number)
  {
    this._carService.deleteCar(id).then( response => {
      this.filtredCars = this.filtredCars.filter( 
        (item : ICar) => {
          return (item.id != id)
      })
      this.notifService.success("Delete Operation was well done");
     // this.dtTrigger.next();
    }).catch((resp) => {
         this.notifService.error("Server Exception was raised");
     });
  }
  
  ngOnInit()
  {
  }
 
}
