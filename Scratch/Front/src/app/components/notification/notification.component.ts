import { Component, OnInit } from '@angular/core';
import { NotifService } from './../../services/notif-service.service';
import { Message } from './../../models/Message';
  
 @Component({
  selector: 'notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.css']
})
export class NotificationComponent implements OnInit {

  message : Message;
  constructor(public notifService : NotifService ){}
  
  ngOnInit() {
    this.notifService.getMessage().subscribe(p => 
    {
      this.message = p;
    });
  }

}
