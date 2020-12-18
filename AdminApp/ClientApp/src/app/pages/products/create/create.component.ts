import { Component, OnInit } from '@angular/core';
import {Product} from '../../../models/product.model';
import {CollectionCallService} from '../../../services/collection-call/collection-call.service';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
  product: Product = {} as Product;
  creating = false;

  constructor(private collectionCallService: CollectionCallService, private router: Router) { }

  ngOnInit(): void {
  }

  create() {
    this.creating = true;
    this.collectionCallService.post('api/product', this.product).subscribe(res => {
      this.creating = false;
      this.router.navigate(['assortiment']);
    });
  }

}
