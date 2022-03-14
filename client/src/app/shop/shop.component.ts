import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { ListEntry } from '../shared/models/list-entry';
import { IProduct } from '../shared/models/product';
import { ShopParams } from '../shared/models/shopParams';
import { IType } from '../shared/models/type';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search', { static: false }) 
  searchTherm: ElementRef;

  products: IProduct[];
  brands: IBrand[];
  brandListEntries: Array<ListEntry> = [];
  types: IType[];
  typeListEntries: Array<ListEntry> = [];
  totalCount: number;
  
  shopParams = new ShopParams();

  sortOptions = [
    { name: 'Alphabetical', value: 'nameAsc' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' },
  ];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  private getProducts() {
    this.shopService.getProducts(this.shopParams).subscribe((response) => {
      this.products = response.data;
      this.shopParams.pageNumber = response.pageIndex;
      this.shopParams.pageSize = response.pageSize;
      this.totalCount = response.count;
    }, error => { 
      console.log(error);
    });
  }

  private getBrands() {
    this.shopService.getBrands().subscribe((response) => {
      this.brands = [{id: 0, brandName: 'All'}, ...response]
      this.brands.forEach(element => {
        const entry = new ListEntry();
        entry.id = element.id;
        entry.name = element.brandName;
        this.brandListEntries.push(entry);
      });
    }, error => { 
      console.log(error);
    });
  }

  private getTypes() {
    this.shopService.getTypes().subscribe((response) => {
      this.types = [{id: 0, typeName: 'All'}, ...response]
      this.types.forEach(element => {
        const entry = new ListEntry();
        entry.id = element.id;
        entry.name = element.typeName;
        this.typeListEntries.push(entry);
      });
    }, error => { 
      console.log(error);
    });
  }

  onBrandSelected(brandId: any) {
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onTypeSelected(typeId: any) {
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(sortOption: string) {
    this.shopParams.sort = sortOption;
    this.getProducts();
  }

  onPageChanged(event: any) {
    if (this.shopParams.pageNumber !== event) {
      this.shopParams.pageNumber = event;
      this.getProducts();
    }
  }

  onSearch() {
    this.shopParams.search = this.searchTherm.nativeElement.value;
    this.getProducts();
  }

  onReset() {
    this.searchTherm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProducts();
  }

}
