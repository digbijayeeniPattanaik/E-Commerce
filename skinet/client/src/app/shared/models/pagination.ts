import {IProduct} from './product';

export interface IPagination {
    pageSize: number;
    pageIndex: number;
    count: number;
    data: IProduct[];
  }
