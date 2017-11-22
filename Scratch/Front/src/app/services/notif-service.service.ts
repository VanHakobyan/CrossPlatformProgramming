import { Message } from './../models/Message';
import { Injectable } from '@angular/core';
import { Subject, Observable} from 'rxjs/Rx';
import { Router, NavigationStart, Event} from '@angular/router';
@Injectable()
export class NotifService {

    subject = new Subject<any>();
    constructor(private router: Router) { 
            router.events.subscribe( event => 
            {
                if(event instanceof NavigationStart) {
                        this.subject.next();
                }
            });
    }
    
    success(message: string) {
        this.subject.next(new Message('alert-success', message));
    }
    error(message: string) {
        this.subject.next(new Message('alert-danger', message));
    }
    getMessage(): Observable<any> {
        return this.subject.asObservable();
    }

}
