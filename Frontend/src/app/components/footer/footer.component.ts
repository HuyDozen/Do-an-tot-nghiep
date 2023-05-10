import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { faFacebook, faInstagram, faGoodreads } from '@fortawesome/free-brands-svg-icons'
import {faCopyright} from '@fortawesome/free-regular-svg-icons'
import { CategoryModelServer } from 'src/app/models/category.model';
import { CategoryService } from 'src/app/services/category.service';
@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
  faFacebook = faFacebook
  faInstagram = faInstagram
  faGoodreads = faGoodreads
  faCopyright = faCopyright

  categories

  constructor(private categoryService: CategoryService,
    private router: Router) {
  }

  ngOnInit(): void {
    this.categoryService.getAllCategories().subscribe({
      next: (data: any) => {
        this.categories = data;

      }
    });
  }
  selectCategory(id: number) {
    this.router.navigate(['list', id]).then();


  }
}


