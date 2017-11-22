
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs/Rx';
import { Http, Headers, RequestOptions, Response, RequestMethod } from '@angular/http';
import { ICar } from './../models/ICar';

@Injectable()
export class CarService {
    carsList : ICar[];
    _baseUrl : string = "http://localhost:5000/api/";
    _getCarsUrl : string = "ManageCar"; 
    options = new RequestOptions({
        withCredentials : true
    }); 
    constructor(private http: Http) { 
 
    }
    public getCars() {
        return this.http.get(this._baseUrl + this._getCarsUrl, this.options)
        .toPromise();
    }
    public getCar(id : number) {
        return this.http.get(this._baseUrl + this._getCarsUrl + "/"+ id, this.options)
        .toPromise();
    }
    public addNewCar(_car : ICar){
       return this.http.post(this._baseUrl + this._getCarsUrl, _car, this.options)
       .toPromise();
     }
    public updateCar(_car : ICar){
        return this.http.put(this._baseUrl + this._getCarsUrl + "/"+  _car.id, _car, this.options)
        .toPromise();
    }
    public deleteCar(id : number){
         return this.http.delete(this._baseUrl + this._getCarsUrl + "/"+ id, this.options)
        .toPromise();    
    }
  
}