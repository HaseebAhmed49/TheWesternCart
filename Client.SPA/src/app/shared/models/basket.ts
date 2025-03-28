import cuid from 'cuid';

export interface BasketItem {
  id: string;
  clothingName: string;
  price: number;
  quantity: number;
  pictureUrl: string;
  brand: string;
  discount: number | null
}
export interface Basket {
  id: string;
  items: BasketItem[];
  clientSecret?: string;
  paymentIntentId?: string;
  deliveryMethodId?: string;
  shippingPrice: number;
}
export class Basket implements Basket {
  id = cuid();
  items: BasketItem[] = [];
  shippingPrice = 0;
}
export interface BasketTotals {
  shipping: number;
  subtotal: number;
  total: number;
}