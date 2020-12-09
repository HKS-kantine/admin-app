import {Injectable, OnInit} from '@angular/core';
import {Notification} from '../../models/notification';
import {nocollapseHack} from '@angular/compiler-cli/src/transformers/nocollapse_hack';
import {CollectionCallService} from '../collection-call/collection-call.service';
import * as signalR from '@aspnet/signalr';
import {environment} from '../../../environments/environment';
import {AuthService} from '../auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class NotificationService implements OnInit {

  notifications: Notification[] = [{
    title: 'test',
    message: 'hallo',
    icon: null,
    type: 'info'
  }];

  private url = 'NotificationUserHub?userId=' + 1;

  private connection: any = new signalR.HubConnectionBuilder()
    .withUrl(`${environment.collectionURL}${this.url}`)
    .configureLogging(signalR.LogLevel.Information)
    .build();

  private userId = 1;
  private connectionId;

  constructor(private auth: AuthService, private collectionCallService: CollectionCallService) {
    if (this.auth.loggedIn) {
      this.url = 'NotificationUserHub?userId=' + 1;
      this.connection.on('sendToUser', (notification) => {
        console.log(notification);
        this.notifications.push(notification);
      });
    }

    this.connection.start().catch(function (err) {
      return console.error(err.toString());
    }).then(res => {this.getConnectionId()});
  }

  ngOnInit(): void {

  }

  getConnectionId() {
    this.connection.invoke('GetConnectionId').then(function (connectionId) {
      console.log(connectionId);
      if (connectionId !== 'undefined') {
        this.connectionId = connectionId;
        console.log(connectionId);

      }
    });
  }

  removeNotification(notification: Notification) {
    const index: number = this.notifications.indexOf(notification);
    this.getConnectionId();
    if (index !== -1) {
      this.notifications.splice(index, 1);
    }
  }
}
