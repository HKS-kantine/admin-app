import { Component, OnInit } from '@angular/core';
import {NotificationService} from '../../services/notificiation/notification.service';
import {Notification} from '../../models/notification';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.css']
})
export class NotificationsComponent implements OnInit {

  notifications: Notification[];

  constructor(private notificationService: NotificationService, private toastr: ToastrService) {
    this.notifications = notificationService.notifications;
    this.notifications.forEach(notificiation => {
      this.toastr.info("Hallllo");
    })
  }

  ngOnInit(): void {
    this.toastr.info("Hallllo");
  }


  removeNotification(notification: Notification) {
    this.notificationService.removeNotification(notification);
  }

}
