import { Component,OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})
export class ListUserComponent implements OnInit {
  users;

  constructor (private user:UserService){

  }

  ngOnInit(): void {
    this.user.getAllUsers().subscribe(prod => {
      this.users = prod
      console.log(this.users);
      
    })
  }
}
