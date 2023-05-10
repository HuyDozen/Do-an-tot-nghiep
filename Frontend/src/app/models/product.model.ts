export interface ProductModelServer {
    id: number;
    title: string;
    category: string;
    description: string;
    image: string;
    price: number;
    quantity: number;
    images: string;
    shortDesc:string;
    categoryName:string;
  };

  //Du lieu phan hoi cho may chu
  export interface ServerResponse  {
    count: number;
    products: ProductModelServer[];
  };
  
  export interface FilterRequestByIdCategory {
    nameCate:string
    id:number
    page:number
  }