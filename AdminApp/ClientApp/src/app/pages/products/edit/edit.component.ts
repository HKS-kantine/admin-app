import { Component, OnInit } from '@angular/core';
import {CollectionCallService} from '../../../services/collection-call/collection-call.service';
import {Product} from '../../../models/product.model';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  product: Product;
  saving = false;

  constructor(private collectionCallService: CollectionCallService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.collectionCallService.get('api/product/' + params.get('id')).subscribe(res => {
        this.product = res;
        console.log(res);
      });
    });
  }
  save() {
    this.saving = true;
    this.collectionCallService.post('api/product', this.product).subscribe(res => {
      this.saving = false;
      this.router.navigate(['assortiment']);
    });
  }
}
