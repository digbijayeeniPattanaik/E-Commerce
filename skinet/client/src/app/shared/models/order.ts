import { IAddress } from './address';

export interface IOrderToCreate {
  basketId: string;
  deliveryMethodId: number;
  shipToAddress: IAddress;
}

export interface IOrder {
  id: number;
  buyerEmail: string;
  orderDate: string;
  shipToAdress: IAddress;
  deliveryMethod: string;
  shippingPrice: number;
  orderItems: IOrderItem[];
  subTotal: number;
  total: number;
  status: string;
}

export interface IOrderItem {
  price: number;
  quantity: number;
  productId: number;
  productName: string;
  pictureUrl: string;
}
