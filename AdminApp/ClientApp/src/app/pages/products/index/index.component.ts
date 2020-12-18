import { Component, OnInit } from '@angular/core';
import {CollectionCallService} from '../../../services/collection-call/collection-call.service';
import {Product} from '../../../models/product.model';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  products: Product[];

  constructor(private collectionCallService: CollectionCallService) { }

  ngOnInit(): void {
    this.collectionCallService.get('api/product').subscribe(res => {
      this.products = res;
      console.log(res);
    });
  }

}
